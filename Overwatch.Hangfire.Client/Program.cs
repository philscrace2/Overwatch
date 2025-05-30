using Hangfire;
using Newtonsoft.Json;
using Spectre.Console;


namespace Overwatch.Hangfire.Client
{
    public class Program
    {
        private const string projects = @"C:\Overwatch\Projects";
        static List<TestProject> overwatchprojects = new List<TestProject>();
        static void Main(string[] args)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("Server=UKCAML11345\\MSSQLSERVER01;Database=HangfireDb;Trusted_Connection=True;TrustServerCertificate=True;");

            // Using Spectre Console to list and select tests
            string projects = Program.projects;

            overwatchprojects = GetOverwatchProjectsFromDisk(projects);

            var cts = new CancellationTokenSource();
            var watchTask = Task.Run(() => WatchForNewTestProjects(projects, cts.Token));

            while (true)
            {
                // Display Spectre Console UI for test selection
                var selectedTests = PromptTestSelection(overwatchprojects);

                // Execute selected tests using Hangfire
                TestRunner.ExecuteTestsAsync(selectedTests).Wait();

                var continueRunning = AnsiConsole.Prompt(new TextPrompt<string>("Do you want to select more tests? (y/n)").PromptStyle("green"));

                if (continueRunning.ToLower() != "y")
                {
                    break;
                }

                selectedTests.Clear();

                overwatchprojects = GetOverwatchProjectsFromDisk(@"C:\Overwatch\Projects");

            }

            Console.WriteLine("Exiting application.");

        }

        // Spectre.Console: Display UI for selecting tests
        private static List<TestProject> PromptTestSelection(List<TestProject> availableProjects)
        {
            // Display tests as a checklist for user selection
            var selectedProjects = AnsiConsole.Prompt(
                new MultiSelectionPrompt<string>()
                    .Title("Select tests to run:")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more tests)[/]")
                    .AddChoices(availableProjects.Select(p => p.Name).ToArray()));

            //Console.WriteLine($"Selected tests: {string.Join(", ", selectedTests)}");
            return availableProjects.Where(p => selectedProjects.Contains(p.Name)).ToList();
        }

        private static List<TestProject> GetOverwatchProjectsFromDisk(string directory)
        {
            List<TestProject> testProjects = new List<TestProject>();

            // Assuming test projects are directories or files in the given directory
            foreach (var dir in Directory.GetDirectories(directory))
            {
                string projectFile = Path.Combine(dir, "project.json");
                if (File.Exists(projectFile))
                {
                    // Deserialize the JSON to create a test project object
                    var testProject = JsonConvert.DeserializeObject<TestProject>(File.ReadAllText(projectFile));
                    testProjects.Add(testProject);
                }
            }

            return testProjects;
        }

        private static void WatchForNewTestProjects(string directory, CancellationToken cancellationToken)
        {
            var watcher = new FileSystemWatcher(directory)
            {
                NotifyFilter = NotifyFilters.DirectoryName | NotifyFilters.FileName,
                Filter = "project.json",  // Watch for project.json files
                IncludeSubdirectories = true
            };


            watcher.Created += (sender, e) =>
            {
                // Re-load the test projects list when a new project file is created
                Console.WriteLine("New test project detected, refreshing the list...");

                overwatchprojects = GetOverwatchProjectsFromDisk(projects);
            };

            watcher.EnableRaisingEvents = true;

            // Wait for cancellation signal
            while (!cancellationToken.IsCancellationRequested)
            {
                Thread.Sleep(1000); // Keep the watcher alive
            }

            watcher.Dispose();
        }


    }
}

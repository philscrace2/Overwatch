using Hangfire;
using Newtonsoft.Json;
using Spectre.Console;


namespace Overwatch.Hangfire.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("Server=UKCAML11345\\MSSQLSERVER01;Database=HangfireDb;Trusted_Connection=True;TrustServerCertificate=True;");

            // Using Spectre Console to list and select tests
            //var tests = GetOverwatchProjectTests();

            var overwatchprojects = GetOverwatchProjectsFromDisk(@"C:\Overwatch\Projects");

            // Display Spectre Console UI for test selection
            var selectedTests = PromptTestSelection(overwatchprojects);

            // Execute selected tests using Hangfire
            TestRunner.ExecuteTestsAsync(selectedTests).Wait();

            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();

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

        //private static List<string> GetOverwatchProjectTests(string directory)
        //{
        //    List<string> testProjects = new List<string>();

        //    // Assuming test projects are directories or files in the given directory
        //    foreach (var dir in Directory.GetDirectories(directory))
        //    {
        //        // Add the directory name or file to the list of test projects
        //        testProjects.Add(Path.GetFileName(dir));
        //    }

        //    return testProjects;
        //}

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


    }
}

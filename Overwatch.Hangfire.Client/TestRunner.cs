using Hangfire;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overwatch.Hangfire.Client
{
    public class TestRunner
    {
        static string m_toolsPath = @"C:\Overwatch\tools";
        static string m_projectsPath = @"C:\Overwatch\Projects";
        static string m_toolName = "ct.exe";

        // Hangfire job to execute selected tests
        public static async Task ExecuteTestsAsync(List<TestProject> selectedTests)
        {
            Console.WriteLine($"Executing {selectedTests.Count} tests...");

            // Dynamically run the tests in parallel
            foreach (var test in selectedTests)
            {
                // Enqueue each test to run in parallel via Hangfire
                BackgroundJob.Enqueue(() => RunTest(test));
            }

            await Task.CompletedTask;
        }

        public static void RunTest(TestProject testProject)
        {
            try
            {
                // Path for log output
                string logFilePath = Path.Combine(Path.Combine(m_projectsPath, testProject.Name), $"log.txt");
                string projectsFilePath = Path.Combine(m_projectsPath, testProject.Name);

                // Create the log directory if it doesn't exist
                Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));

                // Set up ProcessStartInfo for running the executable
                var processStartInfo = new ProcessStartInfo
                {
                    FileName = Path.Combine(m_toolsPath, m_toolName),  // Path to ct tool
                    Arguments = $"{testProject.Arguments}",  // Test project and parameters
                    UseShellExecute = false,
                    RedirectStandardOutput = true,  // Redirect standard output to a file
                    RedirectStandardError = true,   // Redirect error output to a file
                    CreateNoWindow = true,           // Don't show the command window
                    WorkingDirectory = projectsFilePath   // Set the working directory
                };

                // Start the process
                var process = new Process
                {
                    StartInfo = processStartInfo
                };

                // Handle output redirection and write the output to a log file
                using (var writer = new StreamWriter(logFilePath, append: false))
                {
                    process.OutputDataReceived += (sender, e) =>
                    {
                        if (e.Data != null)
                        {
                            writer.WriteLine($"OUTPUT: {e.Data}");
                        }
                    };

                    process.ErrorDataReceived += (sender, e) =>
                    {
                        if (e.Data != null)
                        {
                            writer.WriteLine($"ERROR: {e.Data}");
                        }
                    };

                    process.Start();

                    // Start reading the output asynchronously
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    process.WaitForExit();  // Wait for the process to finish
                }

                // Check if the test passed based on exit code
                if (process.ExitCode == 0)
                {
                    // Log success to Hangfire and console
                    Console.WriteLine($"Test {testProject} passed.");
                    //HangfireContext.SetJobStatus(JobStatus.Succeeded);
                }
                else
                {
                    // Log failure to Hangfire and console
                    Console.WriteLine($"Test {testProject} failed. See log for details.");
                    //HangfireContext.SetJobStatus(JobStatus.Failed);
                }
            }
            catch (Exception ex)
            {
                // Log exception to Hangfire and console
                Console.WriteLine($"Error running test {testProject}: {ex.Message}");
                //HangfireContext.SetJobStatus(JobStatus.Failed);
            }
        }
    }
}

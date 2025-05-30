using OpenAI;
using OpenAI.Chat;
using OpenAI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        //Console.WriteLine(GetNModelTests(ReadTextFileFromDisk("Scenario_Test.txt")));

        //Console.WriteLine(GenerateNModelTestsFromImage("newsreader.jpg"));

        Console.WriteLine("Executing tests using Conformance Tester tool");

        RunConformanceTester(GenerateNModelTestsFromImage("newsreader.jpg"));

        Console.ReadLine();
    }

    public static string SendOpenAIRequest(string request)
    {
        var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
        //var client = new OpenAIClient(apiKey);

        ChatClient client = new ChatClient(model: "gpt-4o-turbo", apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

        ChatCompletion completion = client.CompleteChat(request);

        return completion.Content[0].Text;

    }

    public static string GetNModelTests(string model)
    {
        string requestNModelTestsTemplate = "Generate the tests from this NModel FSM definition ensuring" +
            " that TestSuite is the top node and TestCase are the individual test case nodes" +
            "Format is as follows with only one root node and many TestCase nodes" +
            "TestSuite(\r\n    TestCase(\r\n        StartState(0),\r\n        ShowTitles(),\r\n        ShowText(),\r\n        EndState(0)\r\n    ),\r\n    TestCase(\r\n        StartState(0),\r\n        SelectMessages(),\r\n        SelectTopics(),\r\n        EndState(0)\r\n    ))" +
            model;


        string testSuite = SendOpenAIRequest(requestNModelTestsTemplate);

        return testSuite;
    }

    public static string ReadTextFileFromDisk(string filename)
    {
        try
        {
            // Get the directory of the executing assembly
            string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // Construct the full path to the text file
            string filePath = Path.Combine(assemblyDirectory, filename);

            // Read and display the file contents
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
            else
            {
                Console.WriteLine("File not found: " + filePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading the file: " + ex.Message);
        }

        return "";

    }

    public static string GenerateTestsFromImage(string imageCommand, string imageFileName)
    {
        var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
        //var client = new OpenAIClient(apiKey);

        ChatClient client = new ChatClient(model: "gpt-4o", apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

        // Get the directory of the executing assembly
        string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        Stream imageStream = File.OpenRead(Path.Combine(assemblyDirectory, imageFileName));
        var imageBytes = BinaryData.FromStream(imageStream);

        var messages = new List<ChatMessage>
            {
                new UserChatMessage(new List<ChatMessageContentPart>
                {
                    ChatMessageContentPart.CreateTextPart(imageCommand),
                    ChatMessageContentPart.CreateImagePart(imageBytes, "image/png")
                })
            };

        var completion = client.CompleteChat(messages);
        string result = completion.Value.Content[0].Text.TrimStart(new char[] { '\r', '\n', '`', 'p', 'l', 'a', 'i', 'n', 't', 'e', 'x', 't' })
            .TrimStart(new char[] { '\r', '\n', '`' })
            .TrimEnd(new char[] { '\r', '\n', '`' });

        return result;
    }

    public static string GenerateNModelTestsFromImage(string imageFileName)
    {
        string command = "Generate the tests from this NModel image definition ensuring" +
            " that TestSuite is the top node and TestCase are the individual test case nodes. No need to give introductory sentences like 'Here's the test suite based on the provided NModel image definition:'" +
            "Format is as follows with only one root node and many TestCase nodes" +
            "TestSuite(\r\n    TestCase(\r\n        StartState(0),\r\n        ShowTitles(),\r\n        ShowText(),\r\n        EndState(0)\r\n    ),\r\n    TestCase(\r\n        StartState(0),\r\n        SelectMessages(),\r\n        SelectTopics(),\r\n        EndState(0)\r\n    ))";

        return GenerateTestsFromImage(command, imageFileName);
    }

    public static string RunConformanceTester(string arguments)
    {
        string exePath = @"../../ct.exe";
        string output = String.Empty;
        string errorOutput = String.Empty;

        if(File.Exists(exePath)); // Ensure the path is correct)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = exePath,  // The executable to run
                Arguments = "",      // Optional: If ct.exe requires arguments, pass them here
                RedirectStandardOutput = true, // Redirect output if needed
                RedirectStandardError = true,  // Redirect error output if needed
                UseShellExecute = false,  // Don't use shell for execution
                CreateNoWindow = true   // Don't create a new window
            };

            try
            {
                Process process = Process.Start(startInfo);

                // If needed, read output or error stream
                if (process != null)
                {
                    output = process.StandardOutput.ReadToEnd();
                    errorOutput = process.StandardError.ReadToEnd();

                    // Optionally, print the output/error to the console
                    Console.WriteLine("Output: " + output);
                    if (!string.IsNullOrEmpty(errorOutput))
                    {
                        Console.WriteLine("Error: " + errorOutput);
                    }

                    process.WaitForExit();  // Wait for the process to finish
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error running ct.exe: " + ex.Message);
            }
        }

        // This method would contain the logic to run the conformance tester tool
        // with the provided test suite and model program.
        // For now, we will just return a placeholder string.
        return $"Running conformance tests with:\nTest Suite: {arguments}\nModel Program:";
    }

}


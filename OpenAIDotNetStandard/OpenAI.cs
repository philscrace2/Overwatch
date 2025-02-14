using OpenAI;
using OpenAI.Models;
using System.Threading.Tasks;
using System;
using OpenAI.Chat;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

class Program
{
    static async Task Main(string[] args)
    {
        //Console.WriteLine(GetNModelTests(ReadTextFileFromDisk("Scenario_Test.txt")));

        Console.WriteLine(GenerateNModelTestsFromImage("newsreader.jpg"));

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
        return completion.Value.Content[0].Text;

    }

    public static string GenerateNModelTestsFromImage(string imageFileName)
    {
        string command = "Generate the tests from this NModel image definition ensuring" +
            " that TestSuite is the top node and TestCase are the individual test case nodes" +
            "Format is as follows with only one root node and many TestCase nodes" +
            "TestSuite(\r\n    TestCase(\r\n        StartState(0),\r\n        ShowTitles(),\r\n        ShowText(),\r\n        EndState(0)\r\n    ),\r\n    TestCase(\r\n        StartState(0),\r\n        SelectMessages(),\r\n        SelectTopics(),\r\n        EndState(0)\r\n    ))";

        return GenerateTestsFromImage(command, imageFileName);
    }

}


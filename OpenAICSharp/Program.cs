// See https://aka.ms/new-console-template for more information
using OpenAI;
using OpenAI.Chat;

var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
//var client = new OpenAIClient(apiKey);

ChatClient client = new(model: "gpt-4o", apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

ChatCompletion completion = client.CompleteChat("What is the capital of france?");

Console.WriteLine($"[ASSISTANT]: {completion.Content[0].Text}");

Console.ReadLine();


using Docker.DotNet;
using Docker.DotNet.Models;
using System;
using System.IO;
using System.Threading.Tasks;

class DockerAutomation
{
    public static async Task BuildDockerImageAsync(string dockerfilePath, string imageName)
    {
        // Create a new DockerClient
        using (var client = new DockerClientConfiguration(new Uri("unix:///var/run/docker.sock")).CreateClient())
        {
            // Read the Dockerfile as a stream
            using (var fileStream = new FileStream(dockerfilePath, FileMode.Open, FileAccess.Read))
            {
                // Set the build parameters
                var buildParameters = new ImageBuildParameters
                {
                    Tags = new[] { imageName }
                };

                // Build the Docker image
                var buildResult = await client.Images.BuildImageFromDockerfileAsync(fileStream, buildParameters);

                // Read the result stream (output of the build process)
                using (var reader = new StreamReader(buildResult))
                {
                    var output = await reader.ReadToEndAsync();
                    Console.WriteLine(output);
                }
            }

            Console.WriteLine($"Docker image {imageName} built successfully.");
        }
    }

    public static async Task Main(string[] args)
    {
        string dockerfilePath = "path/to/Dockerfile";  // Path to your Dockerfile
        string imageName = "my-custom-image";          // Name of the image you want to build

        await BuildDockerImageAsync(dockerfilePath, imageName);
    }
}

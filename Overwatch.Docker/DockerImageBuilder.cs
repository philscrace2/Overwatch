using Docker.DotNet;
using Docker.DotNet.Models;
using global::Docker.DotNet.Models;
using global::Docker.DotNet;
using System;
using System.Threading.Tasks;

namespace Overwatch.Docker
{
    class DockerAutomation
    {
        public static async Task BuildDockerImageAsync(string dockerfilePath, string imageName)
        {
            // Create a new DockerClient
            using (var client = new DockerClientConfiguration(new Uri("unix:///var/run/docker.sock")).CreateClient())
            {
                // Set the build parameters
                var buildParameters = new ImageBuildParameters
                {
                    Tags = new[] { imageName },
                    Dockerfile = dockerfilePath
                };

                // Build the Docker image
                var buildResult = await client.Images.BuildImageFromDockerfileAsync(new Uri(dockerfilePath), buildParameters);

                // Read the result stream
                using (var reader = new System.IO.StreamReader(buildResult))
                {
                    var output = reader.ReadToEnd();
                    Console.WriteLine(output);
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

}

using Docker.DotNet;
using Docker.DotNet.Models;
using System;
using System.Threading.Tasks;

namespace Overwatch.Docker
{
    public class DockerTestRunner
    {
        private static async Task RunTestsInDocker()
        {
            var client = new DockerClientConfiguration(new Uri("unix:///var/run/docker.sock")).CreateClient();

            // Create and start a new container
            var container = await client.Containers.CreateContainerAsync(new CreateContainerParameters
            {
                Image = "mcr.microsoft.com/dotnet/core/sdk:3.1", // Choose the appropriate image
                Cmd = new[] { "dotnet", "test" }, // Command to run the tests
                Tty = true
            });

            await client.Containers.StartContainerAsync(container.ID, new ContainerStartParameters());

            // Wait for container to finish and collect the results (simplified for illustration)
            var logs = await client.Containers.GetContainerLogsAsync(container.ID, new ContainerLogsParameters { ShowStdout = true, ShowStderr = true });
            Console.WriteLine(logs);

            // Clean up container
            await client.Containers.RemoveContainerAsync(container.ID, new ContainerRemoveParameters { Force = true });
        }

        public static void Main()
        {
            RunTestsInDocker().GetAwaiter().GetResult();
        }
    }

}

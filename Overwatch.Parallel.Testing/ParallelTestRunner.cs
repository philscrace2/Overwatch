using System;
using System.Threading.Tasks;


namespace Overwatch.Parallel.Testing
{
    public class ParallelTestRunner
    {
        public async Task RunTestsInParallel()
        {
            var task1 = Task.Run(() => RunTest("Test1"));
            var task2 = Task.Run(() => RunTest("Test2"));

            await Task.WhenAll(task1, task2);
        }

        public void RunTest(string testName)
        {
            Console.WriteLine($"Running {testName}");
            // Add actual test execution logic here
        }

        public static void Main()
        {
            var runner = new ParallelTestRunner();
            runner.RunTestsInParallel().GetAwaiter().GetResult();
        }
    }

}

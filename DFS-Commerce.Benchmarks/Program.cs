using BenchmarkDotNet.Running;

namespace DFS_Commerce.Benchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ListVsBinarySearchTree>();
        }
    }
}

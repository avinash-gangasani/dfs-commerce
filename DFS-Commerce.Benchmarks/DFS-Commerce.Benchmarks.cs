using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using DFS_Commerce.Models;
using DFS_Commerce.Services;

namespace DFS_Commerce.Benchmarks
{
    [SimpleJob(RuntimeMoniker.Net10_0)]
    [RPlotExporter]
    public class ListVsBinarySearchTree
    {
        IProductService _service = new ProductService();
        List<Product> products = new List<Product>();
        BinarySearchTree bst = new BinarySearchTree();
        double min = 100;
        double max = 200;

        [Params(100, 1000, 10000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            var allProducts = _service.GetProducts("products_1000.json").Result;
            if(N < allProducts.Count())
            {
                products = allProducts.Take(N).ToList();
            }
            else if(N > allProducts.Count())
            {
                int multiplier = N / allProducts.Count();

                for(int i=0; i<multiplier; i++)
                {
                    products.AddRange(allProducts);
                }
            }
            else
            {
                products = allProducts;
            }

            foreach(var product in products)
            {
                bst.Insert(product);
            }
        }

        [Benchmark]
        public List<Product> List()
        {
            return products.Where(x => x.Price <= max && x.Price >= min).ToList();
        }

        [Benchmark]
        public List<Product> BinarySearchTree()
        {
            return bst.Filter(min, max);
        }
    }
}

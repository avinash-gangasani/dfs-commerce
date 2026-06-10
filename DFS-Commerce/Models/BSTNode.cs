namespace DFS_Commerce.Models
{
    public class BSTNode
    {
        public BSTNode Left { get; set; }
        public BSTNode Right { get; set; }
        public Product Value { get; }

        public BSTNode(Product product)
        {
            Value = product;
        }
    }
}

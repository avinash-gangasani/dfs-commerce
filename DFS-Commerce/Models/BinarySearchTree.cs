namespace DFS_Commerce.Models
{
    public class BinarySearchTree
    {
        private List<Product> Products { get; set; }
        private BSTNode Root { get; set; }

        public BinarySearchTree()
        {
            Products = new List<Product>();
        }

        public void Insert(Product product)
        {
            Root = Insert(Root, product);
        }

        public List<Product> Filter(double min, double max)
        {
            Products.Clear();
            Find(Root, min, max);
            return Products;
        }

        private BSTNode Insert(BSTNode node, Product product)
        {
            if (node == null) return new BSTNode(product);

            if(node.Value.Price < product.Price)
            {
                node.Right = Insert(node.Right, product);
            }
            else
            {
                node.Left = Insert(node.Left, product);
            }
            return node;
        }

        private void Find(BSTNode node, double min, double max)
        {
            if (node == null) return;

            if (node.Value.Price > max)
            {
                Find(node.Left, min, max);
            }
            else if(node.Value.Price < min)
            {
                Find(node.Right, min, max);
            }
            else
            {
                Find(node.Left, min, max);
                Products.Add(node.Value);
                Find(node.Right, min, max);
            }

        }


    }
}

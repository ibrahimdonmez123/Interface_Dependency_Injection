namespace Interface_Dependency_Injection.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts(); 
        Product GetProduct(int id); 
        Product Delete(int id);  
        Product Add(Product newProduct); 
        Product Update(Product updateProduct); 
    }
}






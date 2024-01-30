namespace Interface_Dependency_Injection.Models
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _productlist;
        public ProductRepository()
        {
            _productlist = new List<Product>()
            {
                new Product() { ID=1,Adi="Televizyon",Fiyat=2000,Kategori="Elektronik"},
                new Product() { ID=2,Adi="Cep telefonu",Fiyat=2000,Kategori="Elektronik"},
                new Product() { ID=3,Adi="Masa",Fiyat=2000,Kategori="Ev eşyası"},
                new Product() { ID=4,Adi="BuzDolabı",Fiyat=2000,Kategori="Beyaz eşya"},
                new Product() { ID=5,Adi="Çamaşır Makinesi",Fiyat=2000,Kategori="Beyaz eşya"}

            };
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productlist.ToList();
        }

        public Product GetProduct(int id)
        {
            return _productlist.FirstOrDefault(p => p.ID == id);
        }

        public Product Add(Product newProduct)
        {
            _productlist.Add(newProduct);
            return newProduct;
        }

        public Product Delete(int id)
        {
            Product productDelete = _productlist.FirstOrDefault(p => p.ID == id);
            if (productDelete != null)
            {
                _productlist.Remove(productDelete);
            }
            return productDelete;
        }




        public Product Update(Product updateProduct)
        {
            Product existingProduct = _productlist.FirstOrDefault(p => p.ID == updateProduct.ID);

            if (existingProduct != null)
            {
                existingProduct.Adi = updateProduct.Adi;
                existingProduct.Fiyat = updateProduct.Fiyat;
                existingProduct.Kategori = updateProduct.Kategori;


                return existingProduct;
            }

            return null;

        }
    }
}

namespace MediatrExample.Persistence;

public class FakeDataStore
{
    private static List<Product> _products;

    public FakeDataStore()
    {
        _products = new List<Product>
        {
            new() { Id = 1, Name = "Some prod 1" },
            new() { Id = 2, Name = "Some prod 2" },
            new() { Id = 3, Name = "Some prod 3" }
        };
    }

    public async Task AddProduct(Product product)
    {
        _products.Add(product);
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<Product>> GetAllProducts() =>
        await Task.FromResult(_products);
}
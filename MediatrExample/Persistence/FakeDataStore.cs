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

    public async Task AddProductAsync(Product product)
    {
        _products.Add(product);
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync() =>
        await Task.FromResult(_products);

    public async Task<Product> GetProductByIdAsync(long id)
        => await Task.FromResult(_products.Single(x => x.Id == id));
}
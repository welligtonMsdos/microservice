using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _cliente;
    public const string BASE_PATH = "api/v1/Product";

    public ProductService(HttpClient cliente)
    {
        _cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
    }

    public async Task<IEnumerable<Product>> FindAllProducts()
    {
        var response = await _cliente.GetAsync(BASE_PATH);

        return await response.ReadContentAs<List<Product>>();
    }

    public async Task<Product> FindProductById(long id)
    {
        var response = await _cliente.GetAsync($"{BASE_PATH}/{id}");

        return await response.ReadContentAs<Product>();
    }

    public async Task<Product> CreateProduct(Product product)
    {
        var response = await _cliente.PostAsJson(BASE_PATH, product);

        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<Product>();
        else throw new Exception("Something went wrong when calling API");
    }

    public async Task<Product> UpdateProduct(Product product)
    {
        var response = await _cliente.PutAsJson(BASE_PATH, product);

        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<Product>();
        else throw new Exception("Something went wrong when calling API");
    }

    public async Task<bool> DeleteProductById(long id)
    {
        var response = await _cliente.DeleteAsync($"{BASE_PATH}/{id}");

        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<bool>();
        else throw new Exception("Something went wrong when calling API");
    }
}

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

    public async Task<IEnumerable<ProductModel>> FindAllProducts()
    {
        var response = await _cliente.GetAsync(BASE_PATH);

        return await response.ReadContentAs<List<ProductModel>>();
    }

    public async Task<ProductModel> FindProductById(long id)
    {
        var response = await _cliente.GetAsync($"{BASE_PATH}/{id}");

        return await response.ReadContentAs<ProductModel>();
    }

    public async Task<ProductModel> CreateProduct(ProductModel product)
    {
        var response = await _cliente.PostAsJson(BASE_PATH, product);

        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<ProductModel>();
        else throw new Exception("Something went wrong when calling API");

    }

    public async Task<ProductModel> UpdateProduct(ProductModel product)
    {
        var response = await _cliente.PutAsJson(BASE_PATH, product);

        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<ProductModel>();
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

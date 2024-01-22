﻿using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _client;
    public const string BASE_PATH = "api/v1/Product";

    public ProductService(HttpClient cliente)
    {
        _client = cliente ?? throw new ArgumentNullException(nameof(cliente));
    }

    public async Task<IEnumerable<ProductViewModel>> FindAllProducts()
    {
        var response = await _client.GetAsync(BASE_PATH);

        return await response.ReadContentAs<List<ProductViewModel>>();
    }

    public async Task<ProductViewModel> FindProductById(long id)
    {
        var response = await _client.GetAsync($"{BASE_PATH}/{id}");

        return await response.ReadContentAs<ProductViewModel>();
    }

    public async Task<ProductViewModel> CreateProduct(ProductViewModel product)
    {
        var response = await _client.PostAsJson(BASE_PATH, product);

        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<ProductViewModel>();
        else throw new Exception("Something went wrong when calling API");
    }

    public async Task<ProductViewModel> UpdateProduct(ProductViewModel product)
    {
        var response = await _client.PutAsJson(BASE_PATH, product);

        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<ProductViewModel>();
        else throw new Exception("Something went wrong when calling API");
    }

    public async Task<bool> DeleteProductById(long id)
    {
        var response = await _client.DeleteAsync($"{BASE_PATH}/{id}");

        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<bool>();
        else throw new Exception("Something went wrong when calling API");
    }
}

using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using PAW3.Data.Models;
using PAW3.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW3.Core.BusinessLogic;

public interface IProductBusiness
{
    /// <summary>
    /// Deletes the product associated with the product id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteProductAsync(int id);
    /// <summary>
    /// Gets the product associated with the product id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Product> GetProduct(int id);

    /// <summary>
    /// Update the product
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    Task<bool> UpdateProductAsync(Product product);

    /// <summary>
    /// Get all products.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<IEnumerable<Product>> GetProducts();

    /// <summary>
    /// Gets all products that are in inventory (InventoryId =! NULL).
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Product>> GetProductsInInventory();

    /// <summary>
    /// Creates the product item.
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    Task<bool> SaveProductAsync(Product product);

    /// <summary>
    /// Check if the product exists.
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    Task<bool> FindProduct(Product product);
}

public class ProductBusiness(IRepositoryProduct repositoryProduct) : IProductBusiness
{
    /// </inheritdoc>
    public async Task<bool> SaveProductAsync(Product product)
    {
        product.ModifiedBy ??= "System";
        product.LastModified = DateTime.UtcNow;
        //Business logic here
        return await repositoryProduct.UpsertAsync(product, false);
    }

    /// </inheritdoc>
    public async Task<bool> UpdateProductAsync(Product product)
    {
        product.ModifiedBy ??= "System";
        product.LastModified = DateTime.UtcNow;
        //Business logic here 
        return await repositoryProduct.UpsertAsync(product, true);
    }

    /// </inheritdoc>
    public async Task<bool> DeleteProductAsync(int id)
    {
        var product = await repositoryProduct.FindAsync(id);
        return await repositoryProduct.DeleteAsync(product);
    }

    /// </inheritdoc>
    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await repositoryProduct.ReadAsync();
    }

    /// </inheritdoc>
    public async Task<IEnumerable<Product>> GetProductsInInventory()
    {
        var products = await repositoryProduct.ReadAsync();

        return products = products.Where(p => p.InventoryId != null);
    }

    /// </inheritdoc>
    public async Task<Product> GetProduct(int id)
    {
        //Business logic here
        return await repositoryProduct.FindAsync(id);
    }

    /// </inheritdoc>
    public async Task<bool> FindProduct(Product product)
    {
        return await repositoryProduct.ExistsAsync(product);
    }
}


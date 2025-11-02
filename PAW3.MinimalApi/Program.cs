using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PAW3.Core.BusinessLogic;
using PAW3.Data.Models;
using PAW3.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IProductBusiness, ProductBusiness>();
builder.Services.AddScoped<ICategoryBusiness, CategoryBusiness>();
builder.Services.AddScoped<IInventoryBusiness, InventoryBusiness>();
builder.Services.AddScoped<IComponentBusiness, ComponentBusiness>();
builder.Services.AddScoped<IRepositoryProduct, RepositoryProduct>();
builder.Services.AddScoped<IRepositoryCategory, RepositoryCategory>();
builder.Services.AddScoped<IRepositoryInventory, RepositoryInventory>();
builder.Services.AddScoped<IRepositoryComponent, RepositoryComponent>();

var app = builder.Build();


//CORRESPONDE A TAREA 3
app.MapGet("/ProductItems", async (IProductBusiness productBusiness) =>
    await productBusiness.GetProducts());
app.MapGet("/ProductItems/{id}", async (int id, IProductBusiness productBusiness) =>
    await productBusiness.GetProduct(id));

app.MapGet("/CategoryItems", async (ICategoryBusiness categoryBusiness) =>
    await categoryBusiness.GetCategories());
app.MapGet("/CategoryItems/{id}", async (int id, ICategoryBusiness categoryBusiness) =>
    await categoryBusiness.GetCategory(id));

app.MapGet("/InventoryItems", async (IInventoryBusiness inventoryBusiness) =>
    await inventoryBusiness.GetInventories());
app.MapGet("/InventoryItems/{id}", async (int id, IInventoryBusiness inventoryBusiness) =>
    await inventoryBusiness.GetInventory(id));

app.MapGet("/ComponentItems", async (IComponentBusiness componentBusiness) =>
    await componentBusiness.GetComponents());
app.MapGet("/ComponentItems/{id}", async (int id, IComponentBusiness componentBusiness) =>
    await componentBusiness.GetComponent(id));




///RELLENO COMO USAR MINIMAL API
app.MapGet("/ProductItems/InInventory", async (IProductBusiness productBusiness) =>  // Depending on the DB
    await productBusiness.GetProductsInInventory());

//app.MapGet("/ProductItems/{id}", async (int id, IProductBusiness productBusiness) =>
//    await productBusiness.GetProduct(id)
//        is Product product
//            ? Results.Ok(product)
//            : Results.NotFound($"Sorry, there's no product for code {id}"));

app.MapPost("/ProductItems", async ( Product product, IProductBusiness productBusiness) =>
{
    await productBusiness.SaveProductAsync(product);

    return Results.Created($"/ProductItems/{product.ProductId}", product);
});

app.MapPut("/ProductItems/{id}", async (int id, Product inputProduct, IProductBusiness productBusiness) =>
{
    var product = await productBusiness.GetProduct(id);

    if (product is null) return Results.NotFound($"Product with code {id} does not exist");

    product.ProductId = id;
    product.ProductName = inputProduct.ProductName;
    product.InventoryId = inputProduct.InventoryId;
    product.SupplierId = inputProduct.SupplierId;
    product.Description = inputProduct.Description;
    product.Rating = inputProduct.Rating;
    product.CategoryId = inputProduct.CategoryId;
    product.LastModified = DateTime.UtcNow;
    product.ModifiedBy = inputProduct.ModifiedBy;
    product.Category = inputProduct.Category;
    product.Inventory = inputProduct.Inventory;
    product.Supplier = inputProduct.Supplier;

    await productBusiness.UpdateProductAsync(product);

    return Results.Ok(product);
});


app.MapDelete("/ProductItems/{id}", async (int id, IProductBusiness productBusiness) =>
{
    if (await productBusiness.GetProduct(id) is Product product)
    {
        await productBusiness.DeleteProductAsync(id);
        return Results.Ok(product);
    }

    return Results.NotFound($"Product with code {id} does not exist");
});

app.Run();
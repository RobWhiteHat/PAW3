using PAW3.Architecture;
using PAW3.Models.DTOs;
using PAW3.ServiceLocator.Helper;
using PAW3.ServiceLocator.Services;
using PAW3.ServiceLocator.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection----
builder.Services.AddScoped<IRestProvider, RestProvider>();
builder.Services.AddScoped<IDogDataService, DogDataService>();
builder.Services.AddScoped<ITempDataService, TempDataService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IComponentService, ComponentService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
//builder.Services.AddScoped<ICategoryService, CategoryService>(); **EXAMPLE**

// DTOS----
builder.Services.AddScoped<IService<ProductDTO>, ProductService>();
builder.Services.AddScoped<IService<InventoryDTO>, InventoryService>();
builder.Services.AddScoped<IService<CategoryDTO>, CategoryService>();
builder.Services.AddScoped<IService<ComponentDTO>, ComponentService>();
builder.Services.AddScoped<IService<NotificationDTO>, NotificationService>();
builder.Services.AddScoped<IService<RoleDTO>, RoleService>();
builder.Services.AddScoped<IService<SupplierDTO>, SupplierService>();
//builder.Services.AddScoped<IService<CategoryDTO>, CategoryService>(); **EXAMPLE**

builder.Services.AddScoped<IServiceMapper, ServiceMapper>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

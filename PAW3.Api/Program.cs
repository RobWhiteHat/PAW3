using PAW3.Core.BusinessLogic;
using PAW3.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Business Core Logic
builder.Services.AddScoped<IProductBusiness, ProductBusiness>();
builder.Services.AddScoped<IInventoryBusiness, InventoryBusiness>();
builder.Services.AddScoped<ICategoryBusiness, CategoryBusiness>();
builder.Services.AddScoped<IComponentBusiness, ComponentBusiness>();
builder.Services.AddScoped<INotificationBusiness, NotificationBusiness>();
builder.Services.AddScoped<IRoleBusiness, RoleBusiness>();
builder.Services.AddScoped<ISupplierBusiness, SupplierBusiness>();

//Data Repositories
builder.Services.AddScoped<IRepositoryProduct, RepositoryProduct>(); 
builder.Services.AddScoped<IRepositoryCategory, RepositoryCategory>();
builder.Services.AddScoped<IRepositoryInventory, RepositoryInventory>();
builder.Services.AddScoped<IRepositoryComponent, RepositoryComponent>();
builder.Services.AddScoped<IRepositoryNotification, RepositoryNotification>();
builder.Services.AddScoped<IRepositoryRole, RepositoryRole>();
builder.Services.AddScoped<IRepositorySupplier, RepositorySupplier>();


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

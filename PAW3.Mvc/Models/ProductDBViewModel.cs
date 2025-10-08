using Microsoft.AspNetCore.Mvc;
using PAW3.Models.DTOs;

namespace PAW3.Mvc.Models;

public class ProductDBViewModel
{
    public string Title { get; set; } = "My App";
    public IEnumerable<string> Items { get; set; } = [];
    public IEnumerable<ProductDTO> Products { get; set; } = [];
    public IEnumerable<InventoryDTO> Inventory { get; set; } = [];
    public IEnumerable<CategoryDTO> Categories { get; set; } = [];
    public IEnumerable<ComponentDTO> Component { get; set; } = [];
    public IEnumerable<NotificationDTO> Notification { get; set; } = [];
    public IEnumerable<RoleDTO> Role { get; set; } = [];
    public IEnumerable<SupplierDTO> Supplier { get; set; } = [];



    //public IEnumerable<CategoryDTO> Category { get; set; } = []; **EXAMPLE**
}

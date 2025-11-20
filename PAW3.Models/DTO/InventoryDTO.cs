using PAW3.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW3.Models.DTO
{
    public class InventoryDTO
    {
        public IEnumerable<Inventory> Inventories { get; set; } = [];

        public List<Summary> Summaries { get; set; } = [];
    }
}

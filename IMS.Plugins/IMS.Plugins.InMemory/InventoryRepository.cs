﻿using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Interfaces;

namespace IMS.Plugins.InMemory
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<Inventory> _inventories;

        public InventoryRepository()
        {
            _inventories = new List<Inventory>()
            {
                new Inventory { Id = 1, Name = "Bike Seat", Quantity = 10, Price = 20  },
                new Inventory { Id = 2, Name = "Bike Body", Quantity = 10, Price = 30  },
                new Inventory { Id = 3, Name = "Bike Wheels", Quantity = 20, Price = 10  },
                new Inventory { Id = 2, Name = "Bike Pedels", Quantity = 10, Price = 5  },
            };
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return await Task.FromResult(_inventories);
            }
            return _inventories.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
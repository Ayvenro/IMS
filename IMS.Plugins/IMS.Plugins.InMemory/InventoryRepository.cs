using IMS.CoreBusiness;
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

        public Task AddInventoryAsync(Inventory inventory)
        {
            if (_inventories.Any(x => x.Name.Equals(inventory.Name, StringComparison.OrdinalIgnoreCase)))
            {
                return Task.CompletedTask;
            }
            IncreaseIdByOne(inventory);
            _inventories.Add(inventory);
            return Task.CompletedTask;
        }

        private void IncreaseIdByOne(Inventory inventory)
        {
            var maxId = _inventories.Max(x => x.Id);
            inventory.Id = maxId + 1;
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return await Task.FromResult(_inventories);
            }
            return _inventories.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public Task EditInventoryAsync(Inventory inventory)
        {
            if (_inventories.Any(x => x.Name.Equals(inventory.Name, StringComparison.OrdinalIgnoreCase)))
            {
                return Task.CompletedTask;
            }
            var inv = _inventories.FirstOrDefault(x => x.Id == inventory.Id);
            if (inv != null)
            {
                inv.Name = inventory.Name;
                inv.Quantity = inventory.Quantity;
                inv.Price = inventory.Price;
            }
            return Task.CompletedTask;
        }

        public async Task<Inventory> GetInventoriesByIdAsync(int id)
        {
            var inv = await Task.FromResult(_inventories.First(x => x.Id == id));
            var newInv = new Inventory
            {
                Id = id,
                Name = inv.Name,
                Quantity = inv.Quantity,
                Price = inv.Price
            };
            return newInv;
        }
    }
}
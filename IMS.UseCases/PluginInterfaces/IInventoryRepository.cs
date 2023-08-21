using IMS.CoreBusiness;

namespace IMS.UseCases.Inventories.Interfaces
{
    public interface IInventoryRepository
    {
		Task AddInventoryAsync(Inventory inventory);
		Task EditInventoryAsync(Inventory inventory);
        Task<Inventory> GetInventoriesByIdAsync(int id);
        Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name);
    }
}

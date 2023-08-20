using IMS.CoreBusiness;

namespace IMS.UseCases.Inventories.Interfaces
{
    public interface IInventoryRepository
    {
		Task AddInventoryAsync(Inventory inventory);
		Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name);
    }
}

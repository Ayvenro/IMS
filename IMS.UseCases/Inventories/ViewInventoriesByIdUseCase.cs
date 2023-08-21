using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Interfaces;

namespace IMS.UseCases.Inventories
{
    public class ViewInventoriesByIdUseCase : IViewInventoriesByIdUseCase
    {
        private readonly IInventoryRepository _inventoryRepository;

        public ViewInventoriesByIdUseCase(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<Inventory> ExecuteAsync(int id)
        {
            return await _inventoryRepository.GetInventoriesByIdAsync(id);
        }
    }
}

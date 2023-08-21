using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Interfaces;

namespace IMS.UseCases.Inventories
{
    public class EditInventoryUseCase : IEditInventoryUseCase
	{
		private readonly IInventoryRepository _inventoryRepository;

		public EditInventoryUseCase(IInventoryRepository inventoryRepository)
		{
			_inventoryRepository = inventoryRepository;
		}

		public async Task ExecuteAsync(Inventory inventory)
		{
			await _inventoryRepository.EditInventoryAsync(inventory);
		}
	}
}

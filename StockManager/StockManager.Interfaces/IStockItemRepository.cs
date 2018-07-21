using System.Collections.Generic;
using StockManager.Models;
using System.Threading.Tasks;

namespace StockManager.Interfaces
{
    public interface IStockItemRepository
    {
        Task<StockItem> GetById(string storeId, string name);

        Task<List<StockItem>> GetAllItems();

        Task<string> CreateItem(StockItem item);
    }
}
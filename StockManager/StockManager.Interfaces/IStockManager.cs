
using System.Collections.Generic;
using StockManager.Models;
namespace StockManager.Interfaces
{
    public interface IStockManager
    {
         StockItem GetStockItemById(string id, string itemId);
         List<StockItem> GetStockItemsByQuery(StockItemQuery queryParameters);
         List<StockItem> GetAllItems();//This will need multitenancy support
         string CreateStockItem(StockItem stockItem);
    }
}
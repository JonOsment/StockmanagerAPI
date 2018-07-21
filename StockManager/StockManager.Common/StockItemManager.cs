using System;
using System.Collections.Generic;
using StockManager.Interfaces;
using StockManager.Models;
namespace StockManager.Common
{
    public class StockItemManager : IStockManager
    {

        private IStockItemRepository stockItemRepository{get;set;}

        public StockItemManager (IStockItemRepository _stockItemRepository){
            stockItemRepository = _stockItemRepository;
        }

        public StockItem GetStockItemById(string storeId, string itemId)
        {
            return stockItemRepository.GetById(storeId, itemId).Result;
        }

        public string CreateStockItem(StockItem stockItem)
        {
            return stockItemRepository.CreateItem(stockItem).Result;
        }

        public List<StockItem> GetStockItemsByQuery(StockItemQuery query)
        {
            return new List<StockItem>();    
        }

        public List<StockItem> GetAllItems(){
            return stockItemRepository.GetAllItems().Result; 
        }
    }
}

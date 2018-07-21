namespace StockManager.Common
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Amazon;
    using Amazon.DynamoDBv2;
    using Amazon.DynamoDBv2.Model;
    using Amazon.DynamoDBv2.DataModel;
    using Amazon.DynamoDBv2.DocumentModel;
    using System.Linq;
    
    using WebModels = Models;
    using DynamoModels = StockManager.Models.Dto.Dynamo;


    public class StockItemDynamoRepository : IStockItemRepository
    {

        private IDynamoDBContext context { get; set;}
        private IMapper mapper {get;set;}

        public StockItemDynamoRepository(IDynamoDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<WebModels.StockItem> GetById(string storeId, string itemName)
        {
            DynamoModels.StockItem item = await context.LoadAsync<DynamoModels.StockItem>(storeId, rangeKey: itemName);
            //.QueryAsync<DynamoModels.StockItem>(storeId, QueryOperator.Equals, itemName).GetRemainingAsync(); 
            var stockItem = mapper.Map<WebModels.StockItem>(item);
            return stockItem;
        }

        public async Task<List<WebModels.StockItem>> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public async Task<string> CreateItem(WebModels.StockItem item)
        {
            var stockItem = mapper.Map<DynamoModels.StockItem>(item);
            stockItem.RangeKey = stockItem.ItemName;
            stockItem.PartitionKey = stockItem.StoreId;
            await context.SaveAsync(stockItem);
            return item.ItemName;
        }

    }
}
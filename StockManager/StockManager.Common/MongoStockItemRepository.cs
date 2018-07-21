namespace StockManager.Common
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Interfaces;
    using Models;
    using Models.Dto.Mongo;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization;
    using MongoDB.Driver;
    public class MongoStockItemRepository //: IStockItemRepository 
    {
        /*
        private IMapper mapper{get;set;}
        public MongoStockItemRepository(IMapper _mapper){
            mapper = _mapper;
        }

        public string SaveStockItem(){
            throw new NotImplementedException();
        }


        private IMongoCollection<Models.Dto.Mongo.StockItem> GetCollection(){
            var client = new MongoClient("mongodb://localhost:27017");
            var dataBase = client.GetDatabase("StockManager");
            return dataBase.GetCollection<Models.Dto.Mongo.StockItem>("stockItem");
        }

        public List<Models.StockItem> GetAllItems(){
            var stockItems = new List<Models.StockItem>();
            var collection = GetCollection();
            foreach(Models.Dto.Mongo.StockItem document in collection.Find<Models.Dto.Mongo.StockItem>(x => true).ToEnumerable())
            {
                stockItems.Add(mapper.Map<Models.StockItem>(document));
            }

            return stockItems;
        }

        public string CreateItem(Models.StockItem item)
        {
            var collection = GetCollection();
            var dtoStockItem = mapper.Map<Models.Dto.Mongo.StockItem>(item);
            collection.InsertOne(dtoStockItem);

            return dtoStockItem.Id.ToString();
        }

        public Models.StockItem GetById(string id)
        {
            var collection = GetCollection();
            var filter = Builders<Models.Dto.Mongo.StockItem>.Filter.Eq("_id", new ObjectId(id));
            var stockItem = collection.Find(filter).FirstOrDefault();
            if(stockItem == null){
                return null; //Should really throw an exception that bubbles up into a 404.
            }
            return mapper.Map<Models.StockItem>(stockItem);
             
        }*/
    }
}
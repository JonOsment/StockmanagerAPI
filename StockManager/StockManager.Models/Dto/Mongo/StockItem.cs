using System.Collections.Generic;

namespace StockManager.Models.Dto.Mongo
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Driver;
    
    [BsonIgnoreExtraElements]
    public class StockItem
    {
        public ObjectId Id { get; set; }
        public string itemName { get; set; }
        public int amount { get; set; }
        public List<string> tags {get;set;}
        public double price{get;set;}
    }
}
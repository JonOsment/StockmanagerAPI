namespace StockManager.Models.Dto.Dynamo
{
    using Amazon.DynamoDBv2.DataModel;
    using System.Collections.Generic;
    public class StockItem
    {
        [DynamoDBHashKey]
        public string PartitionKey {get; set;} //{ get { return StoreId; } }

        [DynamoDBRangeKey]
        public string RangeKey {get; set;}//{ get {return $"{ProductType}_{ItemName}"; } }

        public string ProductType{ get; set;}

        public string StoreId{get;set;}
        
        public string ItemName{get;set;}

        public int Amount { get; set; }

        public List<string> Tags {get;set;}
        
        public double Price{get;set;}
    }
}
using System;
using System.Collections.Generic;
namespace StockManager.Models
{
    public class StockItem
    {
        public string StoreId {get;set;}

        public string ItemName { get; set; }
        
        public string ProductType { get; set;}
        
        public int Amount { get; set; }
        
        public List<string> Tags {get;set;}
        
        public double Price{get;set;}
    }
}

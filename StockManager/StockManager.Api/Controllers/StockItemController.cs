using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockManager.Models;
using StockManager.Interfaces;
namespace StockManager.Api.Controllers
{
    [Route("api/[controller]")]
    public class StockItemController : Controller
    {
        private IStockManager StockItemManager{get;set;}
        public StockItemController(IStockManager _StockItemManager)
        {
            StockItemManager = _StockItemManager;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<StockItem> Get([FromQuery] List<string> Tag, [FromQuery] string Name)
        {
            var itemQuery = new StockItemQuery();
            if(Name != null || Tag.Any())
            {
                return StockItemManager.GetStockItemsByQuery(itemQuery);
            }
            return StockItemManager.GetAllItems();
        }

        // GET api/values/5
        [HttpGet("{storeId}/{itemName}")]
        public StockItem Get(string storeId, string itemName )
        {
            return StockItemManager.GetStockItemById(storeId, itemName);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]StockItem Item)
        {
            var createdId = StockItemManager.CreateStockItem(Item);
            return Created($"api/StockItem/{createdId}", createdId);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

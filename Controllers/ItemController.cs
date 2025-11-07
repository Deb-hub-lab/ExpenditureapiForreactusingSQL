using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MyExpenditure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        // In-memory store for demonstration purposes
        private static readonly List<Item> Items = new();

        // GET: /Item
        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetAll()
        {
            return Ok(Items);
        }

        // GET: /Item/{id}
        [HttpGet("{id}")]
        public ActionResult<Item> GetById(int id)
        {
            var item = Items.FirstOrDefault(i => i.Id == id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        // POST: /Item
        [HttpPost]
        public ActionResult<Item> Create(Item item)
        {
            item.Id = Items.Count > 0 ? Items.Max(i => i.Id) + 1 : 1;
            Items.Add(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        // PUT: /Item/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, Item updatedItem)
        {
            var item = Items.FirstOrDefault(i => i.Id == id);
            if (item == null)
                return NotFound();

            item.Name = updatedItem.Name;
            item.Price = updatedItem.Price;
            return NoContent();
        }

        // DELETE: /Item/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = Items.FirstOrDefault(i => i.Id == id);
            if (item == null)
                return NotFound();

            Items.Remove(item);
            return NoContent();
        }
    }

    // Simple item model
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
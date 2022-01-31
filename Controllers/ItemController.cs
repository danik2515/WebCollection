using Microsoft.AspNetCore.Mvc;
using WebCollection.Models;
using WebCollection.Models.Interface;
using WebCollection.Models.ViewModels;
namespace WebCollection.Controllers {

    public class ItemController : Controller {
        private readonly ICollection _collection;
        private readonly IItem _item;

        public ItemController(ICollection collection, IItem item) {
            _collection = collection;

            _item = item;
        }
        public IActionResult Index() {
            return View();
        }
        public IActionResult Create(int id) {
            return View("Edit", new ItemEditViewModel { IItem = _item, CollectionId = id ,CollectionUserId=_collection.GetCollection(id).UserId});
        }
        public IActionResult Edit(int id, int itemId) {
            return View("Edit", new ItemEditViewModel { IItem = _item, CollectionId = id, CollectionUserId = _collection.GetCollection(id).UserId,Id= itemId });
        }
        
        public IActionResult GetCollection(int id) {
            return View("Index", new ItemIndexViewModel {IItem=_item, Collection= _collection.GetCollection(id) });
        }
        public IActionResult GetItem(int id,int collectionId) {
            return View("Item", new ItemIndexViewModel { IItem = _item,ItemId=id, Collection = _collection.GetCollection(collectionId) });
        }

        public IActionResult Delete(int itemId,int collectionId) {
            _item.DeleteItem(itemId);
            return RedirectToAction("GetCollection", "Item", new { id = collectionId });
        }
        [HttpPost]
        public ActionResult Save(ItemEditViewModel itemView) {
            Item item = new Item { Name = itemView.Name,Tag=itemView.Tag,CollectionId=itemView.CollectionId,Comment="",DateTime=DateTime.Now,Id=itemView.Id};
            _item.SaveItem(item, itemView.Values, itemView.CollectionId);
            return RedirectToAction("GetCollection", "Item", new { id = itemView.CollectionId });
        }
    }
}

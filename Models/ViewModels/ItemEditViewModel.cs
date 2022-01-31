using System.ComponentModel.DataAnnotations;
using WebCollection.Models.Interface;
namespace WebCollection.Models.ViewModels {
    public class ItemEditViewModel {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Tag { get; set; }
        public List<string> Values { get; set; }
        public List<int> TypeId { get; set; }
        public IItem IItem { get; set; }
        public int CollectionId { get; set; }
        public string UserId { get; set; }
        public string CollectionUserId { get; set; }
    }
}

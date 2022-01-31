
using WebCollection.Models;
using WebCollection.Models.Interface;
namespace WebCollection.Models.ViewModels {
    public class ItemIndexViewModel {
        public IItem IItem { get; set; }
        public Collection Collection { get; set; }
    }
}

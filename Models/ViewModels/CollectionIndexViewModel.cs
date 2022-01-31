using WebCollection.Models.Interface;

namespace WebCollection.Models.ViewModels {
    public class CollectionIndexViewModel {
        public ITheme ITheme { get; set; }
        public IEnumerable<Collection> Collections { get; set; }
    }
}


using System.ComponentModel.DataAnnotations;
using WebCollection.Models.Interface;
namespace WebCollection.Models.ViewModels {
    public class CollcetionCreateViewModel {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public int ThemeId { get; set; }
        public IFormFile IFormFile { get; set; }
        public ITheme ITheme { get; set; }
        public IItem IItem { get; set; }
        [Required]
        public List<string> NameFields { get; set; }
        public List<string> TypeFields { get; set; }

    }
}

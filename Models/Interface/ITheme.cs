using WebCollection.Models;
namespace WebCollection.Models.Interface {
    public interface ITheme {
        IEnumerable<Theme> Themes { get; }
        Theme GetTheme(int themeId);
    }
}

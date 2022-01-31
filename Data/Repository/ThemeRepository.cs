using WebCollection.Models;
using WebCollection.Models.Interface;
namespace WebCollection.Data.Repository {
    public class ThemeRepository :ITheme {
        private readonly ApplicationDbContext context;



        public ThemeRepository(ApplicationDbContext applicationDbContext) {
            context = applicationDbContext;
        }

        public IEnumerable<Theme> Themes => context.Themes;
        public Theme GetTheme(int themeId) => context.Themes.FirstOrDefault(x => x.Id == themeId);

    }
}

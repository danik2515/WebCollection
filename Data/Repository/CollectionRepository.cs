using Microsoft.EntityFrameworkCore;
using WebCollection.Models;
using WebCollection.Models.Interface;
namespace WebCollection.Data.Repository {
    public class CollectionRepository : ICollection {
        private readonly ApplicationDbContext context;

        

        public CollectionRepository(ApplicationDbContext applicationDbContext) {
            context = applicationDbContext;
        }
        public IEnumerable<Collection> Collections => context.Collections;

        public void SaveCollection(Collection collection) {
            context.Collections.Add(collection);
            context.SaveChanges();
        }
        public Collection GetCollection(int CollectionId) => context.Collections.FirstOrDefault(x => x.Id == CollectionId);
        public int GetCollectionId(string name) => context.Collections.OrderByDescending(x => x.Id).FirstOrDefault(x=>x.Name==name).Id;
       
    }
}

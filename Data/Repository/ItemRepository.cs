using WebCollection.Models;
using WebCollection.Models.Interface;
namespace WebCollection.Data.Repository {
    public class ItemRepository : IItem {
        private readonly ApplicationDbContext context;

        public ItemRepository(ApplicationDbContext applicationDbContext) {
            context = applicationDbContext;
        }
        public IEnumerable<Item> Items => context.Items;
        public IEnumerable<Field> Fields => context.Fields;
        public IEnumerable<FieldType> FieldTypes => context.FieldTypes;
        public IEnumerable<CollectionField> CollectionFields => context.CollectionFields;
        public int GetTypeId(string name) => context.FieldTypes.FirstOrDefault(x => x.Name == name).Id;
        public string GetType(int id) => context.FieldTypes.FirstOrDefault(x => x.Id == id).Name;
        public void SaveField(CollectionField collectionField) {
            context.CollectionFields.Add(collectionField);
            context.SaveChanges();
        }
        public int GetItemId(string name) => context.Items.OrderByDescending(x => x.Id).FirstOrDefault(x => x.Name == name).Id;
        public IEnumerable<CollectionField> GetCollectionFields(int collectionId) => context.CollectionFields.Where(x => x.CollectionId == collectionId);
        public IEnumerable<Item> GetItems(int collectionId) => context.Items.Where(x => x.CollectionId == collectionId);
        public void SaveItem(Item item,List<string> values,int collectionId) {
            context.Items.Add(item);
            context.SaveChanges();
            int itemId=GetItemId(item.Name);
            List<CollectionField> collectionFields = GetCollectionFields(collectionId).ToList();
            for (int i = 0; i < values.Count; i++) {
                if (values[i] == null) { values[i] = ""; }
                context.Fields.Add(new Field {Value=values[i],ItemId=itemId,CollectionFieldId=collectionFields[i].Id });
            }
            context.SaveChanges();
        }
        public string GetValueField(int collectionId, int itemId) => context.Fields.FirstOrDefault(x=>x.ItemId == itemId && x.CollectionFieldId==collectionId).Value;
        
        }
    }


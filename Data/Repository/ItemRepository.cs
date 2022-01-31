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
        public Item GetItem(int Id) => context.Items.FirstOrDefault(x => x.Id == Id);
        public void DeleteItem(int itemId) {
            var Fields = context.Fields.Where(x => x.ItemId == itemId).ToList();
            foreach(var field in Fields) {
                context.Fields.Remove(field);
            }
            context.Items.Remove(GetItem(itemId));
            context.SaveChanges();
        }
        public void SaveItem(Item item,List<string> values,int collectionId) {
            var itemDb = context.Items.Find(item.Id);
            if (itemDb == null) {
                context.Items.Add(item);
                context.SaveChanges();
                int itemId = GetItemId(item.Name);
                List<CollectionField> collectionFields = GetCollectionFields(collectionId).ToList();
                if (values != null) {
                    for (int i = 0; i < values.Count; i++) {
                        if (values[i] == null) { values[i] = ""; }
                        context.Fields.Add(new Field { Value = values[i], ItemId = itemId, CollectionFieldId = collectionFields[i].Id });
                    }
                }
            }
            else {
                itemDb.Name = item.Name;
                itemDb.Tag = item.Tag;
                var Fields = context.Fields.Where(x => x.ItemId == itemDb.Id).ToList();
                if (values != null) {
                    for (int i = 0; i < values.Count; i++) {
                        if (values[i] == null) { values[i] = ""; }
                        Fields[i].Value = values[i];
                    }
                }
            }
            context.SaveChanges();
        }
        public string GetValueField(int collectionId, int itemId) => context.Fields.FirstOrDefault(x=>x.ItemId == itemId && x.CollectionFieldId==collectionId).Value;
        
        }
    }


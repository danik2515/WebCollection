namespace WebCollection.Models.Interface {
    public interface IItem {
        IEnumerable<Item> Items { get; }
        IEnumerable<Field> Fields { get; }
        IEnumerable<FieldType> FieldTypes { get; }
        IEnumerable<CollectionField> CollectionFields { get; }
        IEnumerable<CollectionField> GetCollectionFields(int collectionId);
        IEnumerable<Item> GetItems(int collectionId);
        int GetTypeId(string name);
        void SaveField(CollectionField collectionField);
        void SaveItem(Item item,List<string> values, int collectionId);
        string GetType(int id);
        int GetItemId(string name);
        string GetValueField(int collectionId, int itemId);
    }
}

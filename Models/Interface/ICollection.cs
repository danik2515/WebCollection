namespace WebCollection.Models.Interface {
    public interface ICollection {
        IEnumerable<Collection> Collections { get; }
        void SaveCollection (Collection collection);
        Collection GetCollection(int CollectionId);
        int GetCollectionId(string name);
    }
}

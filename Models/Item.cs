namespace WebCollection.Models {
    public class Item {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public string Comment { get; set; }
        public int CollectionId { get; set; }
        public DateTime DateTime { get; set; }
        public int Likes { get; set; }
    }
}

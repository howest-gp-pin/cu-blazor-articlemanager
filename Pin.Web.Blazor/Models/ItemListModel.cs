namespace Pin.Web.Blazor.Models
{
    public class ItemListModel<T>
    {
        public string Title { get; set; }
        public string ItemName { get; set; }
        public string[] Headers { get; set; }
        public T[] Items { get; set; }
    }
}

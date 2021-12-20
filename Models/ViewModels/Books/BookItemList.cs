
namespace APIConsumer.Models.ViewModels.Books
{
    public class BookItemList
    {
        public decimal BookId { get; set; }

        public string Title { get; set; }

        public decimal PublicationYear { get; set; }

        public string Gender { get; set; }

        public decimal NumberPages { get; set; }
       
        public decimal AuthorId { get; set; }

        public string AuthorName { get; set; }
    }
}

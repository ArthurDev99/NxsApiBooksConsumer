using System.Collections.Generic;
using APIConsumer.Models.ViewModels.Authors;
namespace APIConsumer.Models.ViewModels.Authors.ListResponseAuthor
{
    public class ListResponseAuthor
    {
        public int code { get; set; }
        public string message { get; set; }
        public List<AuthorVM> data { get; set; }
    }
}

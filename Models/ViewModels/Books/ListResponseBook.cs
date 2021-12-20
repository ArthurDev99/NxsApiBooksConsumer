using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIConsumer.Models.ViewModels.Books
{
    public class ListResponseBook
    {
        public int code { get; set; }
        public string message { get; set; }
        public List<BookItemList> data { get; set; }
    }
}
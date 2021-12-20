using APIConsumer.Models.ViewModels.Authors;
using APIConsumer.Models.ViewModels.Authors.ListResponseAuthor;
using APIConsumer.Models.ViewModels.Books;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace APIConsumer.Data
{
    public class IntakerAPI
    {
        public const string baseUrl = "https://localhost:44360";
        public static string sendRequest(string url, string method, string data = "") 
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            request.ContentType = "Application/json";
            request.Accept = "Application/json";

            if (method.Equals("post")) {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(data);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return "";
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            return responseBody;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                return "";
            }

        }

        #region Books
        public static ListResponseBook getBooksList(string author = "", string title = "", int year = 0)
        {
            string url = baseUrl + "/api/Books/GetFilterBooks?" + $"author={author}&title={title}&year={year}";
            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<ListResponseBook>(sendRequest(url , "GET"));
            return response;
        }
        public static SampleResponseBook createNewBook(BookVM new_book)
        {
            string url = baseUrl + "/api/Books/InsertNewBook";
            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<SampleResponseBook>(sendRequest(url, "post", Newtonsoft.Json.JsonConvert.SerializeObject(new_book)));
            return response;
        }
        #endregion

        #region Authors
        public static ListResponseAuthor getAuthorsList(string author = "", string title = "", int year = 0)
        {
            string url = baseUrl + "/api/Authors/GetAllAuthors";
            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<ListResponseAuthor>(sendRequest(url, "GET"));
            return response;
        }
        public static SampleResponseAuthor createNewAuthor(AuthorVM new_author)
        {
            string url = baseUrl + "/api/Authors/InsertNewAuthor";
            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<SampleResponseAuthor>(sendRequest(url, "post", Newtonsoft.Json.JsonConvert.SerializeObject(new_author)));
            return response;
        }
        #endregion
    }
}
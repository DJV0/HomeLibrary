using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.Shared.Dto
{
    public class OpenLibraryBookDto
    {
        [JsonProperty("ISBN:{ }")]
        public ISBN Book { get; set; }

        public class Publisher
        {
            public string name { get; set; }
        }

        public class Identifiers
        {
            public List<string> isbn_13 { get; set; }
            public List<string> isbn_10 { get; set; }
        }

        public class Cover
        {
            public string small { get; set; }
            public string large { get; set; }
            public string medium { get; set; }
        }

        public class Subject
        {
            public string url { get; set; }
            public string name { get; set; }
        }

        public class Author
        {
            public string url { get; set; }
            public string name { get; set; }
        }

        public class ISBN
        {
            public List<Publisher> publishers { get; set; }
            public Identifiers identifiers { get; set; }
            public string title { get; set; }
            public string url { get; set; }
            public int number_of_pages { get; set; }
            public Cover cover { get; set; }
            public List<Subject> subjects { get; set; }
            public string publish_date { get; set; }
            public List<Author> authors { get; set; }
        }
    }
}

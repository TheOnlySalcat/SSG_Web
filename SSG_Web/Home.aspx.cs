using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using RestSharp;

namespace SSG_Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //Settings which may be re-used
        public string apiBaseUrl = "https://the-one-api.dev/v2";
        private string apiToken = "x4IHDwrEg5b11yXtRQxj";

        protected void Page_Load(object sender, EventArgs e)
        {
            //Could do something with URL params here if integrated to another system
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            #region GetBooks
            //Call API using CONTAINS operator (generally most user friendly)
            var client = new RestClient($"{apiBaseUrl}/book?name=/{txtBookName.Text}/i");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {apiToken}");
            IRestResponse response = client.Execute(request);

            books booksList = JsonConvert.DeserializeObject<books>(response.Content);

            //Put results into listbox
            lbBooksResult.Items.Clear();

            foreach (book b in booksList.docs)
            {
                ListItem item = new ListItem();
                item.Text = b.name;
                item.Value = b._id;
                lbBooksResult.Items.Add(item);
            }
            #endregion

            #region GetMovies
            //Call API using CONTAINS operator (generally most user friendly)
            var client2 = new RestClient($"{apiBaseUrl}/movie?name=/{txtBookName.Text}/i");
            client2.Timeout = -1;
            var request2 = new RestRequest(Method.GET);
            request2.AddHeader("Authorization", $"Bearer {apiToken}");
            IRestResponse response2 = client2.Execute(request2);

            movies moviesList = JsonConvert.DeserializeObject<movies>(response2.Content);

            //Put results into listbox
            lbMoviesResult.Items.Clear();

            foreach (movie m in moviesList.docs)
            {
                ListItem item = new ListItem();
                item.Text = m.name;
                item.Value = m._id;
                lbMoviesResult.Items.Add(item);
            }
            #endregion
        }

        protected void lbBooksResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbBooksResult.SelectedItem != null)
            {
                //Call API - Get chapters for book
                var client = new RestClient($"{apiBaseUrl}/chapter?book={lbBooksResult.SelectedValue}");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", $"Bearer {apiToken}");
                IRestResponse response = client.Execute(request);

                chapters chaptersList = JsonConvert.DeserializeObject<chapters>(response.Content);

                //Put results into listbox
                lbChaptersResult.Items.Clear();

                foreach (chapter c in chaptersList.docs)
                {
                    ListItem item = new ListItem();
                    item.Text = c.chapterName;
                    item.Value = c._id;
                    lbChaptersResult.Items.Add(item);
                }
            }
        }

        protected void lbMoviesResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbMoviesResult.SelectedItem != null)
            {
                //Call API - Get quotes for Movie
                var client2 = new RestClient($"{apiBaseUrl}/quote?movie={lbMoviesResult.SelectedValue}");
                client2.Timeout = -1;
                var request2 = new RestRequest(Method.GET);
                request2.AddHeader("Authorization", $"Bearer {apiToken}");
                IRestResponse response2 = client2.Execute(request2);

                quotes quotesList = JsonConvert.DeserializeObject<quotes>(response2.Content);

                //Put results into listbox
                lbQuotesResult.Items.Clear();
                txtCharactersResult.Text = "";

                foreach (quote q in quotesList.docs)
                {
                    ListItem item = new ListItem();
                    item.Text = q.dialog;
                    item.Value = $"{q._id}|{q.character}";
                    lbQuotesResult.Items.Add(item);
                }
            }
        }

        protected void lbQuotesResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbQuotesResult.SelectedItem != null)
            {
                //Call API - Get character of quote
                var client = new RestClient($"{apiBaseUrl}/character?_id={lbQuotesResult.SelectedValue.Split('|')[1]}");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", $"Bearer {apiToken}");
                IRestResponse response = client.Execute(request);

                characters charactersList = JsonConvert.DeserializeObject<characters>(response.Content);

                //Put results into textbox
                txtCharactersResult.Text = "";

                txtCharactersResult.Text = charactersList.docs[0].name;
            }
        }

        protected void lbCharactersResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            //no action
        }

        protected void btnCacheCharacters_Click(object sender, EventArgs e)
        {
            //Call API - Get character by name
            var client = new RestClient($"{apiBaseUrl}/character?name=/{txtSearchCharacter.Text}/i");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {apiToken}");
            IRestResponse response = client.Execute(request);

            characters charactersList = JsonConvert.DeserializeObject<characters>(response.Content);

            //Put results into listbox
            lbCachedCharacters.Items.Clear();

            foreach (character c in charactersList.docs)
            {
                ListItem item = new ListItem();
                item.Value = c._id;
                item.Text = c.name;
                lbCachedCharacters.Items.Add(item);
            }
        }

        protected void lbCachedCharacters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbCachedCharacters.SelectedItem != null)
            {
                //Call API - Get quotes for Character
                var client2 = new RestClient($"{apiBaseUrl}/quote?character={lbCachedCharacters.SelectedValue}");
                client2.Timeout = -1;
                var request2 = new RestRequest(Method.GET);
                request2.AddHeader("Authorization", $"Bearer {apiToken}");
                IRestResponse response2 = client2.Execute(request2);

                quotes quotesList = JsonConvert.DeserializeObject<quotes>(response2.Content);

                //Put results into listbox
                lbQuotesResult.Items.Clear();
                txtCharactersResult.Text = lbCachedCharacters.SelectedItem.Text;

                foreach (quote q in quotesList.docs)
                {
                    ListItem item = new ListItem();
                    item.Text = q.dialog;
                    item.Value = $"{q._id}|{q.character}";
                    lbQuotesResult.Items.Add(item);
                }
            }
        }

        #region ObjectDefinitions

        public class book
        {
            public string _id { get; set; }
            public string name { get; set; }
        }

        public class books
        {
            public List<book> docs { get; set; }
            public int total { get; set; }
            public int limit { get; set; }
            public int offset { get; set; }
            public int page { get; set; }
            public int pages { get; set; }
        }

        public class chapter
        {
            public string _id { get; set; }
            public string chapterName { get; set; }
            public string book { get; set; }
        }

        public class chapters
        {
            public List<chapter> docs { get; set; }
            public int total { get; set; }
            public int limit { get; set; }
            public int offset { get; set; }
            public int page { get; set; }
            public int pages { get; set; }
        }

        public class character
        {
            public string _id { get; set; }
            public string height { get; set; }
            public string race { get; set; }
            public string gender { get; set; }
            public string birth { get; set; }
            public string spouse { get; set; }
            public string death { get; set; }
            public string realm { get; set; }
            public string hair { get; set; }
            public string name { get; set; }
            public string wikiUrl { get; set; }
        }

        public class characters
        {
            public List<character> docs { get; set; }
            public int total { get; set; }
            public int limit { get; set; }
            public int offset { get; set; }
            public int page { get; set; }
            public int pages { get; set; }
        }

        public class movie
        {
            public string _id { get; set; }
            public string name { get; set; }
            public int runtimeInMinutes { get; set; }
            public int budgetInMillions { get; set; }
            public double boxOfficeRevenueInMillions { get; set; }
            public int academyAwardNominations { get; set; }
            public int academyAwardWins { get; set; }
            public double rottenTomatesScore { get; set; }
        }

        public class movies
        {
            public List<movie> docs { get; set; }
            public int total { get; set; }
            public int limit { get; set; }
            public int offset { get; set; }
            public int page { get; set; }
            public int pages { get; set; }
        }

        public class quote
        {
            public string _id { get; set; }
            public string dialog { get; set; }
            public string movie { get; set; }
            public string character { get; set; }
        }

        public class quotes
        {
            public List<quote> docs { get; set; }
            public int total { get; set; }
            public int limit { get; set; }
            public int offset { get; set; }
            public int page { get; set; }
            public int pages { get; set; }
        }


        #endregion

    }
}
using MongoDB.Driver;
using SnippetStore.MongoClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetStore.ConvertClass
{
    public class ConversionManagement
    {
       
        private IMongoDatabase _database;
        private string dbName = "SnippetStore";
        private static string _MongoConString = "mongodb+srv://snippetstore:hLMpRxnk1hzcwHxa@snippetstorecluster.ezjte.mongodb.net/?retryWrites=true&w=majority&appName=SnippetStoreCluster";
        
        public void ConvertRftToPlain()
        {
            var client = new MongoClient(_MongoConString);
            _database = client.GetDatabase(dbName);
            var snippets = _database.GetCollection<SnippetDatabase>("SnippetStore");
            var snippets_list =  snippets.Find(Builders<SnippetDatabase>.Filter.Empty).ToList();

            foreach (var snippet in snippets_list)
            {
                var Richtext = snippet.SnipCode;
                if (Richtext != null || Richtext != ""){
                    var Plain = ConvertRichTextToPlain(Richtext);
                    snippet.SnipCode = Plain;
                }
            }
            snippets.DeleteMany(Builders<SnippetDatabase>.Filter.Empty);
            snippets.InsertMany(snippets_list);

        }

        private static string ConvertRichTextToPlain(string rtfText)
        {
            if (string.IsNullOrEmpty(rtfText)) { return null; }
            using (var rtb = new RichTextBox())
            {
                rtb.Rtf = rtfText;
                return rtb.Text;
            }
        }
    }
}

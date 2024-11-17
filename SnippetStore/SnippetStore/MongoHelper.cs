using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SnippetStore
{
    public class MongoHelper
    {
        private IMongoDatabase _database;
        private string _MongoConString = "mongodb://localhost:27017";
        private string dbName = "SnippetStore";
        public MongoHelper()
        {
            var client = new MongoClient(_MongoConString);
            _database = client.GetDatabase(dbName);
        }

        public List<string> GetLanguages()
        {
            var collection = _database.GetCollection<Languages>("Languages");
            var languages = collection.Find(new BsonDocument()).ToList();
            return languages.Select(x => x.Language).ToList();
        }

        public void AddLanguages(string lang)
        { 
            var languages = _database.GetCollection<Languages>("Languages");
            var language = new Languages { Language = lang };
            languages.InsertOne(language);
        }

        public void DeleteLanguage(string langName)
        {
            var languages = _database.GetCollection<Languages>("Languages");
            var filter = Builders<Languages>.Filter.Eq(x => x.Language, langName);
            languages.DeleteOne(filter);
        }

        public void AddSnippet(SnippetDatabase snippet)
        {
            var snippets = _database.GetCollection<SnippetDatabase>("SnippetStore");
            snippets.InsertOne(snippet);
        }
    }
}

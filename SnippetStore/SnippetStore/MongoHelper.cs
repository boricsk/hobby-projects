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

        public List<string?> GetLanguages()
        {
            var collection = _database.GetCollection<Languages>("Languages");
            var languages = collection.Find(new BsonDocument()).ToList();
            return languages.Select(x => x.Language).ToList();
        }

        public List<string?> GetKeywords()
        {
            var collection = _database.GetCollection<Keywords>("Keywords");
            var keywords = collection.Find(new BsonDocument()).ToList();
            return keywords.Select(x => x.Keyword).ToList();
        }

        public void AddLanguages(string lang)
        { 
            var languages = _database.GetCollection<Languages>("Languages");
            var language = new Languages { Language = lang };
            languages.InsertOne(language);
        }

        public void AddKeyword(string keyw)
        {
            var keywords = _database.GetCollection<Keywords>("Keywords");
            var keyword = new Keywords { Keyword = keyw };
            keywords.InsertOne(keyword);
        }

        public void DeleteKeyw(string keyw)
        {
            var keywords = _database.GetCollection<Keywords>("Keywords");
            var filter = Builders<Keywords>.Filter.Eq(x => x.Keyword, keyw);
            keywords.DeleteOne(filter);
        }

        public void DeleteLanguage(string langName)
        {
            var languages = _database.GetCollection<Languages>("Languages");
            var filter = Builders<Languages>.Filter.Eq(x => x.Language, langName);
            languages.DeleteOne(filter);
        }

        public string? GetMongoIdFromSnipetName(string snipName)
        {
            var snippets = _database.GetCollection<SnippetDatabase>("SnippetStore");
            var filter = Builders<SnippetDatabase>.Filter.Eq(x => x.SnipName, snipName);
            var result = snippets.Find(filter).FirstOrDefault();
            return result?.Id;
        }

        public void AddSnippet(SnippetDatabase snippet)
        {
            var snippets = _database.GetCollection<SnippetDatabase>("SnippetStore");
            snippets.InsertOne(snippet);
        }

        public IMongoCollection<SnippetDatabase> GetSnipets()
        {
            var snippets = _database.GetCollection<SnippetDatabase>("SnippetStore");
            return snippets;
        }

        public string? GetCodeSnipetById(string id)
        {
            var snippets = _database.GetCollection<SnippetDatabase>("SnippetStore");
            var filter = Builders<SnippetDatabase>.Filter.Eq(x => x.Id, id);
            var result = snippets.Find(filter).FirstOrDefault();
            return result?.SnipCode;
        }
    }
}

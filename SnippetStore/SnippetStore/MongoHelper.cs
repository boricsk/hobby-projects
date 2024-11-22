using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SnippetStore
{
    sealed public class MongoHelper
    {
        private IMongoDatabase? _database;
        private string _MongoConString = string.Empty;
        private string dbName = "SnippetStore";

        private IMongoCollection<SnippetDatabase> coll_snippets;
        private IMongoCollection<Languages> coll_languages;
        private IMongoCollection<Keywords> coll_keywords;
        private IMongoCollection<ResWords> coll_reswords;
        private IMongoCollection<BlockSeparators> coll_blockseps;

        public MongoHelper()
        {
            if (RegistryOps.ReadConString() == "")
            {
                RegistryOps.WriteConString("mongodb://localhost:27017");
            }
            else
            {
                _MongoConString = RegistryOps.ReadConString();
            }

            try
            {
                var client = new MongoClient(_MongoConString);
                _database = client.GetDatabase(dbName);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Connection Error: {e.Message}");

            }

            coll_snippets = _database.GetCollection<SnippetDatabase>("SnippetStore");
            coll_languages = _database.GetCollection<Languages>("Languages");
            coll_keywords = _database.GetCollection<Keywords>("Keywords");
            coll_reswords = _database.GetCollection<ResWords>("Reserved words");
            coll_blockseps = _database.GetCollection<BlockSeparators>("Block separators");
        }

        public List<string?> GetLanguages()
        {
            var languages = coll_languages.Find(new BsonDocument()).ToList();
            return languages.Select(x => x.Language).ToList();
        }

        public void AddLanguages(string lang)
        {
            var language = new Languages { Language = lang };
            coll_languages.InsertOne(language);
        }
        public void DeleteLanguage(string langName)
        {
            var filter = Builders<Languages>.Filter.Eq(x => x.Language, langName);
            coll_languages.DeleteOne(filter);
        }

        public void AddKeyword(string keyw)
        {
            var keyword = new Keywords { Keyword = keyw };
            coll_keywords.InsertOne(keyword);
        }

        public void DeleteKeyw(string keyw)
        {
            var filter = Builders<Keywords>.Filter.Eq(x => x.Keyword, keyw);
            coll_keywords.DeleteOne(filter);
        }
        public List<string?> GetKeywords()
        {
            var keywords = coll_keywords.Find(new BsonDocument()).ToList();
            return keywords.Select(x => x.Keyword).ToList();
        }

        public void AddReservedWord(string resw)
        {
            var resword = new ResWords { ResWord = resw };
            coll_reswords.InsertOne(resword);
        }

        public void DeleteResw(string resw)
        {
            var filter = Builders<ResWords>.Filter.Eq(x => x.ResWord, resw);
            coll_reswords.DeleteOne(filter);
        }
        public List<string?> GetReswords()
        {
            var reswords = coll_reswords.Find(new BsonDocument()).ToList();
            return reswords.Select(x => x.ResWord).ToList();
        }

        public void AddBlockSep(string blocks)
        {            
            var blocksep = new BlockSeparators { BlockSep = blocks };
            coll_blockseps.InsertOne(blocksep);
        }

        public void DeleteBlockSep(string blocks)
        {
            var filter = Builders<BlockSeparators>.Filter.Eq(x => x.BlockSep, blocks);
            coll_blockseps.DeleteOne(filter);
        }
        public List<string?> GetBlockSep()
        {
            var blockseps = coll_blockseps.Find(new BsonDocument()).ToList();
            return blockseps.Select(x => x.BlockSep).ToList();
        }

        public string? GetMongoIdFromSnipetName(string snipName)
        {
            var filter = Builders<SnippetDatabase>.Filter.Eq(x => x.SnipName, snipName);
            var result = coll_snippets.Find(filter).FirstOrDefault();
            return result?.Id;
        }

        public void AddSnippet(SnippetDatabase snippet)
        {
            coll_snippets.InsertOne(snippet);
        }

        public IMongoCollection<SnippetDatabase> GetSnipets()
        {
            return coll_snippets;
        }

        public string? GetCodeSnipetById(string id)
        {
            var filter = Builders<SnippetDatabase>.Filter.Eq(x => x.Id, id);
            var result = coll_snippets.Find(filter).FirstOrDefault();
            return result?.SnipCode;
        }

        public void DropDataById(string id)
        {
            coll_snippets.DeleteOne(Builders<SnippetDatabase>.Filter.Eq(x => x.Id, id));
        }

        public void IncreaseView(string id)
        {
            //var snippets = _database.GetCollection<SnippetDatabase>("SnippetStore");
            coll_snippets.UpdateOne(Builders<SnippetDatabase>.Filter.Eq(x => x.Id, id), Builders<SnippetDatabase>.Update.Inc(x => x.NoOfView, 1));

        }

        public void SaveModify(string id, string newData)
        { 
            coll_snippets.UpdateOne(Builders<SnippetDatabase>.Filter.Eq(x => x.Id, id), Builders<SnippetDatabase>.Update.Set(x => x.SnipCode, newData));
        }
    }
}

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
        private string _MongoConString;
        private string dbName = "SnippetStore";
        
        public MongoHelper()
        {          
            _MongoConString = "mongodb://localhost:27017";
            var client = new MongoClient(_MongoConString);
            _database = client.GetDatabase(dbName);
        }

        public List<string?> GetLanguages()
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
        public List<string?> GetKeywords()
        {
            var collection = _database.GetCollection<Keywords>("Keywords");
            var keywords = collection.Find(new BsonDocument()).ToList();
            return keywords.Select(x => x.Keyword).ToList();
        }
        
        public void AddReservedWord(string resw)
        {
            var reswords = _database.GetCollection<ResWords>("Reserved words");
            var resword = new ResWords { ResWord = resw };
            reswords.InsertOne(resword);
        }

        public void DeleteResw(string resw)
        {
            var reswords = _database.GetCollection<ResWords>("Reserved words");
            var filter = Builders<ResWords>.Filter.Eq(x => x.ResWord, resw);
            reswords.DeleteOne(filter);
        }
        public List<string?> GetReswords()
        {
            var collection = _database.GetCollection<ResWords>("Reserved words");
            var reswords = collection.Find(new BsonDocument()).ToList();
            return reswords.Select(x => x.ResWord).ToList();
        }

        public void AddBlockSep(string blocks)
        {
            var blockseps = _database.GetCollection<BlockSeparators>("Block separators");
            var blocksep = new BlockSeparators { BlockSep = blocks };
            blockseps.InsertOne(blocksep);
        }

        public void DeleteBlockSep(string blocks)
        {
            var blockseps = _database.GetCollection<BlockSeparators>("Block separators");
            var filter = Builders<BlockSeparators>.Filter.Eq(x => x.BlockSep, blocks);
            blockseps.DeleteOne(filter);
        }
        public List<string?> GetBlockSep()
        {
            var collection = _database.GetCollection<BlockSeparators>("Block separators");
            var blockseps = collection.Find(new BsonDocument()).ToList();
            return blockseps.Select(x => x.BlockSep).ToList();
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

        public void DropDataById(string id)
        {
            var snippets = _database.GetCollection<SnippetDatabase>("SnippetStore");
            snippets.DeleteOne(Builders<SnippetDatabase>.Filter.Eq(x => x.Id, id));
        }

        public void SaveSetup(SetupData setupData)
        {
            var setup = _database.GetCollection<SetupData>("Setup");
            var firstSetupData = setup.Find(new BsonDocument()).FirstOrDefault();
            //firstSetupData.InsertOne(setupData);      
        }

        public SetupData GetSetup()
        {
            var setup = _database.GetCollection<SetupData>("Setup");
            var result = setup.Find(new BsonDocument()).FirstOrDefault();
            return result;
        }
    }
}

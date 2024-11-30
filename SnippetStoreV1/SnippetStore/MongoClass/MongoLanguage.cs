using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetStore.MongoClass
{
    public class MongoLanguage
    {
        private readonly IMongoCollection<Languages> _languageCollection;
        public MongoLanguage(IMongoCollection<Languages> languageCollection)
        {
            _languageCollection = languageCollection;
        }

        public async Task<List<string?>> GetLanguagesAsync()
        {
            var languages = await _languageCollection.Find(new BsonDocument()).ToListAsync();
            return languages.Select(x => x.Language).ToList();
        }

        public async Task AddLanguagesAsync(string lang)
        {
            var language = new Languages { Language = lang };
            await _languageCollection.InsertOneAsync(language);
        }

        public async Task DeleteLanguageAsync(string langName)
        {
            var filter = Builders<Languages>.Filter.Eq(x => x.Language, langName);
            await _languageCollection.DeleteOneAsync(filter);
        }
    }
}

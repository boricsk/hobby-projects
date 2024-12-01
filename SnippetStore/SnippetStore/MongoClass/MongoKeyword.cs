using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetStore.MongoClass
{
    public class MongoKeyword
    {
        private readonly IMongoCollection<Keywords> _keywordCollection;
        public MongoKeyword(IMongoCollection<Keywords> keywordCollection)
        {
            _keywordCollection = keywordCollection;
        }
        public async Task AddKeywordAsync(string keyw)
        {
            var keyword = new Keywords { Keyword = keyw };
            await _keywordCollection.InsertOneAsync(keyword);
        }

        public async Task DeleteKeywAsync(string keyw)
        {
            var filter = Builders<Keywords>.Filter.Eq(x => x.Keyword, keyw);
            await _keywordCollection.DeleteOneAsync(filter);
        }
        public async Task<List<string?>> GetKeywordsAsync()
        {
            var keywords = await _keywordCollection.Find(new BsonDocument()).ToListAsync();
            return keywords.Select(x => x.Keyword).ToList();
        }
    }
}

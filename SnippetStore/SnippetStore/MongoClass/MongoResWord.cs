using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetStore.MongoClass
{
    public class MongoResWord
    {
        private readonly IMongoCollection<ResWords> _resWordCollection;

        public MongoResWord(IMongoCollection<ResWords> resWordCollection)
        {
            _resWordCollection = resWordCollection;
            
        }

        public async Task AddReservedWordAsync(string resw)
        {
            var resword = new ResWords { ResWord = resw };
            await _resWordCollection.InsertOneAsync(resword);
        }

        public async Task DeleteReswAsync(string resw)
        {
            var filter = Builders<ResWords>.Filter.Eq(x => x.ResWord, resw);
            await _resWordCollection.DeleteOneAsync(filter);
        }
        public async Task<List<string?>> GetReswordsAsync()
        {
            var reswords = await _resWordCollection.Find(new BsonDocument()).ToListAsync();
            return reswords.Select(x => x.ResWord).ToList();
        }
    }
}

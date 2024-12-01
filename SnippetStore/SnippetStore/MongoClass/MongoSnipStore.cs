using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetStore.MongoClass
{
    public class MongoSnipStore
    {
        private readonly IMongoCollection<SnippetDatabase> _snipCollection;
        public MongoSnipStore(IMongoCollection<SnippetDatabase> snipCollection)
        {
            _snipCollection = snipCollection;
        }

        public async Task<string?> GetMongoIdFromSnipetNameAsync(string snipName)
        {
            var filter = Builders<SnippetDatabase>.Filter.Eq(x => x.SnipName, snipName);
            var result = await _snipCollection.Find(filter).FirstOrDefaultAsync();
            return result?.Id;
        }

        public async Task AddSnippetAsync(SnippetDatabase snippet)
        {
            await _snipCollection.InsertOneAsync(snippet);
        }

        public IMongoCollection<SnippetDatabase> GetSnipets()
        {
            return _snipCollection;
        }

        public async Task<string?> GetCodeSnipetByIdAsync(string Id)
        {
            var filter = Builders<SnippetDatabase>.Filter.Eq(x => x.Id, Id);
            var result = await _snipCollection.Find(filter).FirstOrDefaultAsync();
            return result?.SnipCode;
        }

        public async Task<string?> GetSnippetLanguageByIdAsync(string Id)
        {
            var filter = Builders<SnippetDatabase>.Filter.Eq(x => x.Id, Id);
            var result = await _snipCollection.Find(filter).FirstOrDefaultAsync();
            return result?.SnipLanguage;
        }

        public async Task<string?> GetCodeDescByIdAsync(string Id)
        {
            var filter = Builders<SnippetDatabase>.Filter.Eq(x => x.Id, Id);
            var result = await _snipCollection.Find(filter).FirstOrDefaultAsync();
            return result?.SnipShortDesc;
        }

        public async Task DropDataByIdAsync(string Id)
        {
            await _snipCollection.DeleteOneAsync(Builders<SnippetDatabase>.Filter.Eq(x => x.Id, Id));
        }

        public async Task IncreaseViewAsync(string Id)
        {
            await _snipCollection.UpdateOneAsync(Builders<SnippetDatabase>.Filter.Eq(x => x.Id, Id), Builders<SnippetDatabase>.Update.Inc(x => x.NoOfView, 1));
        }

        public async Task SaveModifyAsync(string Id, string newData)
        {
            await _snipCollection.UpdateOneAsync(Builders<SnippetDatabase>.Filter.Eq(x => x.Id, Id), Builders<SnippetDatabase>.Update.Set(x => x.SnipCode, newData));
        }

        public async Task<long> GetSnipNumByLanguageAsync(string language)
        {
            var filter = Builders<SnippetDatabase>.Filter.Eq(l => l.SnipLanguage, language);
            return await _snipCollection.Find(filter).CountDocumentsAsync();
        }

        public Dictionary<string, int> GetTop5Wiew()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            var topFive = _snipCollection.Find(Builders<SnippetDatabase>.Filter.Empty)
                .Sort(Builders<SnippetDatabase>.Sort.Descending(w => w.NoOfView))
                .Limit(5)
                .ToList();

            foreach (var t in topFive)
            {
                result.Add(t.SnipName, t.NoOfView);
            }

            return result;

        }

        public async Task<bool> isNameExistAsync(string Id, string Name)
        {
            string? Lang = await GetSnippetLanguageByIdAsync(Id);
            var SnipNum = GetSnipets().AsQueryable().ToList().Where(l => l.SnipLanguage == Lang && l.SnipName == Name).GroupBy(l => l.SnipName).Count();
            return SnipNum == 0;
        }

        //public async Task RenameNodeName(string newName, string Id)
        //{
        //    if (await isNameExistAsync(Id, newName))
        //    {
        //        _snipCollection.UpdateOne(Builders<SnippetDatabase>.Filter.Eq(x => x.Id, Id), Builders<SnippetDatabase>.Update.Set(x => x.SnipName, newName));
        //    }
        //}


    }
}

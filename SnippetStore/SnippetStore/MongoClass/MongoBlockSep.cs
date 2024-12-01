using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetStore.MongoClass
{
    public class MongoBlockSep
    {
        private readonly IMongoCollection<BlockSeparators> _blockSepCollection;

        public MongoBlockSep(IMongoCollection<BlockSeparators> blockSepCollection)
        {
            _blockSepCollection = blockSepCollection;            
        }

        public async Task AddBlockSepAync(string blocks)
        {
            var blocksep = new BlockSeparators { BlockSep = blocks };
            await _blockSepCollection.InsertOneAsync(blocksep);
        }

        public async Task DeleteBlockSepAsync(string blocks)
        {
            var filter = Builders<BlockSeparators>.Filter.Eq(x => x.BlockSep, blocks);
            await _blockSepCollection.DeleteOneAsync(filter);
        }
        public async Task<List<string?>> GetBlockSepAsync()
        {
            var blockseps = await _blockSepCollection.Find(new BsonDocument()).ToListAsync();
            return blockseps.Select(x => x.BlockSep).ToList();
        }
    }
}

using MongoDB.Driver;
using SnippetStore.RegistryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetStore.MongoClass
{
    public class MongoSyncManagement
    {
        public MongoSyncManagement() { }

        public async Task SyncCloudToLocalDatabaseAsync()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want synchronize cloud database to local one?", "Sync database", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var atlas = new MongoClient(RegistryOps.ReadConString());
                var local = new MongoClient(RegistryOps.ReadConStringLocal());
                var atlasDb = atlas.GetDatabase("SnippetStore");
                var localDb = local.GetDatabase("SnippetStore");

                var atlas_coll_snippets = atlasDb.GetCollection<SnippetDatabase>("SnippetStore");
                var atlas_coll_snippets_data = await atlas_coll_snippets.Find(Builders<SnippetDatabase>.Filter.Empty).ToListAsync();

                var atlas_coll_languages = atlasDb.GetCollection<Languages>("Languages");
                var atlas_coll_languages_data = await atlas_coll_languages.Find(Builders<Languages>.Filter.Empty).ToListAsync();

                var atlas_coll_keywords = atlasDb.GetCollection<Keywords>("Keywords");
                var atlas_coll_keywords_data = await atlas_coll_keywords.Find(Builders<Keywords>.Filter.Empty).ToListAsync();

                var atlas_coll_reswords = atlasDb.GetCollection<ResWords>("Reserved words");
                var atlas_coll_reswords_data = await atlas_coll_reswords.Find(Builders<ResWords>.Filter.Empty).ToListAsync();

                var atlas_coll_blockseps = atlasDb.GetCollection<BlockSeparators>("Block separators");
                var atlas_coll_blockseps_data = await atlas_coll_blockseps.Find(Builders<BlockSeparators>.Filter.Empty).ToListAsync();

                var local_coll_snippets = localDb.GetCollection<SnippetDatabase>("SnippetStore");
                local_coll_snippets.DeleteMany(Builders<SnippetDatabase>.Filter.Empty);
                await local_coll_snippets.InsertManyAsync(atlas_coll_snippets_data);

                var local_coll_languages = localDb.GetCollection<Languages>("Languages");
                local_coll_languages.DeleteMany(Builders<Languages>.Filter.Empty);
                await local_coll_languages.InsertManyAsync(atlas_coll_languages_data);

                var local_coll_keywords = localDb.GetCollection<Keywords>("Keywords");
                local_coll_keywords.DeleteMany(Builders<Keywords>.Filter.Empty);
                await local_coll_keywords.InsertManyAsync(atlas_coll_keywords_data);

                var local_coll_reswords = localDb.GetCollection<ResWords>("Reserved words");
                local_coll_reswords.DeleteMany(Builders<ResWords>.Filter.Empty);
                await local_coll_reswords.InsertManyAsync(atlas_coll_reswords_data);

                var local_coll_blockseps = localDb.GetCollection<BlockSeparators>("Block separators");
                local_coll_blockseps.DeleteMany(Builders<BlockSeparators>.Filter.Empty);
                await local_coll_blockseps.InsertManyAsync(atlas_coll_blockseps_data);
            }
        }
    }
}

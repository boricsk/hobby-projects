using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private string _MongoConStringLocal = string.Empty;
        private string dbName = "SnippetStore";

        public string ConnectedTo { get; private set; }
        public List<BsonValue> DbStats { get; private set; } = new List<BsonValue>();

        private IMongoCollection<SnippetDatabase> coll_snippets;
        private IMongoCollection<Languages> coll_languages;
        private IMongoCollection<Keywords> coll_keywords;
        private IMongoCollection<ResWords> coll_reswords;
        private IMongoCollection<BlockSeparators> coll_blockseps;

        public MongoHelper()
        {
            ConnectToDatabase();

        }

        public void ConnectToDatabase()
        {
            if (RegistryOps.ReadConString() == "")
            {
                RegistryOps.WriteConString("mongodb://localhost:27017");
            }
            else
            {
                _MongoConString = RegistryOps.ReadConString();
                _MongoConStringLocal = RegistryOps.ReadConStringLocal();
            }

            try
            {
                if (RegistryOps.ReadDatabaseOption())
                {
                    var client = new MongoClient(_MongoConStringLocal);
                    _database = client.GetDatabase(dbName);
                    ConnectedTo = "Local";
                }
                else
                {
                    var client = new MongoClient(_MongoConString);
                    _database = client.GetDatabase(dbName);
                    ConnectedTo = "Cloud";
                }

            }
            catch (Exception e)
            {
                MessageBox.Show($"Connection Error: {e.Message}");
            }

            try
            {
                coll_snippets = _database.GetCollection<SnippetDatabase>("SnippetStore");
                coll_languages = _database.GetCollection<Languages>("Languages");
                coll_keywords = _database.GetCollection<Keywords>("Keywords");
                coll_reswords = _database.GetCollection<ResWords>("Reserved words");
                coll_blockseps = _database.GetCollection<BlockSeparators>("Block separators");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Connection Error: {e.Message}");
            }
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

        public string? GetCodeSnipetById(string Id)
        {
            var filter = Builders<SnippetDatabase>.Filter.Eq(x => x.Id, Id);
            var result = coll_snippets.Find(filter).FirstOrDefault();
            return result?.SnipCode;
        }

        public string? GetSnippetLanguageById(string Id)
        {
            var filter = Builders<SnippetDatabase>.Filter.Eq(x => x.Id, Id);
            var result = coll_snippets.Find(filter).FirstOrDefault();
            return result?.SnipLanguage;
        }

        public string? GetCodeDescById(string Id)
        {
            var filter = Builders<SnippetDatabase>.Filter.Eq(x => x.Id, Id);
            var result = coll_snippets.Find(filter).FirstOrDefault();
            return result?.SnipShortDesc;
        }

        public void DropDataById(string Id)
        {
            coll_snippets.DeleteOne(Builders<SnippetDatabase>.Filter.Eq(x => x.Id, Id));
        }

        public void IncreaseView(string Id)
        {
            coll_snippets.UpdateOne(Builders<SnippetDatabase>.Filter.Eq(x => x.Id, Id), Builders<SnippetDatabase>.Update.Inc(x => x.NoOfView, 1));
        }

        public void SaveModify(string Id, string newData)
        {
            coll_snippets.UpdateOne(Builders<SnippetDatabase>.Filter.Eq(x => x.Id, Id), Builders<SnippetDatabase>.Update.Set(x => x.SnipCode, newData));
        }

        public long GetSnipNumByLanguage(string language)
        {
            var filter = Builders<SnippetDatabase>.Filter.Eq(l => l.SnipLanguage, language);
            return coll_snippets.Find(filter).CountDocuments();
        }

        public Dictionary<string, int> GetTop5Wiew()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            var topFive = coll_snippets.Find(Builders<SnippetDatabase>.Filter.Empty)
                .Sort(Builders<SnippetDatabase>.Sort.Descending(w => w.NoOfView))
                .Limit(5)
                .ToList();

            foreach (var t in topFive)
            {
                result.Add(t.SnipName, t.NoOfView);
            }

            return result;

        }

        public async Task SyncLocalDatabase()
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

        public bool isNameExist(string Id, string Name)
        {
            string? Lang = GetSnippetLanguageById(Id);
            var SnipNum = GetSnipets().AsQueryable().ToList().Where(l => l.SnipLanguage == Lang && l.SnipName == Name).GroupBy(l => l.SnipName).Count();
            return SnipNum == 0;
        }

        public void RenameNodeName(string newName, string Id)
        {
            if (isNameExist(Id, newName))
            {
                coll_snippets.UpdateOne(Builders<SnippetDatabase>.Filter.Eq(x => x.Id, Id), Builders<SnippetDatabase>.Update.Set(x => x.SnipName, newName));
            }
        }

        public List<BsonValue> DatabaseStat()
        {
            if (_database != null)
            {
                var command = new BsonDocument { { "dbstats", 1 } };
                var stats = _database.RunCommand<BsonDocument>(command);

                if (stats != null)
                {
                    Debug.WriteLine($"Adatbázis neve: {stats["db"]}");
                    DbStats.Add(stats["db"]);

                    Debug.WriteLine($"Összes gyűjtemény száma: {stats["collections"]}");
                    DbStats.Add(stats["collections"]);

                    Debug.WriteLine($"Adatbázis mérete (dataSize): {stats["dataSize"]} bájt");
                    DbStats.Add(stats["dataSize"]);

                    Debug.WriteLine($"Tárolási méret (storageSize): {stats["storageSize"]} bájt");
                    DbStats.Add(stats["storageSize"]);
                    
                    Debug.WriteLine($"Index mérete (indexSize): {stats["indexSize"]} bájt");
                    DbStats.Add(stats["indexSize"]);

                    // Az adatbázis teljes méretének kiszámítása (dataSize + indexSize)
                    long totalSize = stats["dataSize"].ToInt64() + stats["indexSize"].ToInt64();
                    Debug.WriteLine($"Teljes adatbázis méret (dataSize + indexSize): {totalSize} bájt");
                    DbStats.Add(totalSize);
                }
            }
            return DbStats;
        }
    }
}

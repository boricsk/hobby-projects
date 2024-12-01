using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetStore.MongoClass
{
    public class MongoStatistic
    {
        private readonly IMongoDatabase _database;
        public List<BsonValue> DbStats { get; private set; } = new List<BsonValue>();
        public MongoStatistic(IMongoDatabase database)
        {
            _database = database;
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

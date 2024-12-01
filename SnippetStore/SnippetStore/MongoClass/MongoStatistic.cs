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
                    DbStats.Add(stats["db"]);
                    DbStats.Add(stats["collections"]);
                    DbStats.Add(stats["dataSize"]);
                    DbStats.Add(stats["storageSize"]);
                    DbStats.Add(stats["indexSize"]);
                    long totalSize = stats["dataSize"].ToInt64() + stats["indexSize"].ToInt64();                    
                    DbStats.Add(totalSize);
                }
            }
            return DbStats;
        }
    }
}

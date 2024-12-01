using MongoDB.Bson;
using MongoDB.Driver;
using SnippetStore.RegistryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetStore.MongoClass
{
    public class MongoConnectionManagement
    {
        private IMongoDatabase _database;
        private string dbName = "SnippetStore";
        private string _MongoConString = string.Empty;
        private string _MongoConStringLocal = string.Empty;
        public bool conStatus { get; private set; }
        public string ConnectedTo { get; private set; }
        public MongoConnectionManagement(string conString)
        {
            conStatus = ConnectToDatabase();
        }
        public bool ConnectToDatabase()
        {
            bool ret = true;
            if (RegistryOps.ReadConStringLocal() == "")
            {
                RegistryOps.WriteConStringLocal("mongodb://localhost:27017");
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
                ret = false;
                MessageBox.Show($"Connection Error: {e.Message}");
            }
            return ret;
        }
        public IMongoCollection<T> GetCollection<T>(string collName)
        {
            return _database.GetCollection<T>(collName);
        }

        public IMongoDatabase GetDatabase()
        {
            return _database;
        }

        public bool PingConnection(string conString)
        {
            try
            {
                var pingClient = new MongoClient(conString);
                var result = pingClient.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));                
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}

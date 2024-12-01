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
        public string ConnectedTo { get; private set; }
        public MongoConnectionManagement(string conString)
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
        }
        public IMongoCollection<T> GetCollection<T>(string collName)
        { 
            return _database.GetCollection<T>(collName);
        }

        public IMongoDatabase GetDatabase()
        { 
            return _database;
        }
    }
}

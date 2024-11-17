using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetStore
{
    public class Languages
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Programming language")]
        public string Language { get; set; }

    }

    public class SnippetDatabase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Programming language")]
        public string SnipLanguage { get; set; }
        [BsonElement("Snippet name")]
        public string SnipName { get; set; }
        [BsonElement("Keywords")]
        public List<string> SnipKeywords { get; set; } = new List<string>();
        [BsonElement("Short description")]
        public string SnipShortDesc { get; set; }
        [BsonElement("Code snippet")]
        public string SnipCode { get; set; }
        [BsonElement("Issue date")]
        public DateTime SnipCreatedDate { get; set; }
        [BsonElement("Number of view")]
        public int NoOfView { get; set; }        
    }
}

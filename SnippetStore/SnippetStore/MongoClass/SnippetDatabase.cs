using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetStore.MongoClass
{
    public class Languages
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Programming language")]
        public string? Language { get; set; }

    }

    public class Keywords
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Keyword")]
        public string? Keyword { get; set; }

    }

    public class ResWords
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Reserved word")]
        public string? ResWord { get; set; }


    }

    public class BlockSeparators
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Block separator")]
        public string? BlockSep { get; set; }

    }

    public class SnippetDatabase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Programming language")]
        public string? SnipLanguage { get; set; }
        [BsonElement("Snippet name")]
        public string? SnipName { get; set; }
        [BsonElement("Keywords")]
        public List<string> SnipKeywords { get; set; } = new List<string>();
        [BsonElement("Short description")]
        public string? SnipShortDesc { get; set; }
        [BsonElement("Code snippet")]
        public string? SnipCode { get; set; }
        [BsonElement("Issue date")]
        public DateTime SnipCreatedDate { get; set; }
        [BsonElement("Number of view")]
        public int NoOfView { get; set; }
    }
}

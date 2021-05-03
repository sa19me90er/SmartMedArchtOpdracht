using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SmartMedArchtOpdracht.Buisiness_Logica.Entities
{
    public class Medicine
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string name { get; set; }

        public int quantity { get; set; }

        public DateTime creationDate { get; set; }

        public Medicine()
        {
        }
    }
}

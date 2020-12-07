using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ecommerce.Infrastructure.MongoDB
{
    internal class LogDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        internal string Id { get; set; }

        [BsonElement("conteudo")]
        internal string Conteudo { get; set; }
    }
}

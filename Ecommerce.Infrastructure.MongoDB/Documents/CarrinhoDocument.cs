using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Ecommerce.Infrastructure.MongoDB
{
    internal class CarrinhoDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        internal string Id { get; set; }

        [BsonElement("produtos")]
        internal List<ProdutoDocument> Produtos { get; set; } = new List<ProdutoDocument>();
    }
}

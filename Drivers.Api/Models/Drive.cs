using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Drivers.Api.Models;
public class Drive
{
    [BsonId]//obtener id
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id {get; set;} = string.Empty;
    [BsonElement("Nombre")]
    public string Nombre {get; set;} = string.Empty;
    [BsonElement("Numbre")]
    public int Numbre {get; set;} 
    [BsonElement("Team")]
    public string Team {get;set;} = string.Empty;
}

using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbDemo.Models
{
    public class User
    {
        [BsonId]
        public int Id { get; set; }
        public string email { get; set; }
        public string password { get; set; }    
    }
}

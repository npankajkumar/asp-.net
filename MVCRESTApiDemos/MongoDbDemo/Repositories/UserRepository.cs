using MongoDB.Driver;
using MongoDbDemo.Models;

namespace MongoDbDemo.Repositories
{
    public class UserRepository
    {
        IMongoDatabase actalent;
        IMongoClient actalentClient;
        public UserRepository()
        {
            actalentClient = new MongoClient("mongodb://localhost:27017");
            actalent = actalentClient.GetDatabase("actalent");
        }
        public IMongoCollection<User> Users => actalent.GetCollection<User>("users");
        public bool AddUser(User user)
        {
            Users.InsertOne(user);
            return true;
        }
        public List<User> GetUsers()
        {
            return Users.Find(u => true).ToList();
        }
        public bool UpdateUser(int id,User user)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id, user.Id);
            var update = Builders<User>.Update.Set(u => u.password, user.password);
                                          
            var result = Users.UpdateOne(filter, update);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
        public bool DeleteUser(int id)
        {
            var result = Users.DeleteOne(u => u.Id == id);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }
        public bool Validate(User user)
        {
            var result = Users.Find(u => u.email == user.email && u.password == user.password);
            if(result !=null)
                return result.CountDocuments() > 0;
            return false;
        }
    }
    }

using System;
using System.Linq;

namespace HostBooking.Models.Repositories
{
    public class UserRepository : IRepository<User>
    {
        public void Insert(User user)
        {
            using var db = new DbContext();
            if (UserWithLoginExists(db, user?.Login))
                throw new Exception("User exists");
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public bool IsAuth(string login, string password)
        {
            Console.WriteLine("isAuth");
            try
            {
                using var db = new DbContext();
                var users = db.Users.ToArray();
                Console.WriteLine(users[0]);
                return db.Users.Any(user => user.Login == login && user.Password == password);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool UserWithLoginExists(DbContext dbCon, string login)
        {
            return dbCon.Users.Any(user => user.Login == login);
        }
    }
}
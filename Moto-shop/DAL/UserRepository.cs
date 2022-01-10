using Moto_shop.Models;
using Org.BouncyCastle.Crypto.Generators;

namespace Moto_shop.DAL
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly ApplicationDbContext _db;

        private bool disposed = false;


        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public User RegisterUser(User user)
        {
            try
            {
                var createdUser = _db.Add(user);
                _db.SaveChanges();

                return createdUser.Entity;
            }
            catch (Exception)
            {

                throw new Exception("Email is exist");
            }
        }

        public User CheckPassword(string email, string password)
        {
            var user = _db.Users.SingleOrDefault(u => u.Email == email);
            if (user == null)
            {
                throw new Exception("Invalid email. User not found");
            }
            if (BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return user;
            }
            return null;
        }

        public User GetUserById(int id)
        {
            return _db.Users.FirstOrDefault(u => u.Id == id);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

using System;
using System.Linq;
using KeepNote3.IRepo;



namespace DAL
{
    //Repository class is used to implement all Data access operations
    public class UserRepository : IUserRepository
    {
        private KeepDbContext _dbContext;
        public UserRepository(KeepDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        //This method should be used to delete an existing user. 
        public bool DeleteUser(string userId)
        {
            var user = _dbContext.Users.Find(userId);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        //This method should be used to get a user by userId.
        public User GetUserById(int userId)
        {
            var user = _dbContext.Users.First(users => users.userId == userId);
            return user;
        }
        //This method should be used to save a new user.
        public bool RegisterUser(User user)
        {
            throw new NotImplementedException();
        }
        //This method should be used to update an existing user.
        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
        //This method should be used to validate a user using userId and password.
        public bool ValidateUser(string userId, string password)
        {
            throw new NotImplementedException();
        }
    }
}
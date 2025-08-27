namespace bblTest01
{
    public class UserRepository
    {
        private static readonly List<User> _users = new()
    {
        new User { Id = 1, Name = "Leanne Graham", Username = "Bret", Email = "Sincere@april.biz", Phone = "1-770-736-8031", Website = "hildegard.org" },
        new User { Id = 2, Name = "Ervin Howell", Username = "Antonette", Email = "Shanna@melissa.tv", Phone = "010-692-6593", Website = "anastasia.net" }
    };

        public static List<User> GetAll() => _users;

        public static User? GetById(long id) => _users.FirstOrDefault(u => u.Id == id);

        public static void Add(User user)
        {
            user.Id = _users.Max(u => u.Id) + 1;
            _users.Add(user);
        }

        public static bool Update(long id, User updatedUser)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            existing.Name = updatedUser.Name;
            existing.Username = updatedUser.Username;
            existing.Email = updatedUser.Email;
            existing.Phone = updatedUser.Phone;
            existing.Website = updatedUser.Website;
            return true;
        }

        public static bool Delete(long id)
        {
            var user = GetById(id);
            return user != null && _users.Remove(user);
        }
    }
}

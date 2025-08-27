namespace bblTest01
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Website { get; set; }
    }
}

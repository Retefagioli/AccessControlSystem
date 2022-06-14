namespace DataAccess.Models
{
    public class UserModel : CreateUserModel
    {
        public int Id { get; set; }
    }

    public class CreateUserModel
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Gender{ get; set; }
        public int GroupId { get; set; }
    }
}

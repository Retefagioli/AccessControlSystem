namespace DataAccess.Models
{
    public class AccessTokenModel : CreateAccessTokenModel
    {
        public int Id { get; set; }
    }

    public class CreateAccessTokenModel
    {
        public string? Token { get; set; }
        public int UserId { get; set; }
    }
}

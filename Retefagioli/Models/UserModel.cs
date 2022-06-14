using System.Text.Json.Serialization;

namespace Retefagioli.Models
{
    public class UserModel
    {
        public UserModel(int id, string name, string surname, string email, string phone, string gender, int groupId)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
            Gender = gender;
            GroupId = groupId;
        }

        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("surname")]
        public string? Surname { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }
        [JsonPropertyName("phone")]
        public string? Phone { get; set; }
        [JsonPropertyName("gender")]
        public string? Gender { get; set; }
        [JsonPropertyName("groupId")]
        public int GroupId { get; set; }

        public override string ToString()
        {
            return Id + " " + Name + " " + Surname + " " +
            Phone + " " + Email + " " + Gender + " " + GroupId;
        }
    }
}

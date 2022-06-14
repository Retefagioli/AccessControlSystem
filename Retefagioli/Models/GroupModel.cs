using System.Text.Json.Serialization;

namespace Retefagioli.Models
{
    public class GroupModel
    {
        public GroupModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
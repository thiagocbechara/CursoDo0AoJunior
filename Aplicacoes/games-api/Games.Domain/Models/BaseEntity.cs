using System.Text.Json.Serialization;

namespace Games.Domain.Models
{
    public abstract class BaseEntity
    {
        [JsonIgnore]
        public long Id { get; set; }
    }
}
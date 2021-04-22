using System.Text.Json.Serialization;

namespace Banco.Domain.Database
{
    public abstract class BaseEntity
    {
        [JsonIgnore]
        public long Id { get; set; }
    }
}

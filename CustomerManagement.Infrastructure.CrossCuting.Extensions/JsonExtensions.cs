using Newtonsoft.Json;

namespace CustomerManagement.Infrastructure.CrossCuting.Extensions
{
    public static class JsonExtensions
    {

        public static string Serialize<T>(T obj)
            => JsonConvert.SerializeObject(obj, Formatting.Indented);

        public static T Deserialize<T>(string value)
            => JsonConvert.DeserializeObject<T>(value);
    }
}

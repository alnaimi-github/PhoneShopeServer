using System.Text.Json.Serialization;
using System.Text.Json;

namespace PhonesShope.Services.StaticGlobal
{
    public static class General
    {
        public static string SerializeObj(object modelObject) => JsonSerializer.Serialize(modelObject, JsonOptions());
        public static T DesterilizeJsonString<T>(string jsonString) => JsonSerializer.Deserialize<T>(jsonString, JsonOptions())!;
        public static StringContent GenerateStringContent(string serializedObj) => new(serializedObj, System.Text.Encoding.UTF8, "application/json");
        public static IEnumerable<T> DesterilizeJsonStringList<T>(string jsonString) => JsonSerializer.Deserialize<IEnumerable<T>>(jsonString, JsonOptions())!;
        public static JsonSerializerOptions JsonOptions()
        {
            return new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip
            };
        }
    }
}

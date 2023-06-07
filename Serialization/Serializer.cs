using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MerchantHub.Connector.Proxy.Api.Serialization
{
    internal sealed class Serializer
    {
        private static readonly JsonSerializer _jsonSerializer = new JsonSerializer
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.None
        };

        internal static string SerializeToString(object data)
        {
            return JsonConvert.SerializeObject(data, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatString = "yyyy-MM-dd'T'HH:mm:ss"
            });
        }

        internal static T DeserializeString<T>(string json)
        {
            try
            {
                using var stringReader = new StringReader(json);
                using var jsonReader = new JsonTextReader(stringReader);
                return _jsonSerializer.Deserialize<T>(jsonReader);
            }
            catch (Exception e)
            {
                throw new SerializationException($"Could not deserialize object of type {typeof(T)}", e, json);
            }
        }
    }
}

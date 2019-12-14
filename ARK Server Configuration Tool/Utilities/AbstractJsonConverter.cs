using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using ARK_Server_Configuration_Tool.Structs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARK_Server_Configuration_Tool.Utilities
{
    public abstract class AbstractJsonConverter<T> : JsonConverter
    {
        protected abstract T Create(Type objectType, JObject jObject, string path);

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);

            T target = Create(objectType, jObject, reader.Path.Split('.').Last());
            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }

        public override void WriteJson(
            JsonWriter writer,
            object value,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        protected static bool FieldExists(
            JObject jObject,
            string name,
            JTokenType type)
        {
            JToken token;
            return jObject.TryGetValue(name, out token) && token.Type == type;
        }
    }
}



using CrystalWind.VegaSharp.Core.Specifications;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Reflection;

namespace CrystalWind.VegaSharp.Core
{
    internal class JsonViewCreator
    {
        private JsonViewCreator()
        {

        }

        public static JsonViewCreator Get { get; } = new JsonViewCreator();

        class MyContractResolver : DefaultContractResolver
        {

            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                JsonProperty property = base.CreateProperty(member, memberSerialization);
                if (typeof(IVegaObject).IsAssignableFrom(property.DeclaringType))
                {
                    property.PropertyName = property.PropertyName.ToLower();
                }
                return property;
            }
        }

        class MixValueConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return typeof(IMixInternalValue).IsAssignableFrom(objectType);
            }


            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                var res = value as IMixInternalValue;
                writer.WriteValue(res.GetValue());
            }
        }


        public string Create(ISpecification specification)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore
            };
            settings.ContractResolver = new MyContractResolver();
            settings.Formatting = Formatting.Indented;

            settings.Converters.Add(new MixValueConverter());
            settings.Converters.Add(new StringEnumConverter(new CamelCaseNamingStrategy()));

            return JsonConvert.SerializeObject(specification, settings);
        }

    }

}



using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace CrystalWind.VegaSharp.Core
{
    internal class JsonViewCreator
    {
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

        public string Create(Engine engine)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore
            };
            settings.ContractResolver = new MyContractResolver();
            settings.Formatting = Formatting.Indented;
            return JsonConvert.SerializeObject(engine, settings);
        }

    }

}

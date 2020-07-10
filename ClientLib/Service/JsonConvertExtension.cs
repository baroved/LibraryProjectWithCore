using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientLib.Service
{
    public class JsonConvertExtension : JsonConverter
    {
        #region Methods
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(AbstractItem);
        }

        //get json of abstractitem array and per all item create class by type
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);

            if (jo["type"].Value<string>() == "Book")
                return jo.ToObject<Book>(serializer);

            if (jo["type"].Value<string>() == "Journal")
                return jo.ToObject<Journal>(serializer);



            return null;
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

}

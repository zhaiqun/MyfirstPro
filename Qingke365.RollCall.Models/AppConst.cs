using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qingke365.RollCall.Models
{
    public class AppConst
    {

        public static JsonSerializerSettings DefaultJsonSerializerSettings => new JsonSerializerSettings()
        {
            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
            Formatting = Newtonsoft.Json.Formatting.Indented,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
            {
                IgnoreSerializableAttribute = true
            },
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
            DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat,
            DateFormatString = "yyyy-MM-dd HH:mm:ss"
        };
    }
}

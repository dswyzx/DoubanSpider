using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoubanSpider
{
    public static class TupelExtent
    {
        public static string ToJson(this object obj, Formatting format = Formatting.Indented)
        {
            JsonSerializerSettings jsetting = new JsonSerializerSettings();
            jsetting.NullValueHandling = NullValueHandling.Ignore;
            jsetting.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            return JsonConvert.SerializeObject(obj, format, jsetting);
        }
    }
}

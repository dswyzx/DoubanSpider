using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Dapper.Contrib.Extensions;
using Dapper;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Net.Http.Headers;
using System.Net;

namespace DoubanSpider
{
    /// <summary>
    /// blinddate里有全文的标识,读取接口获取全文存入fullpage
    /// </summary>
    public class Pro_getfull : BaseProgram
    {

        static void Main1(string[] args)
        {
            ConfigReset();

            for (int i = 0; i < 102; i++)
            {
                string sql = " select id,fullid,dd from BlindDate where dd=0 limit 10 ";
                List<BlindDate> datas = conn.Query<BlindDate>(sql).AsList();
                string res = "";

                List<FullPages> pages = new List<FullPages>();

                foreach (var data in datas)
                {
                    res = GetRespose(data.fullid);
                    FullPages page = new FullPages();
                    page.fullid = data.fullid;
                    page.details = res;

                    pages.Add(page);
                    int ins = conn.Execute($" update  BlindDate set dd=1 where id={data.id}");
                }
                long insert = conn.Insert(pages);
            }

        }

        private static string GetRespose(long fullid)
        {
            string url = $"https://www.douban.com/j/note/{fullid}/full";
            //string url = $"https://www.douban.com/j/note/759336526/full";
            nlog.Info($"get respose:{fullid}");

            var handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip
            };
            HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("Accept", " application/json, text/javascript, */*; q=0.01");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", " Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.97 Safari/537.36");
            client.DefaultRequestHeaders.Add("Cookie", "bid=a-0BrXT9Wrw");

            HttpResponseMessage response = client.GetAsync(url).Result;
            client.Dispose();
            var responseString = response.Content.ReadAsStringAsync().Result;

            responseString = responseString.Replace("{\"html\":\"", "");
            responseString = responseString.Remove(responseString.Length - 2, 2);
            //  responseString = responseString.Replace("\\\"", "");


            // var res = Regex.Unescape(responseString);
            //  res = res.Replace("\\", "/");
            return responseString;
        }
    }
}

using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading;

namespace DoubanSpider
{
    /// <summary>
    /// 自接口获取豆瓣话题下发帖,部分帖子格式较早可看到全文,两种格式实体类不一致.插入blinddate
    /// </summary>
    public class Program : BaseProgram
    {

        public static int start = 1760;
        static void Main1(string[] args)
        {
            ConfigReset();
            #region url
            /* 
            string filepath = @"D:\code\douban\res1page.txt";
            string str = File.ReadAllText(filepath);
             */
            #endregion
            string str = "";
            Stopwatch stopWatch = new Stopwatch();
            for (int i = start; i <= 1740; i = i + 20)
            {
                try
                {
                    stopWatch.Start();
                    start = i;
                    str = GetRespose(start);
                    //string filepath = @"D:\code\douban\1.json";
                    //string str = File.ReadAllText(filepath);
                    TitleModel model = JsonConvert.DeserializeObject<TitleModel>(str);

                    MysqlDapper mysql = new MysqlDapper();
                    List<BlindDate> li = new List<BlindDate>();
                    List<FullPages> pages = new List<FullPages>();

                    ObjectAddList(model, li, pages);
                    var insertint = mysql.InsertObjList(li);
                    if (pages.Count > 0)
                    {
                        int tt = mysql.InsertObjList(pages);
                    }

                    if (insertint == 0)
                    {
                        nlog.Error($"insert result 0,get one obj:({li[0].ToJson()})");
                    }
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    if (ts.TotalSeconds < 5)
                    {
                        nlog.Info($"once time(s):{ts.TotalSeconds}");
                        Random r = new Random();
                        int sec = r.Next(3000, 6000);
                        Thread.Sleep(sec);
                    }
                }
                catch (Exception e)
                {
                    nlog.Error(e, $"str:{str}");
                    throw;
                }

            }
        }

        private static void ObjectAddList(TitleModel model, List<BlindDate> li, List<FullPages> pages)
        {
            foreach (var item in model.items)
            {
                var target = item.target;
                BlindDate date = new BlindDate();

                if (target.status == null)
                {
                    if (int.TryParse(target.author.id, out int id))
                    {
                        date.author_id = id;
                    }
                    if (int.TryParse(target.id, out int fullid))
                    {
                        date.fullid = fullid;
                    }
                    else
                    {
                        nlog.Error($"原:{target.id},start:{start},target{item.target.ToJson()}");
                        break;
                    }
                    date.author_loc = target.author.loc == null ? "" : target.author.loc.name;
                    date.author_name = target.author.name == null ? "" : target.author.name;
                    date.author_reg = Convert.ToDateTime(target.author.reg_time);
                    date.theabstract = item.@abstract;
                    date.page_createtime = Convert.ToDateTime(target.create_time);
                    li.Add(date);
                }
                else
                {
                    FullPages page = new FullPages();

                    var status = target.status;
                    if (long.TryParse(status.author.id, out long id))
                    {
                        date.author_id = id;
                    }
                    if (long.TryParse(status.id, out long fullid))
                    {
                        date.fullid = fullid;
                        page.fullid = fullid;
                    }
                    else
                    {
                        nlog.Error($"原:{status.id},start:{start},target{item.target.ToJson()}");
                        break;
                    }
                    date.author_loc = status.author.loc == null ? "" : status.author.loc.name;
                    date.author_name = status.author.name;
                    date.author_reg = Convert.ToDateTime(status.author.reg_time);
                    date.theabstract = item.@abstract;
                    date.page_createtime = Convert.ToDateTime(status.create_time);
                    li.Add(date);

                    page.detailstext = status.text;

                    string imgs = "";
                    if (status.images.Length > 0)
                    {
                        foreach (var img in status.images)
                        {
                            imgs += img.large.url + ";";
                        }
                    }
                    page.imgs = imgs;
                    pages.Add(page);
                }
            }
        }

     

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        private static string GetRespose(int start)
        {
            string url = $"https://m.douban.com/rexxar/api/v2/gallery/topic/51644/items?sort=hot&start={start}&count=20&status_full_text=1&guest_only=0&ck=t5wj";
            //string url = $"https://m.douban.com/rexxar/api/v2/gallery/topic/51644/items?sort=hot&start=1740&count=20&status_full_text=1&guest_only=0&ck=t5wj";
            nlog.Info($"start:{start},url:{url}");

            var handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip
            };
            HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("Accept", " application/json, text/javascript, */*; q=0.01");
            client.DefaultRequestHeaders.Add("Accept-Encoding", " gzip, deflate, br");
            client.DefaultRequestHeaders.Add("Accept-Language", " zh-CN,zh-TW;q=0.9,zh;q=0.8,en;q=0.7");
            client.DefaultRequestHeaders.Add("Cache-Control", " no-cache");
            client.DefaultRequestHeaders.Add("Connection", " keep-alive");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Host", " m.douban.com");
            client.DefaultRequestHeaders.Add("Origin", " https://www.douban.com");
            client.DefaultRequestHeaders.Add("Pragma", " no-cache");
            client.DefaultRequestHeaders.Add("Referer", " https://www.douban.com/gallery/topic/51644/");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", " empty");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", " cors");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Site", " same-site");
            client.DefaultRequestHeaders.Add("User-Agent", " Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.97 Safari/537.36");

            string cookie = "bid=a-0BrXT9Wr";
            if (start % 200 == 0)
            {
                Random r = new Random();
                cookie += r.Next(0, 9);
            }

            client.DefaultRequestHeaders.Add("Cookie", "bid=a-0BrXT9Wrw");

            HttpResponseMessage response = client.GetAsync(url).Result;
            client.Dispose();
            var responseString = response.Content.ReadAsStringAsync().Result;

            responseString = responseString.Replace("\\\"", "");

            var res = Regex.Unescape(responseString);

            res = res.Replace("\\", "/");
            return res;
        }

    }

}

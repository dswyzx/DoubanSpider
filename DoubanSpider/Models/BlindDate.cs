using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoubanSpider
{
    [Table("blinddate")]
    public class BlindDate
    {
        public int id { get; set; }
        public string name { get; set; } = "";
        public int age { get; set; } = 0;
        public string address { get; set; } = "";
        public string sex { get; set; } = "";
        public string sexchose { get; set; } = "";
        public string edu { get; set; } = "";
        public string history { get; set; } = "";
        public int height { get; set; } = 0;
        public int weight { get; set; } = 0;
        public string hobbies { get; set; } = "";
        public string advantages { get; set; } = "";
        public string disadvantages { get; set; } = "";
        public string requirements { get; set; } = "";
        public string author_loc { get; set; } = "";
        public string author_name { get; set; } = "";
        public long author_id { get; set; } = 0;
        public DateTime author_reg { get; set; } = Convert.ToDateTime("2000-1-1");
        public long fullid { get; set; } = 0;
        public string theabstract { get; set; } = ""; //简介
        public string pagetitle { get; set; } = "";
        public DateTime page_createtime { get; set; } = Convert.ToDateTime("2000-1-1");

        public int dd { get; set; } = 0;
    }
}

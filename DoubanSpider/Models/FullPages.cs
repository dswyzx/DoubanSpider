using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoubanSpider
{
    [Table("FullPage")]
    public class FullPages
    {
        public long fullid { get; set; }
        public string details { get; set; }
        public string detailstext { get; set; }
        public string imgs { get; set; }
    }
}

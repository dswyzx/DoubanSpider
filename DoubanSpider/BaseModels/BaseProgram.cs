using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using NLog;
using System;
using System.IO;

namespace DoubanSpider
{
    /// <summary>
    /// 一些公用
    /// </summary>
    public class BaseProgram
    {
        public static readonly Logger nlog = LogManager.GetCurrentClassLogger();
        public static IConfigurationRoot configuration;
        public static MySqlConnection conn = new MySqlConnection() { ConnectionString = Program.configuration["Option:ConnectionString"] };

        /// <summary>
        /// 初始化读取配置
        /// </summary>
        public static void ConfigReset()
        {
            configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("appsettings.json", false)
            .Build();
            string conn = configuration["Option:ConnectionString"];
        }
    }

}

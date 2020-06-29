using System;
using System.Collections.Generic;
using System.Text;

namespace DoubanSpider
{
    public class TitleModel
    {
        public int count { get; set; }
        public int start { get; set; }
        public int total { get; set; }
        public int folded_total { get; set; }
        public Item[] items { get; set; }
    }

    public class Item
    {
        public Target target { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string @abstract { get; set; }
        //public Topic topic { get; set; }
        //public string source { get; set; }
        //public bool by_topic_creator { get; set; }
        //public int vote_status { get; set; }
        //public bool is_ad { get; set; }
    }

    public class Target
    {
        public Status status { get; set; }

        //  public string @abstract { get; set; }
        //public string domain { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string create_time { get; set; }
        public int collections_count { get; set; }
        public int reshares_count { get; set; }
        /// <summary>
        /// 页id
        /// </summary>
        public string id { get; set; }
        public Author author { get; set; }
        // public object[] comments { get; set; }
        //public bool is_collected { get; set; }
        //public bool can_transfer_reply_limit { get; set; }
        //public string type { get; set; }
        //public int reaction_type { get; set; }
        public string update_time { get; set; }
        //public int photo_count { get; set; }
        //public string cover_url { get; set; }
        //public int timeline_share_count { get; set; }
        //public string sharing_url { get; set; }
        //public Photo[] photos { get; set; }
        //public int likers_count { get; set; }
        //public string reply_limit { get; set; }
        //public string uri { get; set; }
        //public int read_count { get; set; }
        /// <summary>
        /// 详情页
        /// </summary>
        public string url { get; set; }
        //public int reactions_count { get; set; }
        //public int comments_count { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        //public bool can_transfer_accessible { get; set; }
    }



    public class Status
    {
        public string text { get; set; }
        public Image[] images { get; set; }

        public string id { get; set; }

        public Author author { get; set; }

        public string create_time { get; set; }
    }


    /// <summary>
    /// 个人信息
    /// </summary>
    public class Author
    {
        public Loc loc { get; set; }
        //public string kind { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public string reg_time { get; set; }
        /// <summary>
        /// 本人页
        /// </summary>
        public string url { get; set; }
        //public string uri { get; set; }
        //public string avatar { get; set; }
        //public string type { get; set; }
        /// <summary>
        /// 个人id
        /// </summary>
        public string id { get; set; }
        public string uid { get; set; }
    }

    /// <summary>
    /// 选择城市
    /// </summary>
    public class Loc
    {
        /// <summary>
        /// 108288 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 北京
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// beijing
        /// </summary>
        public string uid { get; set; }
    }
    public class Image
    {
        public Large large { get; set; }

        public bool is_animated { get; set; }

    }
    public class Large
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int size { get; set; }
    }

    #region unuse
    /*
    public class Photo
    {
        public string src { get; set; }
    }
    public class Topic
    {
        public int subscription_count { get; set; }
        public Creator creator { get; set; }
        public bool is_subscribed { get; set; }
        public object[] guests { get; set; }
        public string card_subtitle { get; set; }
        public string id { get; set; }
        public string topic_label_bg_color { get; set; }
        public string topic_label_bg_img { get; set; }
        public string topic_icon { get; set; }
        public int post_count { get; set; }
        public string label { get; set; }
        public string topic_label_hashtag_color { get; set; }
        public object[] ad_monitor_urls { get; set; }
        public bool is_ad { get; set; }
        public string unpublic_reason { get; set; }
        public int participant_count { get; set; }
        public object subject_card { get; set; }
        public string cover_url { get; set; }
        public int content_type { get; set; }
        public bool is_public { get; set; }
        public string topic_label_text_color { get; set; }
        public string name { get; set; }
        public string sharing_url { get; set; }
        public string topic_icon_large { get; set; }
        public object[] click_track_urls { get; set; }
        public string uri { get; set; }
        public string introduction { get; set; }
    }

    public class Creator
    {
        public Loc1 loc { get; set; }
        public string kind { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public int verify_type { get; set; }
        public string reg_time { get; set; }
        public string uri { get; set; }
        public string avatar { get; set; }
        public string type { get; set; }
        public string id { get; set; }
        public string uid { get; set; }
    }

    public class Loc1
    {
        public string id { get; set; }
        public string name { get; set; }
        public string uid { get; set; }
    }
    */
    #endregion

}

using System;
using System.Collections.Generic;
using System.Text;

namespace DoubanSpider.Models
{

    public class Rootobject
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
        public string _abstract { get; set; }
        public Topic1 topic { get; set; }
        public string source { get; set; }
        public bool by_topic_creator { get; set; }
        public int vote_status { get; set; }
        public bool is_ad { get; set; }
    }

    public class Target
    {
        public Status status { get; set; }
        public string type { get; set; }
        public Comment[] comments { get; set; }
        public bool liked { get; set; }
        public string _abstract { get; set; }
        public string domain { get; set; }
        public string create_time { get; set; }
        public int collections_count { get; set; }
        public int reshares_count { get; set; }
        public string id { get; set; }
        public Author1 author { get; set; }
        public bool is_collected { get; set; }
        public bool can_transfer_reply_limit { get; set; }
        public int reaction_type { get; set; }
        public string update_time { get; set; }
        public int photo_count { get; set; }
        public string cover_url { get; set; }
        public int timeline_share_count { get; set; }
        public string sharing_url { get; set; }
        public Photo[] photos { get; set; }
        public int likers_count { get; set; }
        public string reply_limit { get; set; }
        public string uri { get; set; }
        public int read_count { get; set; }
        public string url { get; set; }
        public int reactions_count { get; set; }
        public int comments_count { get; set; }
        public string title { get; set; }
        public bool can_transfer_accessible { get; set; }
    }

    public class Status
    {
        public bool liked { get; set; }
        public string text { get; set; }
        public string screenshot_title { get; set; }
        public object notice_info { get; set; }
        public string screenshot_url { get; set; }
        public bool is_subscription { get; set; }
        public Image[] images { get; set; }
        public int reshares_count { get; set; }
        public string screenshot_type { get; set; }
        public string id { get; set; }
        public object censor_info { get; set; }
        public Author author { get; set; }
        public string subscription_text { get; set; }
        public string mini_program_cover_url { get; set; }
        public object[] entities { get; set; }
        public bool can_transfer_reply_limit { get; set; }
        public object reshared_status { get; set; }
        public bool forbid_reshare_and_comment { get; set; }
        public string activity { get; set; }
        public int resharers_count { get; set; }
        public string reshare_id { get; set; }
        public bool is_private { get; set; }
        public string sharing_url { get; set; }
        public object card { get; set; }
        public Topic topic { get; set; }
        public string wechat_timeline_share { get; set; }
        public string reply_limit { get; set; }
        public int like_count { get; set; }
        public string uri { get; set; }
        public string mini_program_page { get; set; }
        public object parent_status { get; set; }
        public object video_info { get; set; }
        public string create_time { get; set; }
        public int comments_count { get; set; }
        public string mini_program_name { get; set; }
        public bool allow_comment { get; set; }
        public bool is_status_ad { get; set; }
        public bool can_transfer_accessible { get; set; }
    }

    public class Author
    {
        public Loc loc { get; set; }
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

    public class Loc
    {
        public string id { get; set; }
        public string name { get; set; }
        public string uid { get; set; }
    }

    public class Topic
    {
        public string topic_label_bg_color { get; set; }
        public string topic_label_bg_img { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public object[] click_track_urls { get; set; }
        public Tail_Icon tail_icon { get; set; }
        public string uri { get; set; }
        public string subheading { get; set; }
        public string id { get; set; }
        public string topic_icon { get; set; }
        public string topic_label_hashtag_color { get; set; }
        public int content_type { get; set; }
        public string type { get; set; }
        public string card_subtitle { get; set; }
        public object[] ad_monitor_urls { get; set; }
        public string topic_icon_large { get; set; }
        public string topic_label_text_color { get; set; }
        public bool is_ad { get; set; }
        public string sharing_url { get; set; }
    }

    public class Tail_Icon
    {
    }

    public class Image
    {
        public Large large { get; set; }
        public object raw { get; set; }
        public bool is_animated { get; set; }
        public Normal normal { get; set; }
    }

    public class Large
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int size { get; set; }
    }

    public class Normal
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int size { get; set; }
    }

    public class Author1
    {
        public Loc1 loc { get; set; }
        public string kind { get; set; }
        public string name { get; set; }
        public string reg_time { get; set; }
        public string url { get; set; }
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

    public class Comment
    {
        public bool is_folded { get; set; }
        public Ref_Comment ref_comment { get; set; }
        public bool is_censoring { get; set; }
        public bool is_deleted { get; set; }
        public Author2 author { get; set; }
        public string text { get; set; }
        public int total_replies { get; set; }
        public string uri { get; set; }
        public Entity[] entities { get; set; }
        public string create_time { get; set; }
        public object[] replies { get; set; }
        public string parent_comment_id { get; set; }
        public int id { get; set; }
    }

    public class Ref_Comment
    {
    }

    public class Author2
    {
        public Loc2 loc { get; set; }
        public string kind { get; set; }
        public string name { get; set; }
        public string reg_time { get; set; }
        public string url { get; set; }
        public string uri { get; set; }
        public string avatar { get; set; }
        public string type { get; set; }
        public string id { get; set; }
        public string uid { get; set; }
        public int verify_type { get; set; }
    }

    public class Loc2
    {
        public string id { get; set; }
        public string name { get; set; }
        public string uid { get; set; }
    }

    public class Entity
    {
        public int start { get; set; }
        public int end { get; set; }
        public string uri { get; set; }
        public string title { get; set; }
    }

    public class Photo
    {
        public string src { get; set; }
    }

    public class Topic1
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
        public Loc3 loc { get; set; }
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

    public class Loc3
    {
        public string id { get; set; }
        public string name { get; set; }
        public string uid { get; set; }
    }

}

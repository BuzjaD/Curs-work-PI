using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photosharing.Models
{
    public class Photo
    {
        public string id { get; set; }
        public string user_id { get; set; }
        public string user_avatar { get; set; }
        public string username { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public DateTime creation_date { get; set; }
        public int likes  { get; set; }
    }
}

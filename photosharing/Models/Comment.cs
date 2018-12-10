using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photosharing.Models
{
    public class Comment
    {
        public int id { get; set; }
        public DateTime creation_date { get; set; }
        public string user_id { get; set; }
        public string Text { get; set; }
        public string photo_id { get; set; }
    }
}

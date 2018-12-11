using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace photosharing.Models
{
    public class Photo
    {
        public string id { get; set; }
        public string user_id { get; set; }
        [ForeignKey("user_id")]
        public User User { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public DateTime creation_date { get; set; }
        public int likes  { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}

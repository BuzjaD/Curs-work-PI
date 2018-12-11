using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace photosharing.Models
{
    public class Follower
    {
        public int id { get; set; }
        public string follower_id { get; set; }
        [ForeignKey("follower_id")]
        public User User { get; set; }
        public string user_id { get; set; }
        [ForeignKey("user_id")]
        public User User2 { get; set; }
    }
}

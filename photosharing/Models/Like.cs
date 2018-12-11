using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace photosharing.Models
{
    public class Like
    {
        public string id { get; set; }
        public string user_id { get; set; }
        [ForeignKey("user_id")]
        public User User { get; set; }
        public string photo_id { get; set; }
        [ForeignKey("photo_id")]
        public Photo Photo { get; set; }
    }
}

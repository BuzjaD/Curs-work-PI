using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photosharing.Models
{
    public class Like
    {
        public string id { get; set; }
        public string user_id { get; set; }
        public string photo_id { get; set; }
    }
}

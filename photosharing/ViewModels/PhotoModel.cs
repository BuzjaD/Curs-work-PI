using photosharing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photosharing.ViewModels
{
    public class PhotoModel
    {
        public Photo Photo { get; set; }
        public User User { get; set; }
        public bool isLiked;
        public Dictionary<Comment, User> Comments { get; set; }
    }
}

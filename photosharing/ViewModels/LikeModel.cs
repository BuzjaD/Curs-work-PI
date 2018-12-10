using photosharing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photosharing.ViewModels
{
    public class LikeModel
    {
        public Photo Photo { get; set; }
        public bool isLiked;
    }
}

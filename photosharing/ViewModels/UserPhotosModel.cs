using photosharing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photosharing.ViewModels
{
    public class UserPhotosModel
    {
        public User user { get; set; }
        public List<PhotoModel> userPhotos { get; set; }

        public bool isSubscribe { get; set; }
    }
}

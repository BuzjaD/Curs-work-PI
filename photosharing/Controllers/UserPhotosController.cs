using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using photosharing.Models;
using photosharing.ViewModels;

namespace photosharing.Controllers
{
    public class UserPhotosController : Controller
    {
        PhotosharingDBContext db;

        public UserPhotosController(PhotosharingDBContext context)
        {
            this.db = context;
        }

        public IActionResult Index(string id)
        {
            bool isSubscribe = false;

            var curUser = db.Users
                  .Where(c => c.id == User.Identity.Name)
                  .FirstOrDefault();

            ViewData["currentUserProf"] = curUser;

            foreach (var follower in db.Followers)
            {
                if (follower.follower_id == User.Identity.Name && follower.user_id == id)
                {
                    isSubscribe = true;
                }
            }

            List<PhotoModel> allPhotos = new List<PhotoModel>();
            User user = db.Users.Where(us => us.id == id).FirstOrDefault();

            foreach (var el in db.Photos)
            {
                if(el.user_id == id)
                {
                Photo newPhoto = el;
                Dictionary<Comment, User> newComments = new Dictionary<Comment, User>();
                foreach (var comm in db.Comments)
                {
                    if (comm.photo_id == newPhoto.id)
                    {
                        var comentator = db.Users.Where(us => us.id == comm.user_id).FirstOrDefault();
                        newComments.Add(comm, comentator);
                    }
                }
                PhotoModel newModel = new PhotoModel();
                newModel.Photo = newPhoto;
                newModel.User = user;
                newModel.Comments = newComments;
                allPhotos.Add(newModel);
                }
            }
            UserPhotosModel UPmodel = new UserPhotosModel { userPhotos = allPhotos, user = user, isSubscribe = isSubscribe };

            return View(UPmodel);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Follow(string userId)
        {

            Follower follower = new Follower() { follower_id = User.Identity.Name, user_id = userId };

            db.Followers.Add(follower);
            await db.SaveChangesAsync();

            String redirectPath = "~/UserPhotos?id=" + userId.ToString();

            return RedirectPermanent(redirectPath);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Unfollow(string userId)
        {

            Follower follower = db.Followers
                .Where(c => c.follower_id == User.Identity.Name && c.user_id == userId)
                .FirstOrDefault();

            db.Followers.Remove(follower);
            await db.SaveChangesAsync();

            String redirectPath = "~/UserPhotos?id=" + userId.ToString();

            return RedirectPermanent(redirectPath);

        }
    }
}
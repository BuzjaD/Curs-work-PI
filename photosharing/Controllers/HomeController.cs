using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using photosharing.Models;
using photosharing.ViewModels;

namespace photosharing.Controllers
{
    public class HomeController : Controller
    {
        private PhotosharingDBContext db;

        public HomeController(PhotosharingDBContext ctx)
        {
            db = ctx;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await db.Users
                   .Where(c => c.id == User.Identity.Name)
                   .FirstOrDefaultAsync();

            ViewData["currentUser"] = user;

            List<PhotoModel> allPhotos = new List<PhotoModel>();
            List<string> followingIds = new List<string>();
            List<User> followingUsers = new List<User>();

            foreach(var el in db.Followers)
            {
                if(el.follower_id == User.Identity.Name)
                {
                    followingIds.Add(el.user_id);
                }
            }
            foreach (var id in followingIds)
            {
                foreach (var us in db.Users)
                {
                    if (id == us.id)
                    {
                        followingUsers.Add(us);
                    }
                }
            }
            foreach(var followingUser in followingUsers) {
            foreach (var el in db.Photos)
            {
                    if (el.user_id == followingUser.id)
                    {
                        Photo newPhoto = el;
                        User newUser = await db.Users.Where(us => us.id == newPhoto.user_id).FirstOrDefaultAsync();
                        Dictionary<Comment, User> newComments = new Dictionary<Comment, User>();
                        foreach (var comm in db.Comments)
                        {
                            if (comm.photo_id == newPhoto.id)
                            {
                                var comentator = await db.Users.Where(us => us.id == comm.user_id).FirstOrDefaultAsync();
                                newComments.Add(comm, comentator);
                            }
                        }
                        Like like = await db.Likes.Where(c => c.user_id == User.Identity.Name && c.photo_id == newPhoto.id).FirstOrDefaultAsync();
                        PhotoModel newModel = new PhotoModel();
                        newModel.Photo = newPhoto;
                        newModel.User = newUser;
                        newModel.Comments = newComments;
                        if (like == null)
                        {
                            newModel.isLiked = false;
                        }
                        else
                        {
                            newModel.isLiked = true;
                        }
                        allPhotos.Add(newModel);
                    }
            }
            }
            return View(allPhotos);
        }

        [Authorize]
        public async Task<IActionResult> AllPublications()
        {
            var user = await db.Users
                   .Where(c => c.id == User.Identity.Name)
                   .FirstOrDefaultAsync();

            ViewData["currentUser"] = user;

            List<PhotoModel> allPhotos = new List<PhotoModel>();
           
                foreach (var el in db.Photos)
                {
                        Photo newPhoto = el;
                        User newUser = await db.Users.Where(us => us.id == newPhoto.user_id).FirstOrDefaultAsync();
                        Dictionary<Comment, User> newComments = new Dictionary<Comment, User>();
                        foreach (var comm in db.Comments)
                        {
                            if (comm.photo_id == newPhoto.id)
                            {
                                var comentator = await db.Users.Where(us => us.id == comm.user_id).FirstOrDefaultAsync();
                                newComments.Add(comm, comentator);
                            }
                        }
                        Like like = await db.Likes.Where(c => c.user_id == User.Identity.Name && c.photo_id == newPhoto.id).FirstOrDefaultAsync();
                        PhotoModel newModel = new PhotoModel();
                        newModel.Photo = newPhoto;
                        newModel.User = newUser;
                        newModel.Comments = newComments;
                        if (like == null)
                        {
                            newModel.isLiked = false;
                        }
                        else
                        {
                            newModel.isLiked = true;
                        }
                        allPhotos.Add(newModel);
                }
            return View("Index",allPhotos);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult GetPhoto()
        {
            return PartialView("_PhotoComponent");
        }

        public async Task<ActionResult> Details(string id)
        {
            Photo newPhoto = await db.Photos.Where(photo => photo.id == id).FirstOrDefaultAsync();
            if (newPhoto != null)
            {
                User newUser = await db.Users.Where(us => us.id == newPhoto.user_id).FirstOrDefaultAsync();
                Dictionary<Comment, User> newComments = new Dictionary<Comment, User>();
                foreach (var comm in db.Comments)
                {
                    if (comm.photo_id == newPhoto.id)
                    {
                        var comentator = await db.Users.Where(us => us.id == comm.user_id).FirstOrDefaultAsync();
                        newComments.Add(comm, comentator);
                    }
                }
                Like like = await db.Likes.Where(c => c.user_id == User.Identity.Name && c.photo_id == newPhoto.id).FirstOrDefaultAsync();
                PhotoModel newModel = new PhotoModel();
                newModel.Photo = newPhoto;
                newModel.User = newUser;
                newModel.Comments = newComments;
                if(like == null)
                {
                    newModel.isLiked = false;
                }
                else
                {
                    newModel.isLiked = true;
                }
                return PartialView(newModel);
            }
            return HttpNotFound();
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }
    }
}

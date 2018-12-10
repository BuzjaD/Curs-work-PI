using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using photosharing.Models;
using photosharing.ViewModels;

namespace photosharing.Controllers
{
    public class PhotoController : Controller
    {
        PhotosharingDBContext db;
        IHostingEnvironment _env;
        public PhotoController(PhotosharingDBContext context, IHostingEnvironment env)
        {
            this.db = context;
            _env = env;
        }

        [HttpGet]
        public IActionResult AddPhoto()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePhoto(Photo newPhoto)
        {
            var newFileName = string.Empty;

            if (HttpContext.Request.Form.Files != null)
            {
                var fileName = string.Empty;
                string PathDB = string.Empty;

                var files = HttpContext.Request.Form.Files;

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.ToString().Replace('"', ' ').Trim();
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                        var FileExtension = Path.GetExtension(fileName);

                        newFileName = myUniqueFileName + FileExtension;

                        fileName = Path.Combine(_env.WebRootPath, "uploads") + $@"\{newFileName}";
                        
                        PathDB = "~/uploads/" + newFileName;
                        string thumbnailDB = "~/uploads/thumbs/" + newFileName;
                        using (FileStream fs = System.IO.File.Create(fileName))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }

                        DateTime now = DateTime.Now;
                        var user = db.Users
                        .Where(c => c.id == User.Identity.Name)
                        .FirstOrDefault();
                        if(newPhoto.description == null)
                        {
                            newPhoto.description = "No description";
                        }
                        db.Photos.Add(new Photo { id = myUniqueFileName, user_id = user.id, username = user.username, user_avatar = user.avatar, url = PathDB, creation_date = now, description = newPhoto.description,likes = 0 });
                        await db.SaveChangesAsync();
                        return RedirectToAction("Index","Home");
                    }
                }
            }
            return RedirectToAction("AddPhoto");
        }

        [Authorize]
        public async Task<IActionResult> DeletePhoto(string photoId)
        {
            var user = db.Users
                   .Where(c => c.id == User.Identity.Name)
                   .FirstOrDefault();
            var photoToDelete = db.Photos.Where(p => p.id == photoId && p.user_id == user.id).FirstOrDefault();
            string[] parts = photoToDelete.url.Split('/');

            string filename = Path.Combine(_env.WebRootPath, "uploads") + $@"\{parts[2]}"; 
            
            filename = Path.Combine(_env.WebRootPath, "uploads") + $@"\thumbs" + $@"\{parts[2]}";
            try
            {
                    if (System.IO.File.Exists(filename))
                    {
                        System.IO.File.Delete(filename);
                    }
            }
            catch (IOException ex)
            {
                return View("Error", ex);
            }
            db.Photos.Remove(photoToDelete);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "UserPhotos", new {id = User.Identity.Name});
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> ToggleLike(string photoId)
        {
            Like like = db.Likes
             .Where(c => c.user_id == User.Identity.Name && c.photo_id == photoId)
             .FirstOrDefault();

            if (like == null)
            {
                Like newLike = new Like { user_id = User.Identity.Name, photo_id = photoId };

                var thisPhoto = db.Photos
                    .Where(c => c.id == photoId)
                    .FirstOrDefault();

                thisPhoto.likes += 1;

                db.Likes.Add(newLike);
                await db.SaveChangesAsync();
                LikeModel newModel = new LikeModel();
                newModel.Photo = thisPhoto;
                newModel.isLiked = true;
                return PartialView(newModel);
            }

            else
            {
                var thisPhoto = db.Photos
              .Where(c => c.id == photoId)
              .FirstOrDefault();

                thisPhoto.likes -= 1;

                db.Likes.Remove(like);
                await db.SaveChangesAsync();
                LikeModel newModel = new LikeModel();
                newModel.Photo = thisPhoto;
                newModel.isLiked = false;
                return PartialView(newModel);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> addComment(string comment, string photoId)
        {
            PhotoModel PM = new PhotoModel();
            
            if (comment != null || comment != "")
            {
                
                var photo = db.Photos
                .Where(p => p.id == photoId)
                .FirstOrDefault();
                var user = db.Users
            .Where(u => u.id == photo.user_id)
            .FirstOrDefault();
                var comentator = db.Users
            .Where(u => u.id == User.Identity.Name)
            .FirstOrDefault();
                Comment new_comment = new Comment(){ Text = comment, photo_id = photoId,  user_id = comentator.id, creation_date = DateTime.Now };
                db.Comments.Add(new_comment);
                await db.SaveChangesAsync();
                PM.Photo = photo;
                PM.User = user;
                PM.Comments = new Dictionary<Comment, User>();
                foreach (var comm in db.Comments)
                {
                    if (comm.photo_id == photoId)
                    {
                        User comenter = db.Users
                            .Where(c => c.id == comm.user_id)
                            .FirstOrDefault();

                        PM.Comments.Add(comm, comenter);
                    }
                }
            }

            return PartialView("_Comments", PM);
        }
    }
}
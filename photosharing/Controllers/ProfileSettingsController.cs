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

namespace photosharing.Controllers
{
    public class ProfileSettingsController : Controller
    {
        PhotosharingDBContext db;
        IHostingEnvironment _env;

        public ProfileSettingsController(PhotosharingDBContext context, IHostingEnvironment env)
        {
            db = context;
            _env = env;
        }

        [Authorize]
        public IActionResult ProfileSettings()
        {
            User user = db.Users
                .Where(c => c.id == User.Identity.Name)
                .FirstOrDefault();

            return View(user);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> ChangeData(String username, String email, String password, String avatar)
        {
            User user = db.Users
                .Where(c => c.id == User.Identity.Name)
                .FirstOrDefault();

            user.username = username;
            user.email = email;
            user.password = password;


            if (HttpContext.Request.Form.Files != null)
            {
                var fileName = string.Empty;
                string PathDB = string.Empty;

                var files = HttpContext.Request.Form.Files;

                foreach(var file in files)
                {
                    if (file.Length > 0)
                    {
                        fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.ToString().Replace('"', ' ').Trim();
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                        var FileExtension = Path.GetExtension(fileName);
                        string newFileName = myUniqueFileName + FileExtension;

                        fileName = Path.Combine(_env.WebRootPath, "uploads") + $@"\{newFileName}";

                        PathDB = "~/uploads/" + newFileName;

                        using (FileStream fs = System.IO.File.Create(fileName))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }
                        user.avatar = PathDB;
                    }
                }
               
                
            }
            db.Users.Update(user);

            await db.SaveChangesAsync();

            return RedirectToAction("Index","Home");
        }
    }
}
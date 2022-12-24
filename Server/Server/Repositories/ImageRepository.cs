using Server.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Server.Repositories
{
    public class ImageRepository: IImageRepository
    {
        public List<Image> GetAllImages(string cookie)
        {
            List<Image> images;
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                images = db.Images.ToList();
            }
            return images;
        }

        public Image GetImage(int id, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var image = db.Images.ToList().Where(u => u.PostId == id).SingleOrDefault();
                return image;
            }
        }

        public int AddImage(Image Image, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                db.Images.Add(Image);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
            return 1;
        }

        public int DownloadImage(FileForm image, int post_id, string cookie)
        {
            var user = new User();
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                user = db.Users.ToList().Where(u => u.PasswordHash == cookie).SingleOrDefault();
            }
            image.Name = user.Id.ToString() + "_" + DateTime.Now.ToString("Mddyyyyhhmmsstt") + ".jpg";
            try
            {
                string pather = Path.GetRelativePath(AppDomain.CurrentDomain.BaseDirectory, "websec-3/Client/Db/");
                string path = Path.Combine(pather, image.Name);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    image.file.CopyTo(stream);
                }
                var db_image = new Image { PostId = post_id, ImageUrl = image.Name, Order = 1};
                using (Models.ApplicationContext db = new Models.ApplicationContext())
                {
                    if (db.Images.ToList().Where(u => u.PostId == post_id).Count() >= 1)
                        return -1;
                    db.Images.Add(db_image);
                    db.SaveChanges();
                }
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
            return 1;
        }

        public int DeleteImage(int id, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var image = db.Images.ToList().Where(x => x.Id == id).SingleOrDefault(); 
                db.Images.Remove(image);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
            return 1;
        }
    }
}

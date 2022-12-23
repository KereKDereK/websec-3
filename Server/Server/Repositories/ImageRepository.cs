using Server.Models;
using System;
using System.Collections.Generic;
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
                var image = db.Images.Find(id);
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

        public int UpdateImage(int id, Image newImage, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var image = db.Images.ToList().Where(x => x.Id == id).SingleOrDefault();
                image.ImageUrl = newImage.ImageUrl;
                image.Order = newImage.Order;
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

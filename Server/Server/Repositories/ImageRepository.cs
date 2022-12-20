using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Repositories
{
    public class ImageRepository: IImageRepository
    {
        public List<Image> GetAllImages()
        {
            List<Image> images;
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                images = db.Images.ToList();
            }
            return images;
        }

        public Image GetImage(int id)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var image = db.Images.ToList().Where(x => x.Id == id);
                if (image.Count() == 0)
                    throw new Exception("No element with such ID");
                return (Image)image;
            }
        }

        public int AddImage(Image Image)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                db.Images.Add(Image);
                try
                {
                    db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
            return 1;
        }

        public int UpdateImage(int id, Image newImage)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var image = (Image)db.Images.ToList().Where(x => x.Id == id);
                image.ImageUrl = newImage.ImageUrl;
                image.Order = newImage.Order;
                try
                {
                    db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
            return 1;
        }

        public int DeleteImage(int id)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var image = (Image)db.Images.ToList().Where(x => x.Id == id);
                db.Images.Remove(image);
                try
                {
                    db.SaveChangesAsync();
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

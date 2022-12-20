using Server.Models;
using System.Collections.Generic;

namespace Server.Repositories
{
    public interface IImageRepository
    {
        public int AddImage(Image image);
        public int UpdateImage(int id, Image newImage);
        public int DeleteImage(int id);
        //public int DeleteAllUsers();
        Image GetImage(int id);
        public List<Image> GetAllImages();
    }
}

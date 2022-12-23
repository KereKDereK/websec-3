using Server.Models;
using System.Collections.Generic;

namespace Server.Repositories
{
    public interface IImageRepository
    {
        public int AddImage(Image image, string cookie);
        public int DownloadImage(FileForm image, int post_id, string cookie);
        public int DeleteImage(int id, string cookie);
        //public int DeleteAllUsers();
        Image GetImage(int id, string cookie);
        public List<Image> GetAllImages(string cookie);
    }
}

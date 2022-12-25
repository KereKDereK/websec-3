using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Repositories
{
    public interface IImageRepository
    {
        public int AddImage(Image image, string cookie);
        public Task<int> DownloadImage(FileForm image, int post_id, string cookie);
        public Task<int> DeleteImage(int id, string cookie);
        //public int DeleteAllUsers();
        Image GetImage(int id, string cookie);
        public List<Image> GetAllImages(string cookie);
    }
}

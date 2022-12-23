using Microsoft.AspNetCore.Http;

namespace Server.Models
{
    public class FileForm
    {
        public string Name { get; set; }
        public IFormFile file { get; set; }

        public FileForm(IFormFile file)
        {
            this.file = file;
        }
            
    }
}

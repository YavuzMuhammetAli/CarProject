using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.File
{
    public class FileManager : IFileService
    {
        public void Delete(string filepath)
        {
            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            return Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName);

                string guid = GuidHelpers.GuidHelpers.CreatGuid();
                string filePath = guid + extension;

                using (FileStream fileStream = System.IO.File.Create(root + filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();

                    return filePath;
                }
            }
            return null;
        }
    }
}

using Core.Utilities.Helpers.GuidHelper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelperManager:IFileHelper
    {
        ///for files
        public void Delete(string filePath)
        {
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        public string Update(IFormFile file,string filePath,string root)
        {
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(file, root);


        }

        public string Upload(IFormFile file, string root)
        {
            if(file.Length>0)
            {
                if(!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName);
                string guid = GuidHelperManager.CreateGuid();
                string filePath = guid + extension;//guidimiz ve yolumuzla filepathimizi oluşturuyoruz.
                using(FileStream fileStream=File.Create(root+filePath))//dosyayı wwwrootta oluştur
                {
                    file.CopyTo(fileStream);//filestream a kopyala
                    fileStream.Flush();
                    return filePath;

                }
            }
            return null;
        }

        
    }
}

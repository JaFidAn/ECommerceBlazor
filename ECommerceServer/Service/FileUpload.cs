using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceServer.Service.IService;
using Microsoft.AspNetCore.Components.Forms;

namespace ECommerceServer.Service
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _webHostEnvirenment;

        public FileUpload(IWebHostEnvironment webHostEnvirenment)
        {
            _webHostEnvirenment = webHostEnvirenment;
        }

        public bool DeleteFile(string filePath)
        {
            if (File.Exists(_webHostEnvirenment.WebRootPath + filePath))
            {
                File.Delete(_webHostEnvirenment.WebRootPath + filePath);
                return true;
            }
            return false;
        }

        public async Task<string> UploadFile(IBrowserFile file)
        {
            FileInfo fileInfo = new FileInfo(file.Name);
            var fileName = Guid.NewGuid().ToString() + fileInfo.Extension;
            var folderDirectory = $"{_webHostEnvirenment.WebRootPath}\\images\\product";
            if (!Directory.Exists(folderDirectory))
            {
                Directory.CreateDirectory(folderDirectory);
            }
            var filePath = Path.Combine(folderDirectory, fileName);

            await using FileStream fs = new FileStream(filePath, FileMode.Create);
            await file.OpenReadStream().CopyToAsync(fs);

            var fullPath = $"/images/product/{fileName}";
            return fullPath;
        }
    }
}
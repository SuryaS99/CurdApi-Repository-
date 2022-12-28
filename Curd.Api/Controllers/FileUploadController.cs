using Curd.Database;
using Curd.Model.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Curd.Api.Controllers
{
    public class FileUploadController : Controller
    {
        public static IWebHostEnvironment _environment;
        private readonly AppDbContext _appDbContext;

        public FileUploadController(IWebHostEnvironment environment, AppDbContext appDbContext)
        {
            _environment = environment;
            _appDbContext = appDbContext;

        }

        public class FileUpload
        {
            public IFormFile files { get; set; }
        }

        [HttpPost]
        [Route("File")]
        public async Task<Upload> Upload(FileUpload fileUpload)
        {
            Upload files = new Upload();

            if (fileUpload.files.Length > 0)
            {
                string fileDriveLocation = Path.Combine(_environment.WebRootPath + "\\Upload\\");
                string fileLocation = string.Concat(_environment.WebRootPath + "\\Upload\\", fileUpload.files.FileName);

                if (!Directory.Exists(fileDriveLocation))
                {
                    Directory.CreateDirectory(fileDriveLocation);
                }
                using (FileStream fileStream = System.IO.File.Create(fileLocation + FileMode.Create))
                {
                    await fileUpload.files.CopyToAsync(fileStream);
                }
                files.FilePath = fileLocation;
                files.fileName = fileUpload.files.FileName;

                await _appDbContext.Upload.AddAsync(files);
                await _appDbContext.SaveChangesAsync();


            }
            return files;
        }

        [HttpDelete]
        [Route("File/{name}")]
        public async Task<bool> FileDelete(string name)
        {
           // Upload upload = new Upload();
            int result = 0;
            var currDir = _environment.WebRootPath + "\\Upload\\";
            var files = Directory.GetFiles(currDir);
            //foreach (var file in files)
           // {
                if (!System.IO.File.Exists(string.Concat(files))) 
                {
                    System.IO.File.Delete(string.Concat(files));
                }
             //   break;
          //  }

            //if (!Directory.Exists(Path.Combine(files)))
            //{
            //    System.IO.File.Delete(Path.Combine(files));
            //}

            if (!Directory.Exists(Convert.ToString(files)))
            {
                var _fileUpload = await _appDbContext.Upload.Where(u => u.fileName == name).FirstOrDefaultAsync();

                _appDbContext.Entry(_fileUpload).State = EntityState.Deleted;
                result = await _appDbContext.SaveChangesAsync();
                }
                return result > 0 ? true : false;



            //int result = 0;
            //var currDir = _environment.WebRootPath + "\\Upload\\";
            //var files = Directory.GetFiles(currDir);
            //var filesId = Path.Combine(_environment.WebRootPath + "\\Upload\\" + id);

            //if (!Directory.Exists(Path.Combine(files)))
            //{
            //    System.IO.File.Delete(Path.Combine(files));
            //}

            //if (!Directory.Exists(filesId))
            //{
            //    var _fileUpload = await _appDbContext.Upload.Where(u => u.Id == id).FirstOrDefaultAsync();

            //    _appDbContext.Entry(_fileUpload).State = EntityState.Deleted;

            //    result = await _appDbContext.SaveChangesAsync();
            //}
            //return result > 0 ? true : false;


        }

        //[HttpPut]
        //[Route("File")]
        //public async Task<bool> FileUpdate(string name,FileUpload fileUpload)
        //{
        //    Upload upload = new Upload();
        //    var result = 0;
        //    var currDir = _environment.WebRootPath + "\\Upload\\";
        //    var files = Directory.GetFiles(currDir);
        //    var newFile= string.Concat(_environment.WebRootPath + "\\Upload\\", fileUpload.files.FileName);
        //    var filebackup= _environment.WebRootPath + "\\Upload\\"+ "\\Backup\\";

        //    if (!Directory.Exists(Convert.ToString(files)))
        //    {
        //        System.IO.File.Replace(Convert.ToString(files),newFile,filebackup);
        //    }
        //    using (FileStream fileStream = System.IO.File.Create(newFile + FileMode.Create))
        //    {
        //        await fileUpload.files.CopyToAsync(fileStream);
        //    }
        //    files.FilePath = newFile;
        //    files.fileName = fileUpload.files.FileName;

        //    var _fileUpload = await _appDbContext.Upload.Where(u => u.fileName == name).FirstOrDefaultAsync();

        //        _appDbContext.Entry(_fileUpload).State = EntityState.Modified;
        //       result = await _appDbContext.SaveChangesAsync();
           
        //    return result > 0 ? true : false;
        //    //return ;
        //}

    }
}


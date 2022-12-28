using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Curd.Model.Models
{
    public class Upload
    {
      //  public IFormFile file { get; set; }
        //  public static FileAccess Create { get; set; }
        [Key]
        public int Id { get; set; }

        [Display(Name ="File Upload")]
        public string FilePath { get; set; }
        
        public string fileName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curd.Model.Models
{
    public class TokenDto
    {
        public string Token { get; set; }
        public DateTime ExpiryTime { get; set; }

    }
}

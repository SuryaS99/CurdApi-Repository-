using Curd.ModelDTO.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curd.Services.Token
{
    public interface ITokenServices
    {
        Task<string> CreateToken(LoginDto loginDTO);


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Veiculo.Application.Interfaces
{
    public interface ITokenService
    {
        string GerarToken(string usuarioId, string email, IList<string> roles);
    }
}

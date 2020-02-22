using System;
using System.Collections.Generic;
using System.Text;

namespace Abstractions.Repository
{
    public interface IClienteRepository
    {
        byte[] ExportListaCliente();
    }
}

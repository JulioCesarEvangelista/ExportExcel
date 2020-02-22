using Abstractions.Repository;
using Abstractions.Service;
using System;

namespace Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public byte[] ExportListaCliente()
        {
            return _clienteRepository.ExportListaCliente();
        }
    }
}

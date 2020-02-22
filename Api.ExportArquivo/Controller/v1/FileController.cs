using System;
using Abstractions.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api.ExportArquivo.Controller.v1
{
    [Route("v1/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public FileController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }


        [HttpGet(Name = "ObterArquivo")]
        public IActionResult ObterArquivo()
        {
            byte[] fileContents = _clienteService.ExportListaCliente();
            string export = "Clientes";

            var file = File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: export + ".xlsx"
            );

            return file;
        }
    }
}
using Abstractions.Repository;
using Repository.File;
using System;
using System.Collections.Generic;
using System.Data;

namespace Repository
{
    public class ClienteRepository : ReportExport, IClienteRepository
    {
        public byte[] ExportListaCliente()
        {
            byte[] bytes = null;
          
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Nome");
            dt.Columns.Add("Idade");
            DataRow _ravi = dt.NewRow();
            _ravi["Nome"] = "Julio Nascimento";
            _ravi["Idade"] = "30";
            dt.Rows.Add(_ravi);

            bytes = XLSXFromDataTable(dt, "Clientes", "Relatório de Clientes");

            return bytes;
        }
    }
}

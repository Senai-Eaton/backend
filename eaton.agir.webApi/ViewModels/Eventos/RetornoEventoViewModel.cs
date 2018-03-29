using System;
using System.Collections.Generic;
using eaton.agir.webApi.ViewModels.Empresas;

namespace eaton.agir.webApi.ViewModels.Eventos
{
    public class RetornoEventoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Foto { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHora { get; set; }
        public RetornoEmpresaViewModel Empresa { get; set; }
    }
}
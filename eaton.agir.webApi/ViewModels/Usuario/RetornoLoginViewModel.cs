using System.Collections.Generic;
using eaton.agir.webApi.ViewModels.Eventos;

namespace eaton.agir.webApi.ViewModels.Usuario
{
    public class RetornoLoginViewModel
    {
        public string Foto { get; set; }
        public string Nome { get; set; }
        public string AreaAtuacao { get; set; }

        public ICollection<RetornoEventoViewModel> Eventos { get; set; }
    }
}
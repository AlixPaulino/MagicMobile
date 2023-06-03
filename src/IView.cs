using System.Collections.Generic;

namespace MagicMobile
{
    public interface IView
    {
        void ExibirMensagem(string texto);
        void ExibirLista(List<string> lista);
        void ExibirErro(string erro);
    }
}
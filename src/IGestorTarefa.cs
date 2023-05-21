using System.Collections.Generic;

namespace MagicMobile
{
    public interface IGestorTarefa
    {
        List<string> ApresentarListaTarefas();
        void NovaTarefa(string tarefa);
    }
}
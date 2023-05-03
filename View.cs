using Quarto_Chines_Eventos_Delegados;
using System;

namespace Gestor_tarefas_Eventos_Delegados {
    class View {

        public View() {
            // Inicialização dos componentes
            model = new Model();

            // Comando para encerrar o programa
            model.DocumentoTerminou += Encerrar;
        }

        // Mensagem de boas-vindas
        public void BoasVindas() {
            Console.WriteLine("Bem vindo ao Gestor de Tarefas!");
        }

        // Para atualizar a lista de tarefas
        public void AtualizarListaTarefas(int nTarefa) {
            //Obtém a tarefa inicial
            string tarefa="";
            //Colocá-la no ecrã.
            Console.WriteLine(tarefa);
        }


        // Listar tarefas View->View
        public void ListarTarefas()
        {
            // Avança para a próxima tarefa
            // estadoAtualLista sucesso (true) ou fim (false)
            if (estadoAtualLista)
                ListaAtualMudou();
            else
                ListaTerminou();
        }

        // Para encerrar o programa
        private void Encerrar()
        {
            Environment.Exit(0);
        }
    }
}
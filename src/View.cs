using Gestor_tarefas_Eventos_Delegados;
using System;
using System.Collections.Generic;

namespace Gestor_tarefas_Eventos_Delegados {
    class View {

        public View() {
        }

        // Mensagem de boas-vindas
        public void ApresentarBoasVindas() {
            Console.WriteLine("Bem vindo ao Gestor de Tarefas!");
        }


        // Para atualizar a lista de tarefas (View -> View)
        public void AtualizarListaTarefas(List<string> tarefas) // Adicione um parâmetro do tipo List<string>
        {
            Console.WriteLine("\nLista de Tarefas:");
            for (int i = 0; i < tarefas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tarefas[i]}");
            }
        }

        // Para encerrar o programa
        private void Encerrar()
        {
            Environment.Exit(0);
        }
    }
}
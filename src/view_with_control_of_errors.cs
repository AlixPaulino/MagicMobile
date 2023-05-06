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

        // Para atualizar a lista de tarefas (Model -> View)
        public void AtualizarListaTarefas(List<string> tarefas)
        {
            Console.WriteLine("\nLista de Tarefas:");
            try
            {
                if (tarefas.Count == 0)
                {
                    Console.WriteLine("Nenhuma tarefa inserida.");
                }
                else
                {
                    for (int i = 0; i < tarefas.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {tarefas[i]}");
                    }
                }
            }
            catch (Exception ex)
            {
                ApresentarErro($"Erro ao atualizar a lista de tarefas: {ex.Message}");
            }
        }

        // Para encerrar o programa
        private void Encerrar()
        {
            Environment.Exit(0);
        }

        // Para apresentar mensagem de erro
        public void ApresentarErro(string mensagem)
        {
            Console.WriteLine($"ERRO: {mensagem}");
        }

    }
}

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
        
         // Método para animar o botão ao acionar uma tarefa
        public void AnimaBotaoAcionarTarefa() {
            Console.WriteLine("Anima botão");
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
        
        // Para exibir o Menu

        public void ExibirMenu()
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Adicionar tarefa");
            Console.WriteLine("2. Visualizar tarefas");
            Console.WriteLine("3. Sair");
        }

        public void PedirDadosTarefa()
        {
            Console.WriteLine("Insira os dados da nova tarefa:");
        }
        
        public void ExibirMensagemDespedida()
        {
            Console.WriteLine("Obrigado por usar o Gestor de Tarefas!");
        }
        
        public void ExibirMensagemErro(String erro)
        {
            Console.WriteLine(erro);
            Console.WriteLine("Prima qualquer tecla para continuar.");
        }
        
        // Para encerrar o programa
        private void Encerrar()
        {
            Environment.Exit(0);
        }
    }
}

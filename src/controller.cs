using System;
using System.Collections.Generic;
using System.IO;
using MagicMobile;

namespace Gestor_tarefas_Eventos_Delegados {
    class Controller {
        private IView view;
        private Model model;

		//inicio da View e Model num construtor	
        public Controller()
        {
            view = new View();
            model = new Model();
		}

		/*Eventos e delegados para comunicação entre componentes*/
		// Fluxos controller - view
		public delegate void ApresentarTexto(string texto);
		public event ApresentarTexto MensagemTexto;

		public delegate void ApresentarMensagensLista(List<string> lista);

		public event ApresentarMensagensLista ExibirLista;

		public delegate void ExibirMensagemErro(string texto);

		public event ExibirMensagemErro MensagemErro;

		
		// Fluxos controller - model
		public delegate void DadosTarefas(string Texto);
		public event DadosTarefas Inserir;

		public delegate List<String> ApresentarListaTafefas();
		public event ApresentarListaTafefas ApresentarLista;

        public void IniciarPrograma() {
	        
	        /** Fluxos controller - view **/
	        // para apresentar a mensagens
	        MensagemTexto += view.ExibirMensagem;
	        // para apresentar uma lista no ecrã - menu ou lista de tarefas 
	        ExibirLista += view.ExibirLista;
	        // para apresentar ao utilizador a mensagem de erro 
	        MensagemErro += view.ExibirErro;
	        
	        /** Fluxos controller - model **/
	        // Registra o método que será chamado quando o evento Inserir for acionado
	        Inserir += model.NovaTarefa;
	        // pede a lista de tarefa à model
	        ApresentarLista += model.ApresentarListaTarefas;
	        

            
	        // Chama o evento MensagemTexto para apresentar a mensagem de boas-vindas
	        MensagemTexto("Bem vindo ao Gestor de Tarefas!");
            
            bool sair = false;
            while (!sair)
            {
	            List<string> opcoesMenu = new List<string>() {"Adicionar tarefa", "Visualizar tarefas", "Sair"};
	            // Exibimos o menu
	            MensagemTexto("Escolha uma opção:");
	            ExibirLista(opcoesMenu);
	            
	            string opcao = Console.ReadLine(); //recolhemos a opção

	            switch (opcao)
	            {
		            case "1":
			            LimparEcra();
			            //Adicionar tarefa;
			            //chamamos o evento que exibe a mensagem e pedimos os dados
			            MensagemTexto("Insira os dados da nova tarefa:"); 
			            string dadosTarefa = Console.ReadLine(); // lemos os dados do terminal
			            Inserir(dadosTarefa); // chamamos o evento do model que cria os dadosTarefa
			            break;
		            case "2":
			            LimparEcra();
			            // Visualizar tarefas
			            try
			            {
							List<string> listaTarefas = ApresentarLista(); // pedimos a lista ao model
							MensagemTexto("\nLista de Tarefas:");
							ExibirLista(listaTarefas); //passamos a lista à view
			            }
			            catch (InvalidOperationException e)
			            {
				            MensagemErro(e.Message);
				            Console.ReadKey();
				            LimparEcra();
			            }
			            
			            break;
		            case "3":
			            MensagemTexto("Obrigado por usar o Gestor de Tarefas!");
			            sair = true;
			            break;
		            default:
			            LimparEcra();
			            MensagemTexto("Opção inválida. Por favor escolha outra opção.");
			            break;
	            }
	            
            }
		}

        private void LimparEcra()
        {
	        try
	        {
				Console.Clear();
	        }
	        catch (IOException)
	        {
		        // em ambientes que não suportem a limpeza do ecrã o metodo clear lança uma excepção
		        // mas podemos simplesmente ignora-la e prosseguir a execução
	        }
        }
	}
}

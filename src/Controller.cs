using System;
using System.Collections.Generic;
using System.IO;

namespace Gestor_tarefas_Eventos_Delegados {
    class Controller {
        private View view;
        private Model model;

	    //inicio da View e Model num construtor	
		public Controller()
        {
            view = new View();
            model = new Model();
		}

		/*Eventos e delegados para comunicação entre componentes*/
		// Fluxos controller - view
		public delegate void ApresentacaoTexto();
		public event ApresentacaoTexto Apresentar;

		public delegate void ExibirMenu();

		public event ExibirMenu Exibir;

		public delegate void PedirDadosTarefa();

		public event PedirDadosTarefa PedirDados;

		public delegate void ExibirMensagemSaida();

		public event ExibirMensagemSaida MensagemSaida;

		public delegate void ExibirMensagemErro(string texto);

		public event ExibirMensagemErro MensagemErro;
	    public delegate void AnimaBotao();
        public event AnimaBotao AnimaBotaoAcionarTarefa;

        public delegate void AtualizarListaTarefas(List<string> lista);

        public event AtualizarListaTarefas AtualizarLista;

		
		
		// Fluxos controller - model
		public delegate void DadosTarefas(string Texto);
		public event DadosTarefas Inserir;

		public delegate List<String> ApresentarListaTafefas();
		public event ApresentarListaTafefas ApresentarLista;

        public void IniciarPrograma() {
	        
	        /** Fluxos controller - view **/
	        // para apresentar a mensagem de boas vinda 
	        Apresentar += view.ApresentarBoasVindas;
	        // para apresentar ao utilizador as opções do menu
	        Exibir += view.ExibirMenu;
	        // para apresentar ao utilizador a mensagem a pedir os dados da tarefa
	        PedirDados += view.PedirDadosTarefa;
	        // Atualiza a lista de tarefas na view
	        AtualizarLista += view.AtualizarListaTarefas;
	        // Registra o método que será chamado quando o evento AnimaBotaoAcionarTarefa for acionado
	        AnimaBotaoAcionarTarefa += view.AnimaBotaoAcionarTarefa;
	        // Regista o método que será chamado para apresentar a mensagem de despedida quando o user sair
	        MensagemSaida += view.ExibirMensagemDespedida;
	        // Regista o método que será chamado para apresentar mensagens de erro
	        MensagemErro += view.ExibirMensagemErro;
	        
	        /** Fluxos controller - model **/
	        // Registra o método que será chamado quando o evento Inserir for acionado
	        Inserir += model.NovaTarefa;
	        // pede a lista de tarefa à model
	        ApresentarLista += model.ApresentarListaTarefas;
	        

            
	        // Chama o evento Apresentar para apresentar a mensagem de boas-vindas
            Apresentar();
            
            bool sair = false;
            while (!sair)
            {
	            Exibir(); // Exibimos o menu
	            string opcao = Console.ReadLine(); //recolhemos a opção

	            switch (opcao)
	            {
		            case "1":
			            LimparEcra();
			            // Adiciona a animação do botão de acionar tarefa
                        AnimaBotaoAcionarTarefa();
			            //Adicionar tarefa;
			            PedirDados(); //chamamos o evento que exibe a mensagem de pedir os dados
			            string dadosTarefa = Console.ReadLine(); // lemos os dados do terminal
			            Inserir(dadosTarefa); // chamamos o evento do model que cria os dadosTarefa
			            break;
		            case "2":
			            LimparEcra();
			            // Visualizar tarefas
			            try
			            {
							List<string> listaTarefas = ApresentarLista(); // pedimos a lista ao model
							AtualizarLista(listaTarefas); //passamos a lista à view
			            }
			            catch (InvalidOperationException e)
			            {
				            Console.WriteLine(e.Message);
			            }
			            
			            break;
		            case "3":
			            MensagemSaida();
			            sair = true;
			            break;
		            default:
			            LimparEcra();
			            Console.WriteLine("Opção inválida. Por favor escolha outra opção.");
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

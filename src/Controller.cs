using System;

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

        // Eventos e delegados para comunicação  
	   public delegate void ApresentacaoTexto();
	   public event ApresentacaoTexto Apresentar;
        
       public delegate void DadosTarefas(string Texto);
	  public event DadosTarefas Inserir;
	  
	 public delegate void AnimaBotao();
	  public event AnimaBotao AnimaBotaoAcionarTarefa;

        public void IniciarPrograma() {

             //para apresentar a mensagem de boas vinda após o clique do utilizador em IniciarPrograma()
            Apresentar += view.ApresentarBoasVindas;          
            // Chama o evento Apresentar para apresentar a mensagem de boas-vindas
            Apresentar();

              // Registra o método que será chamado quando o evento Inserir for acionado
            Inserir += model.NovaTarefa;
            // Solicita a inserção de dados de tarefas
            Inserir("Insira os dados da tarefa nova: ");
			
			 // Registra o método que será chamado quando o evento AnimaBotaoAcionarTarefa for acionado
            AnimaBotaoAcionarTarefa += view.AnimaBotaoAcionarTarefa;
            // Adiciona a animação do botão de acionar tarefa
            AnimaBotaoAcionarTarefa();
			
			// Atualiza a lista de tarefas na view
			 view.AtualizarListaTarefas(model.ApresentarListaTarefas());
			
		}
	}
}

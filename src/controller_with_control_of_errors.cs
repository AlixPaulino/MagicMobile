using System;

namespace Gestor_tarefas_Eventos_Delegados {
    class Controller {
        private View view;
        private Model model;

        // Inicializa a View e Model no construtor	
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

            // Para apresentar a mensagem de boas-vinda após o clique do utilizador em IniciarPrograma()
            Apresentar += view.ApresentarBoasVindas;          
            // Chama o evento Apresentar para apresentar a mensagem de boas-vindas
            try {
                Apresentar();
            } catch (Exception ex) {
                view.ApresentarErro(ex.Message);
            }

            // Registra o método que será chamado quando o evento Inserir for acionado
            Inserir += model.NovaTarefa;
            // Solicita a inserção de dados de tarefas
            try {
                Inserir("Insira os dados da tarefa nova: ");
            } catch (Exception ex) {
                view.ApresentarErro(ex.Message);
            }
			
            // Registra o método que será chamado quando o evento AnimaBotaoAcionarTarefa for acionado
            AnimaBotaoAcionarTarefa += view.AnimaBotaoAcionarTarefa;
            // Adiciona a animação do botão de acionar tarefa
            try {
                AnimaBotaoAcionarTarefa();
            } catch (Exception ex) {
                view.ApresentarErro(ex.Message);
            }
			
            // Atualiza a lista de tarefas na view
            try {
                view.AtualizarListaTarefas(model.ApresentarListaTarefas());
            } catch (Exception ex) {
                view.ApresentarErro(ex.Message);
            }
        }
		
        public string DadosTarefas()
        {
            Console.WriteLine("Insira os dados da tarefa:");
            string texto = Console.ReadLine();
            return texto;
        }
    }
}

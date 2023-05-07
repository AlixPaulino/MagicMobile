using System;

namespace Gestor_tarefas_Eventos_Delegados {
    class Controller {

        private View view;
        private Model model;

        // Eventos e delegados para comunicação 
        public delegate void ApresentacaoTexto();
        public event ApresentacaoTexto Apresentar;

        public delegate void DadosTarefas(string Texto);
        public event DadosTarefas Inserir;

        public Controller()
        {
            view = new View();
            view.CliqueBotaoAcionarTarefa += AnimaBotaoAcionarTarefa;
            view.ListaTarefas += MostrarListaTarefas;
        }

        public void IniciarPrograma() {

            // Inicialização dos componentes
            model = new Model();

            //para apresentar a mensagem de boas vinda após o clique do utilizador em IniciarPrograma()
            Apresentar += view.ApresentarBoasVindas;          

            // Apresenta o programa
            Apresentar();

            // Inicia os dados de tarefas
            Inserir += model.DadosTarefas;
            Inserir();

            // Inicia a inserção de dados de tarefas
            string texto = NovaTarefa();
            model.NovaTarefa();

            //Pedir lista de tarefas
            ListaTarefas();
            model.ApresentarListaTarefas();

            //Atualizar lista de tarefas
            AtualizarListaTarefas();
            view.ApresentarAtualizarListaTarefas();
        }

        public void AnimaBotaoAcionarTarefa()
        {
            // Adicionar animação após clique do botão de acionar tarefa
        }

        public void MostrarListaTarefas()
        {
            // Mostrar lista de tarefas na View
            string lista = model.GetListaTarefas();
            view.ListagemTarefas(lista);
        }

        public string NovaTarefa()
        {
            string texto = Console.ReadLine();
            return texto;
        }

        public void ListaTarefas()
        {
            model.PedirListaTarefas();
        }

        public void AtualizarListaTarefas()
        {
            model.AtualizarListaTarefas();
        }
    }
}
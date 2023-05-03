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

        public void IniciarPrograma() {

            // Inicialização dos componentes
            view = new View();
            model = new Model();

           //para apresentar a mensagem de boas vinda após o clique do utilizador em IniciarPrograma()
            Apresentar += view.ApresentarBoasVindas;          

            // Apresenta o programa
            Apresentar();

            // Inicia os dados de tarefas
            DadosTarefas();
            model.DadosTarefas();

            // Inicia a inserção de dados de tarefas
            string texto = NovaTarefa();
            model.NovaTarefa();


            //Pedir lista de tarefas
            ListaTarefas();
            model.ApresentarListaTarefas();

            //Atualizar lista de tarefas
            AtulizarListaTarefas();
            view.ApresentarAtualizarListaTarefas();
        }


        public string DadosTarefas() {
            string texto = Console.ReadLine();
            return texto;
        }

        public string NovaTarefa()
        {
            string texto = Console.ReadLine();
            return texto;
        }

        public string ListaTarefas()
        {
            string texto = Console.ReadLine();
            return texto;
        }

        public string AtualizarListaTarefas()
        {
            string texto = Console.ReadLine();
            return texto;
        }
    }

}

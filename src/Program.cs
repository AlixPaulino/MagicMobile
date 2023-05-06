using System;
using Gestor_tarefas_Eventos_Delegados;

namespace Gestor_tarefas_Eventos_Delegados_Main {
    class Program {
        static void Main(string[] args) {
            // Cria uma instancia de um objeto da classe Controller
            Controller controller = new Controller();
            
            // Inicia o programa chamando o método IniciarPrograma() da classe Controller
            controller.IniciarPrograma();
        }
    }
}
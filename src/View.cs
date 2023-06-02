using Gestor_tarefas_Eventos_Delegados;
using System;
using System.Collections.Generic;
using MagicMobile;

namespace Gestor_tarefas_Eventos_Delegados {
    class View:IView {

        public View() {
        }
        
        //Método para exibir uma mensagem de texto;
        public void ExibirMensagem(string texto)
        {
           Console.WriteLine(texto); 
        }

        //Método para exibir strings numa lista
        public void ExibirLista(List<string> lista)
        {
            for(int i = 0 ; i < lista.Count ; i++) 
                Console.WriteLine($"{i + 1}. {lista[i]}");
        }

        //Método para exibir uma mensagem de erro
        public void ExibirErro(string erro)
        {
            Console.WriteLine(erro);
            Console.WriteLine("Prima qualquer tecla para continuar.");
        } 


    }
}

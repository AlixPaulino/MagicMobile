using System;
using System.Collections.Generic;

namespace Gestor_tarefas_Eventos_Delegados {
    class Model {
        
        // Lista onde são armazenadas as tarefas
        private List<string> tarefas;

        // Construtor da classe Model
        public Model() {
            // No construtor inicializamos a lista de tarefas
            tarefas = new List<string>();
        }

        // Método para adicionar uma tarefa à lista,
        // Parametro "texto" com a descrição da tarefa 
        public void NovaTarefa(string texto) {
            tarefas.Add(texto);
        }

        // Método para retornar a lista de tarefas atual
        // Retrona uma List<string> com todas as tarefas armazenadas. 
        public List<string> ApresentarListaTarefas() {
            return tarefas;
        }
    }
}
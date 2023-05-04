using System;
using System.Collections.Generic;

namespace Gestor_tarefas_Eventos_Delegados {
    class Model {

        private List<string> tarefas;

        public Model() {
            tarefas = new List<string>();
        }

        public void DadosTarefas(string texto) {
            tarefas.Add(texto);
        }

        public void NovaTarefa(string texto) {
            tarefas.Add(texto);
        }

        public List<string> ApresentarListaTarefas() {
            return tarefas;
        }
    }
}
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

        public string ApresentarListaTarefas() {
            string listaTarefas = "";

            for (int i = 0; i < tarefas.Count; i++) {
                listaTarefas += $"{i + 1}. {tarefas[i]}\n";
            }

            return listaTarefas;
        }
    }
}
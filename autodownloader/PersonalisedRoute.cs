using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autodownloader
{
    /*
     * Clase que contiene un nombre identificador y un 'List' con 'PersonalisedActions'.
     * Este 'List' es un recorrido creado por el usuario.
     */
    public class PersonalisedRoute
    {
        // Identificador del recorrido
        public string name { get; set; }
        // 'List' con 'PersonalisedActions' que forman un recorrido
        public List<PersonalisedAction> route = new List<PersonalisedAction>();
    }
}

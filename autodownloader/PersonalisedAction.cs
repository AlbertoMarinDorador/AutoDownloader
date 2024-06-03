using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autodownloader
{
    /*
     * Esta clase almacena una determinada accion y el resto las inicializa a cero.
     * El tipo de accion viene indicado por la variable 'actionType'. 
     */
    public class PersonalisedAction
    {
        // Indica el tipo de accion almacenado en esta clase
        // 1.Point, 2.Text, 3.Wait, 4.RouteId
        public int actionType { get; set; } = 0;
        // Almacena la posicion en la que se realizara un click 
        public Point mousePosition = new Point();
        // Almacena el texto a introducir
        public string texto { get; set; }
        // Almacena el tiempo de espera en segundos
        public uint waitTime { get; set; }
        // Almacena la id de la ruta a ejecutar dentro de esta ruta
        public int personalisedRouteId { get; set; }
    }
}

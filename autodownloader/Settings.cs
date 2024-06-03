using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autodownloader
{
    /*
     * Esta clase tiene el objetivo de almacenar las opciones necesarias para el programa.
     */
    public class Settings
    {
        // OPCIONES GENERALES
        // 'List' con todos los recorridos creados por el usuario
        public List<PersonalisedRoute> personalisedRoutes = new List<PersonalisedRoute>();

        // OPCIONES DESCARGA
        // La ruta a la carpeta donde van a estar todas las descargas
        public string topLevelFolderDefaultPath { get; set; }
        // La ruta al .txt con  los links para las descargas
        public string linksFileDefaultPath { get; set; }
        // Segun el valor realizara un recorrido entre descargas.
        // El valor indica la cantidad de descargas a esperar antes de ejecutarse.
        // 0 == nunca.
        public uint iterationNumber;
        // La posicion del recorrido a ejecutar entre descargas.
        public int iterateActionId;
    }
}

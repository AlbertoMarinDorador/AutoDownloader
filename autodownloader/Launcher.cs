using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autodownloader
{
    static class Launcher
    {
        /*
         * La clase 'Launcher' esta pensada para que lea la BD antes de abrir la vista y le mande como 
         * argumentos las variables necesarias (Ej: Rutas de directorios, variables, etc).
         */
        [STAThread]
        static void Main()
        {
            Settings pathsAndParams;
            pathsAndParams = DealWithDB.LoadSettings();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Interface(pathsAndParams));
        }
    }
}

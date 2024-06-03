using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autodownloader
{
    /*
     * Clase que contiene todos los modulos que interaccionan con archivos o carpetas
     */
    class DealWithFilesAndDirs
    {
        /*
         * Modulo que lee un txt y devuelve un array de string con su contenido linea a linea
         * A mejorar:
         *      - Mirar la manera de que el modulo devuelva un 'List', solo he conseguido 
         *          que funcione con un array de string.
         */
        public static String[] ReadFile(string linksFile)
        {
            List<string> lines_list = new List<string>();
            try
            {   // Open the text file using a stream reader.
                using (StreamReader file = new StreamReader(linksFile))
                {
                    string line = "";
                    // Saving the data 
                    while ((line = file.ReadLine()) != null)
                    {
                        lines_list.Add(line);
                    }
                    file.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            string[] lines_array = lines_list.ToArray();
            return lines_array;
        }

        /*
         * Modulo que te devuelve un 'bool' en funcion de si existe o no el archivo. 
         * Return: True (existe), False (no existe).
         */
        static public bool CheckFileExists(string FilePath)
        {
            bool itExisted = true;
            if (!File.Exists(FilePath))
            {
                itExisted = false;
            }
            return itExisted;
        }

        /*
         * Modulo que te devuelve un 'bool' en funcion de si el archivo esta o no vacio.
         * Return: True (vacio), False (no vacio).
         */
        static public bool FileIsEmpty(string file)
        {
            bool empty = false;
            if (new FileInfo(file).Length == 0)
            {
                empty = true;
            }
            return empty;
        }

        /*
         * Modulo que espera hasta que aparece un archivo nuevo en la carpeta especificada
         * A mejorar:
         *      - Que compruebe la validez del archivo que aparece en la carpeta
         *      - Que muestre los segundos que lleva esperando en la descarga
         */
        public static void WaitDownloadEnd(string pathDownloadFolder, int partsCounter, Interface view)
        {
            do
            {
                // Compruebo si se ha solicitado el cierre de la hebra desde la vista.
                if (view.HaveToForcedStopState()) return;
            } while (Directory.GetFiles(pathDownloadFolder).Length < partsCounter);
        }



        /*      FUTURE CODE
           string[] fileEntries = Directory.GetFiles(pathDownloadFolder);

           foreach (string fileName in fileEntries)
               System.Console.WriteLine("ficheros: {0}", fileName);
           */


        /*      Lo quite porque esta version te creaba un archivo default de no existir ninguno
         static public bool CheckLinksFileExists(string linksFilePath, string linksFileDefaultPath)
        {
            bool itExisted = true;
            if (!File.Exists(linksFilePath))
            {
                System.IO.File.Create(linksFileDefaultPath);
                itExisted = false;
            }
            return itExisted;
        } 
         */

        /*
         * Modulo que te devuelve un 'bool' en funcion de si existe o no la carpeta 
         * Return: True (existe), False (no existe).
         */
        static public bool CheckTopLevelFolderExists(string topLevelFolderPath)
        {
            bool itExisted = true;
            if (!Directory.Exists(topLevelFolderPath))
            {
                itExisted = false;
            }
            return itExisted;
        }

        /*      DEPRECATED
         * Modulo que crea una nueva carpeta dentro de 'topLevelFolder' con el nombre 'dirName'
         * asegurandome de que en caso de ya existir, crearla añadiendo una numeracion
         * A mejorar:
         *      - Me gustaria resumir un poco mas la comprobacion de si existe
         */
        public static string CreateNewDir(string topLevelFolder, string dirName)
        {
            string newFolder = System.IO.Path.Combine(topLevelFolder, dirName);     // El path del nuevo Dir
            int CounterForRepeatsDirs = 1;      // Sirve para comprobar si hay mas de 1 Dir con el mismo nombre

            // Si el Dir no existe, lo crea
            if (!Directory.Exists(newFolder))
            {
                System.IO.Directory.CreateDirectory(newFolder);
                return newFolder;
            }
            else
            {
                // Si el Dir existe, intento crearlo añadiendo una numeracion al final
                while (Directory.Exists(newFolder + "_" + CounterForRepeatsDirs))
                {
                    CounterForRepeatsDirs++;        // Si sigue existiendo, aumento el numero
                }
                System.IO.Directory.CreateDirectory(newFolder + "_" + CounterForRepeatsDirs);
                return newFolder + "_" + CounterForRepeatsDirs;
            }
        }

        /*      Lo quite porque esta version te creaba una carpeta default de no existir ninguna
         static public bool CheckTopLevelFolderExists(string topLevelFolderPath, string topLevelFolderDefaultPath)
        {
            bool itExisted = true;
            if (!Directory.Exists(topLevelFolderPath))
            {
                System.IO.Directory.CreateDirectory(topLevelFolderDefaultPath);
                itExisted = false;
            }
            return itExisted;
        } 
         */
    }
}

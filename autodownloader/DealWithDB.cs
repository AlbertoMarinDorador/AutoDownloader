using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace autodownloader
{
    /*
     * Esta clase contiene todos los modulos que se relacionan con la Base de Datos o con los 
     * datos en si.
     */
    class DealWithDB
    {
        /*      
         * Este modulo esta pensado para que lea de la BD si el usuario tiene algun dato guardado,
         * de no ser asi, le devuelve unos parametros default.
         * Return: Return: Un objeto 'Settings' con todos los ajustes.
         */
        public static Settings LoadSettings()
        {
            if(!existDB())
            {
                return DefaultSettings.Load();
            }
            else 
            {
                return LoadDBSettings();
            }
        }

        /*
         * Comprueba si existen datos guardados en la DB.
         * Return: existen datos guardados (true), que no existen (false)
         */
        public static Boolean existDB()
        {
            if (DealWithFilesAndDirs.CheckFileExists(GetDBPath()))
            {
                if (IsDBCorrect())
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        /*
         * Compruebo si la primera linea de la DB es correcta.
         * Si la DB es correcta (true), si no (false)
         */
        public static bool IsDBCorrect()
        {
            string line = GetDBFirstLine();       
            try
            {
                if (line.Contains("xml version") && line != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: The first line could not be read:");
                return false;
            }
        }

        /*
         * Devuelve la primera linea de la DB
         */
        public static string GetDBFirstLine()
        {
            string line = "";
            try
            {   // Open the text file using a stream reader.
                using (StreamReader file = new StreamReader(GetDBPath()))
                {
                    // Saving the data 
                    line = file.ReadLine();
                    file.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return line;
        }

        /*
         * Devuelve la ruta de la DB
         */
        public static string GetDBPath()
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "\\db.xml";
            return path;
        }
        
        /*
         * Devuelve los ajustes guardados en la DB.
         * Return: Un objeto 'Settings' con todos los ajustes.
         */
        public static Settings LoadDBSettings()
        {
            Settings newSettings = new Settings();
            newSettings = DealWithXML.LoadDB();
            return newSettings;
        }

        /*
         * LLama a una funcion que se encarga de guardar los ajustes en la DB
         */
        public static void SaveDBSettings(Settings theSettings)
        {
            DealWithXML.SaveDB(theSettings);
        }
    }
}

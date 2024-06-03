using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace autodownloader
{
    /*
     * Clase que contiene los modulos encargados de simular y gestionar al raton
     */
    public class DealWithMouse
    {
        /*
         * Permite simular los click del raton
         */
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        /*
         * Permite cambiar la posicion del raton
         */
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetCursorPos(int X, int Y);

        /*
         * Retrieves the cursor's position, in screen coordinates.
         */
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point mousePosition);

        /*
         * Utiliza una biblioteca DLL para obtener la posicion del raton.
         */
        public static Point GetCursorPosition()
        {
            Point mousePosition;
            GetCursorPos(out mousePosition);
            return mousePosition;
        }

        /*
         * Hace uso de una biblioteca DLL para mover el raton y de otra para realizar el click.
         */
        public static void MakeLeftClick(Point pos)
        {
            uint X = 0;
            uint Y = 0;
            // Mueve al raton 
            SetCursorPos(pos.X, pos.Y);     
            // Realiza la accion
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);      
        }
        
        /*
         * Simula el clik derecho del raton en la posicion indicada
         */
        public static void MakeRightClick(Point pos)
        {
            uint X = 0;
            uint Y = 0;
            SetCursorPos(pos.X, pos.Y);
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, X, Y, 0, 0);
        }
    }
}

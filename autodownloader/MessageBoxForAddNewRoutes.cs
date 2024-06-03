using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autodownloader
{
    /*
     * Esta vista actua como 'MessageBox', dependiendo de la opcion que elijas 
     * se devolvera un 'DialogResult' distinto.
     */
    public partial class MessageBoxForAddNewRoutes : Form
    {
        //  En esta variable se almacenaran los datos de las opciones que lo requieran
        public string newActionValue { get; set; }
        // Constructor, inicializa
        public MessageBoxForAddNewRoutes(Settings loadedSettings)
        {
            InitializeComponent();
            for (int i = 0; i < loadedSettings.personalisedRoutes.Count; i++)
            {
                comboBoxActualPersonalisedRoutes.Items.Add(i + ". " + loadedSettings.personalisedRoutes[i].name);
            }
        }

        /*
         * Devuelve el 'DialogResult' 'Yes'
         */
        private void captureClick_Click(object sender, EventArgs e)
        {

        }

        /*
         * Devuelve el 'DialogResult' 'No'
         */
        private void captureText_Click(object sender, EventArgs e)
        {
            newActionValue = textBoxCaptureText.Text;
        }

        /*
         * Devuelve el 'DialogResult' 'OK'
         */
        private void Finish_Click(object sender, EventArgs e)
        {
            
        }

        /*
         * Devuelve el 'DialogResult' 'Ignore'
         */
        private void captureWaitTime_Click(object sender, EventArgs e)
        {
            newActionValue = textBoxCaptureWaitTime.Text;
        }

        /*
         * Devuelve el 'DialogResult' 'Retry'
         */
        private void addActualPersonalisedRoutes_Click(object sender, EventArgs e)
        {
            string action = comboBoxActualPersonalisedRoutes.Text;
            newActionValue = action[0] + "";
        }
    }
}

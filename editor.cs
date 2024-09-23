using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Capa_de_Presentación
{
    public partial class editor : Form
    {
        string directorio = "";
        public editor()
        {
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void editor_Load(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Maximized;
      
        }

        private void ventanaNuevaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            editor window = new editor();
            window.Show();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            


            texto.ResetText  ();
   
            this.Text = "nuevo archivo sin titulo";
   
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }



            TextReader abrir = new StreamReader(filePath);
            texto.Text = abrir.ReadToEnd();
            abrir.Close();
            directorio = filePath;


            this.Text = directorio;
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if(directorio == "") {
                Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "Text Files | *.txt";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        // Code to write the stream goes here.
                        myStream.Close();
                    }
                }
            }
            else {
                TextWriter guardar = new StreamWriter(directorio);
                guardar.Write(texto.Text);
                guardar.Close();
            }





        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Text Files | *.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = texto.Text;
            printDlg.Document = printDoc;
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;
            //Call ShowDialog  
            if (printDlg.ShowDialog() == DialogResult.OK) printDoc.Print();
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deshacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // SendKeys.Send("^{z}");
        }

        private void fuenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fuente.ShowDialog() == DialogResult.OK)
            {
                texto.Font= fuente.Font;
            }
        }

        private void atrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = "esta erramienta posee un conjunto de acciones similares a las acciones realizadas por editores de texto con la misma apariencia , el mismo posee n menu de navegacion con un conjunto de opciones para que puedan satisfacer las nececidades del usuario y a su vez potencial su capasidad de manupular la herramienta";
            MessageBox.Show(text);
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
    }


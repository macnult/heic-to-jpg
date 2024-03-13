using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "HEIC Files (*.heic)|*.heic";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] filePaths = openFileDialog.FileNames;  // Array of filenames

                // Clear the textbox before displaying new filenames (optional)
                textBox1.Text = "";

                bool isFirstFile = true;  // Flag to track the first file

                // Loop through filenames and display them in the textbox
                foreach (string filePath in filePaths)
                {
                    string fileName = Path.GetFileName(filePath);

                    // Formatting each file name
                    if (isFirstFile)
                    {
                        textBox1.Text += "\"" + fileName;
                        isFirstFile = false;
                    }
                    else
                    {
                        
                        textBox1.Text += ", \"" + fileName;
                    }
                }
                textBox1.Text += "\"";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // i think the convert script would go here
        }

        private void convert_Click(object sender, EventArgs e)
        {

        }
    }
}

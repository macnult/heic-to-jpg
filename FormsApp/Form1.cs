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
using ImageMagick;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace FormsApp
{
    public partial class Form1 : Form
    {
        private OpenFileDialog dialog = new OpenFileDialog(); // Declare dialog as a member variable

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dialog.Filter = "HEIC Files (*.heic)|*.heic";
            dialog.Multiselect = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string[] filePaths = dialog.FileNames; // Array of filenames

                // Clear the textbox before displaying new filenames (optional)
                textBox1.Text = "";

                bool isFirstFile = true; // Flag to track the first file

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
            // May need something later
        }

        private void convert_Click(object sender, EventArgs e)
        {
            if (dialog.FileNames.Length == 0)
            {
                MessageBox.Show("Please select HEIC files to convert.");
                return;
            }
            foreach (string filePath in dialog.FileNames)
            {
                try
                {
                    using (MagickImage image = new MagickImage(filePath))
                    {
                        string newPath = Path.ChangeExtension(filePath, ".jpg");
                        image.Quality = 100; // Adjust quality as needed (0-100)
                        image.Write(newPath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error converting {filePath}: {ex.Message}");
                }
            }
            MessageBox.Show($"All files converted to JPG successfully!");
        }  
    }
}

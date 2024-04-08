using System;
using System.IO;
using System.Windows.Forms;
using ImageMagick;


namespace FormsApp
{
    public partial class Form1 : Form
    {
        private OpenFileDialog dialog = new OpenFileDialog(); 

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            dialog.Filter = "HEIC Files (*.heic)|*.heic";
            dialog.Multiselect = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string[] filePaths = dialog.FileNames; 

                textBox1.Text = "";

                bool isFirstFile = true;
                
                // Put file names into textbox
                foreach (string filePath in filePaths)
                {
                    string fileName = Path.GetFileName(filePath);

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

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            // May need something later
        }

        private void Convert_Click(object sender, EventArgs e)
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
                    // Testing purposes
                    MagickNET.Initialize();

                    using (MagickImage image = new MagickImage(filePath))
                    {
                        string newPath = Path.ChangeExtension(filePath, ".jpg");
                        image.Quality = 100; // Adjust quality (0-100)
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

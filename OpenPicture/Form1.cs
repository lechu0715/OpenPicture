using OpenPicture.Properties;
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

namespace OpenPicture
{
    public partial class Form1 : Form
    {
        
        public string PathFileText { get; set; } = $@"{Path.GetDirectoryName(Application.ExecutablePath)}\Sciezka.txt";
        public string NewPath { get; set; } = @"";

        public Form1()
        {
            InitializeComponent();

            if (File.Exists(PathFileText))
            {
                string text = File.ReadAllText(PathFileText);
                pbPhoto.Image = new Bitmap(@text);
            }

            ButtonsVisible();

        }

        public void CreateTextFile(string _pathPhoto)
        {
            File.WriteAllText(PathFileText, _pathPhoto);
        }


        public void ButtonsVisible()
        {
            if (pbPhoto.Image == null)
            {
                btnDelete.Visible = false;
            }
            else
            {
                btnDelete.Visible = true;
            }
        }

        public void btnAddPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pbPhoto.Image = new Bitmap(open.FileName);
                pbPhoto.Image = new Bitmap(open.FileName);
                NewPath = open.FileName.ToString();

                CreateTextFile(NewPath);
            }
            ButtonsVisible();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            pbPhoto.Image = null;
            ButtonsVisible();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (pbPhoto.Image == null)
            {
                File.Delete(PathFileText);
            }
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;
using PanelTree.Models;
namespace PanelTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        PanelContext context;
        private void Form1_Load(object sender, EventArgs e)
        {
            context = new PanelContext();
            context.Init();

         
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.DefaultExt = "bmp";

            string path = "";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
               path = dialog.FileName;
               
               Image im = context.GetImage();
               im.Save(path);
                MessageBox.Show("Image saved!");
            }
        
           
         
            //  ig.DrawScene(context);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image im = context.GetImage();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = im;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

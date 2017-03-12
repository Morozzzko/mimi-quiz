using System;
using System.Drawing;
using System.Windows.Forms;

namespace MissQuiz
{
    public partial class QuizForm : Form
    {
        private ControlForm mainForm = null;

        private bool state = false;
        public Color c;

        private Bitmap current = null;
        public QuizForm()
        {
            InitializeComponent();
        }

        public QuizForm(Form callingForm)
        {
            mainForm = callingForm as ControlForm;
            InitializeComponent();
            Form2_ResizeEnd(null, null);
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private int size = 10;

        private void Form2_ResizeEnd(object sender, EventArgs e)
        {
            //create auto-resized code(image and text box scale)
            int width = this.Width - 17;
            int heigth = this.Height;
            int verical_pad = 5;//pixels
            double canvas_h = (heigth - verical_pad) * 0.8;

            double textbox_h = (heigth - verical_pad) * 0.2;
            label1.Width = width - 2 * size;
            label1.Height = -2 * size + (int)textbox_h;
            label1.Left = size;
            label1.Top = ((int)canvas_h) + verical_pad - 37 + size;
            this.Refresh();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Close();
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            mainForm.fld.Draw(g,this.Height, this.Width);

            //g = label1.CreateGraphics();
            g.DrawRectangle(new Pen(c, (float)size), label1.Left - size/2, label1.Top - size/2, label1.Width + size, label1.Height + size);
        }
    }
}

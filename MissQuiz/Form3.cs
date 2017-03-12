using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MissQuiz
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ArrayList ColorList = new ArrayList();
            Type colorType = typeof(System.Drawing.Color);
            PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static |
                                          BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (PropertyInfo c in propInfoList)
            {
                this.comboBox1.Items.Add(c.Name);
                this.comboBox2.Items.Add(c.Name);
                this.comboBox3.Items.Add(c.Name);
                this.comboBox4.Items.Add(c.Name);
                this.comboBox5.Items.Add(c.Name);
                this.comboBox6.Items.Add(c.Name);
                this.comboBox7.Items.Add(c.Name);
                this.comboBox8.Items.Add(c.Name);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string index = ((ComboBox)sender).Name.Remove(0, 8);
            string imagebox_name = "pictureBox" + index;
            PictureBox p = (PictureBox)(this.GetType().GetField(imagebox_name).GetValue(this));

            string color_name = ((ComboBox)sender).Text;
            Color c = Color.FromName(color_name);
            p.BackColor = c;
            p.Refresh();
        }
    }
}

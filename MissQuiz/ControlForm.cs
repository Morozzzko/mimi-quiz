using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MissQuiz
{
    public partial class ControlForm : Form
    {
        private int ind;
        private QuizForm child = null;

        private Int64 time;

        public Field fld = null;
        public ControlForm()
        {
            InitializeComponent();
            child = new QuizForm(this);
            child.Show();
            fld = new Field();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"Text: (\d+)", RegexOptions.IgnoreCase);
            MatchCollection mc = reg.Matches(sender.ToString());
            int index = 0;
            if (mc.Count > 0)
            {
                index = Convert.ToInt32(Regex.Replace(mc[0].Value, @"Text: (\d+)", "$1")) - 1;
            }
            //String s = fld.quests[index].quiz;

            //open card
            fld.quests[index].Visual = fld.quests[index].State;

            //get question
            /*child.label1.Text = fld.quests[index].quiz;*/
            //child.label1.BorderStyle = BorderStyle.FixedSingle;//= fld.Colors[(int)fld.quests[index].State];
            child.c = fld.Colors[(int) fld.quests[index].State];
//             Graphics g = child.label1.CreateGraphics();
//             g.DrawRectangle(new Pen(fld.Colors[(int)fld.quests[index].State],5.0f),0,0,child.label1.Width, child.label1.Height );

            //textBox1.Text = fld.quests[index].quiz;
            /*label1.Text = fld.quests[index].quiz;*/
            ind = index;

            child.Refresh();
        }

        private void button_cln_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            child.label1.Text = "";
            child.label1.BackColor = BackColor;
            child.c = Color.DarkGray;
            child.Refresh();
        }

        private void button_show_Click(object sender, EventArgs e)
        {
            ShowTimer.Interval = 15000;//<FIXME>
            ShowTimer.Enabled = true;

            for (int i = 0; i < 45; i++)
            {
                fld.quests[i].Visual = fld.quests[i].State;
            }

            child.Refresh();

            //time = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

        private void ShowTimer_Tick(object sender, EventArgs e)
        {
            ShowTimer.Enabled = false;

            for (int i = 0; i < 45; i++)
            {
                fld.quests[i].Visual = Miss.Closed;
            }

            child.Refresh();

            time = DateTime.Now.Ticks/TimeSpan.TicksPerMillisecond - time;
            //textBox1.Text = time.ToString();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            child.ControlBox = !child.ControlBox;
            child.WindowState = FormWindowState.Maximized;
            child.Refresh();
        }

        private void button47_Click(object sender, EventArgs e)
        {
            //<FIXME>
            label1.Text = fld.quests[ind].Text;
            child.label1.Text = fld.quests[ind].Text;
        }

        private void button48_Click(object sender, EventArgs e)
        {
            //<FIXME>
            child.label1.Text = fld.quests[ind].Answer;
        }

        private void button49_Click(object sender, EventArgs e)
        {
            Form3 testform = new Form3();
            testform.Show();
        }
    }
}

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

            //open card

            Question question = (Question) fld.Questions[index];
            question.isVisible = true;

            //get question
            /*child.label1.Text = fld.quests[index].quiz;*/
            //child.label1.BorderStyle = BorderStyle.FixedSingle;//= fld.Colors[(int)fld.quests[index].State];
            child.c = fld.Colors[(int) question.Difficulty];
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
            child.questionPicture.Visible = false;
            child.Refresh();
        }

        private void button_show_Click(object sender, EventArgs e)
        {
            ShowTimer.Interval = 15000;//<FIXME>
            ShowTimer.Enabled = true;

            for (int i = 0; i < 45; i++)
            {
                Question question = (Question) fld.Questions[i];
                question.isVisible = true;
            }

            child.Refresh();

            //time = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

        private void ShowTimer_Tick(object sender, EventArgs e)
        {
            ShowTimer.Enabled = false;

            for (int i = 0; i < 45; i++)
            {
                Question question = (Question) fld.Questions[i];
                question.isVisible = false;
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
            // show question
            Question question = (Question) fld.Questions[ind];
            if (question.Text[0] == '.') // image?
            {
                child.questionPicture.ImageLocation = question.Text;
                child.questionPicture.Visible = true;
            }
            else
            {

                label1.Text = question.Text;
                child.label1.Text = question.Text;
            }
        }

        private void button48_Click(object sender, EventArgs e)
        {
            //<FIXME>
            Question question = (Question)fld.Questions[ind];
            child.label1.Text = question.Answer;
        }
    }
}

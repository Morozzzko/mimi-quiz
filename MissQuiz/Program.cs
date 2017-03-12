using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections;

namespace MissQuiz
{
    static class Program
    {
        public static int State = 0;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ControlForm());
        }
    }

    public enum Difficulty
    {
        None,
        Easy,
        Medium,
        Hard
    }
    
    public class Question
    {

        public string Answer { get; set; }
        public string Text { get; set; }

        public Boolean isVisible { get; set; }

        public Difficulty Difficulty { get; set; }

        public Question(string text, string answer, Difficulty difficulty)
        {
            Text = text;
            Answer = answer;
            Difficulty = difficulty;
            isVisible = false;
        }
    }

    public class Field
    {

        public ArrayList Questions { get; private set; }

        public Color[] Colors = { Color.LightGray, Color.Green, Color.Yellow, Color.Red };

        public Field()
        {
            Questions = new ArrayList(45);
            string[] QuestionLines = File.ReadAllLines(@"questions.txt");
            string[] AnswerLines = File.ReadAllLines(@"answers.txt");
            string[] DifficultyLines = File.ReadAllLines(@"difficulty.txt");

            for (UInt16 i = 0; i < 45; i++)
            {
                Enum.TryParse(DifficultyLines[i], true, out Difficulty difficulty);
                Questions.Add(new Question(QuestionLines[i], AnswerLines[i], difficulty));
            }
        }

        public void Draw(Graphics g, int H, int W)
        {
            //Graphics g = pb.CreateGraphics();
            
            int TotalHeight = H - 35;
            int TotalWidth = W - 17;
            float BlockWidth = TotalWidth/9.0f;
            float BlockHeight = TotalHeight * 0.78f / 5.0f;

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            
            for (int i = 0; i < 45; i++)
            {
                //draw block
                int IndexY = i / 9;
                int IndexX = i % 9;
                float PositionX = BlockWidth * IndexX;
                float PositionY = BlockHeight * IndexY;
                Question question = (Question) Questions[i];
                SolidBrush color = (question.isVisible) 
                    ? new SolidBrush(Colors[(int) question.Difficulty])
                    : new SolidBrush(Colors[0]);

                g.FillRectangle(color, new RectangleF(PositionX,PositionY,BlockWidth,BlockHeight));

                g.DrawString((i + 1).ToString(), new Font("Georgia", 32), new SolidBrush(Color.Black),
                    new RectangleF(PositionX, PositionY, BlockWidth, BlockHeight), stringFormat);
            }

            for (int i = 0; i < 10; i++)
            {
                g.DrawLine(new Pen(Color.Black), i * BlockWidth, 0.0f, i * BlockWidth, BlockHeight * 5);
            }

            for (int i = 0; i < 6; i++)
            {
                g.DrawLine(new Pen(Color.Black), 0.0f, i * BlockHeight, BlockWidth * 9, i * BlockHeight);
            }

        }
    }
}

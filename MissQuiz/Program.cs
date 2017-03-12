using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

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
        Easy,
        Medium,
        Hard
    }

    public enum Miss
    {
        Closed = 0,
        Common = 1,
        First = 2,
        Second = 3,
        Third = 4,
        Fourth = 5,
        Fifth = 6,
        Sixth = 7,
        Seventh = 8,
        Eighth = 9
    }

    public class Question
    {
        public Miss State;
        public Miss Visual = Miss.Closed;

        public string Answer { get; set; }
        public string Text { get; set; }

        public Difficulty Difficulty { get; set; }

        public Question(string text, Miss miss, string answer)
        {
            Text = text;
            Answer = answer;
            State = miss;
            Difficulty = Difficulty.Easy;
        }

        public Question(string text, string answer, Difficulty difficulty)
        {
            Text = text;
            Answer = answer;
            State = Miss.Common;
            Difficulty = difficulty;
        }
    }

    public class Field
    {
        public Question[] quests;

        public Color[] Colors = { Color.DarkGray, Color.White, Color.DodgerBlue, Color.Chartreuse, Color.Magenta,
                                  Color.Red, Color.Yellow, Color.DarkOrange, Color.Cyan, Color.Green };

        public Field()
        {
            string[] lines = File.ReadAllLines(@"quiz.txt");
            string[] lines_ans = File.ReadAllLines(@"ans.txt");
            quests = new Question[45];
            //open file with quiz
            for (int i = 0; i < 45; i++)
            {
                Miss curr_m = Miss.Common;
                //2016 version
                switch (i)
                {
                    case 9:
                    case 22:
                    case 25:
                    case 29:
                    case 43:
                        curr_m = Miss.Common;
                        break;
                    case 5:
                    case 11:
                    case 30:
                    case 35:
                    case 42:
                        curr_m = Miss.First;
                        break;
                    case 6:
                    case 10:
                    case 21:
                    case 41:
                    case 34:
                        curr_m = Miss.Second;
                        break;
                    case 1:
                    case 7:
                    case 12:
                    case 28:
                    case 33:
                        curr_m = Miss.Third;
                        break;
                    case 13:
                    case 16:
                    case 20:
                    case 32:
                    case 37:
                        curr_m = Miss.Fourth;
                        break;
                    case 3:
                    case 14:
                    case 17:
                    case 27:
                    case 39:
                        curr_m = Miss.Fifth;
                        break;
                    case 2:
                    case 15:
                    case 19:
                    case 26:
                    case 40:
                        curr_m = Miss.Sixth;
                        break;
                    case 8:
                    case 18:
                    case 24:
                    case 31:
                    case 36:
                        curr_m = Miss.Seventh;
                        break;
                    case 0:
                    case 4:
                    case 23:
                    case 38:
                    case 44:
                        curr_m = Miss.Eighth;
                        break;
                }

                //2015 version
//                 switch (i)
//                 {
//                     case 18:
//                     case 7:
//                     case 34:
//                     case 21:
//                     case 37:
//                         curr_m = miss.Common;
//                         break;
//                     case 6:
//                     case 13:
//                     case 28:
//                     case 35:
//                     case 10:
//                         curr_m = miss.First;
//                         break;
//                     case 0:
//                     case 11:
//                     case 22:
//                     case 43:
//                     case 38:
//                         curr_m = miss.Second;
//                         break;
//                     case 8:
//                     case 15:
//                     case 2:
//                     case 32:
//                     case 39:
//                         curr_m = miss.Third;
//                         break;
//                     case 3:
//                     case 9:
//                     case 16:
//                     case 23:
//                     case 36:
//                         curr_m = miss.Fourth;
//                         break;
//                     case 4:
//                     case 24:
//                     case 26:
//                     case 30:
//                     case 42:
//                         curr_m = miss.Fifth;
//                         break;
//                     case 19:
//                     case 25:
//                     case 14:
//                     case 31:
//                     case 44:
//                         curr_m = miss.Sixth;
//                         break;
//                     case 17:
//                     case 20:
//                     case 1:
//                     case 41:
//                     case 27:
//                         curr_m = miss.Seventh;
//                         break;
//                     case 5:
//                     case 40:
//                     case 12:
//                     case 29:
//                     case 33:
//                         curr_m = miss.Eighth;
//                         break;
//                 }

                //                 if (i > 4 && i < 10)
                //                     curr_m = miss.First;
                //                 if (i > 9 && i < 15)
                //                     curr_m = miss.Second;
                //                 if (i > 14 && i < 20)
                //                     curr_m = miss.Third;
                //                 if (i > 19 && i < 25)
                //                     curr_m = miss.Fourth;
                //                 if (i > 24 && i < 30)
                //                     curr_m = miss.Fifth;
                //                 if (i > 29 && i < 35)
                //                     curr_m = miss.Sixth;
                //                 if (i > 34 && i < 40)
                //                     curr_m = miss.Seventh;
                //                 if (i > 39)
                //                     curr_m = miss.Eighth;
                quests[i] = new Question(lines[i], curr_m, lines_ans[i]);
                //init to question
                //quests[i].init(lines[i],curr_m, lines_ans[i]);
            }

            //mix
//             var random = new Random();
//             for (int i = 0; i < 100000; i++)
//             {
//                 int ind1 = random.Next()%45;
//                 int ind2 = random.Next()%45;
//                 if (ind1 == ind2)
//                     continue;
// 
//                 question tmp;
//                 tmp = quests[ind1];
//                 quests[ind1] = quests[ind2];
//                 quests[ind2] = tmp;
//             }
        }

        public void Draw(Graphics g, int H, int W)
        {
            //Graphics g = pb.CreateGraphics();
            
            int h = H-35;
            int w = W - 17;
            float w_each = w/9.0f;
            float h_each = h * 0.78f / 5.0f;

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            for (int i = 0; i < 45; i++)
            {
                //draw block
                int ind_y = i/9;
                int ind_x = i%9;
                float x = w_each * ind_x;
                float y = h_each * ind_y;
                g.FillRectangle(new SolidBrush(Colors[(int)quests[i].Visual]),new RectangleF(x,y,w_each,h_each) );

                g.DrawString((i + 1).ToString(), new Font("Georgia", 32), new SolidBrush(Color.Black),
                    new RectangleF(x, y, w_each, h_each), stringFormat);
            }

            for (int i = 0; i < 10; i++)
            {
                g.DrawLine(new Pen(Color.Black), i * w_each, 0.0f, i * w_each, h_each*5);
            }

            for (int i = 0; i < 6; i++)
            {
                g.DrawLine(new Pen(Color.Black), 0.0f, i * h_each, w_each*9, i * h_each);
            }

        }
    }
}

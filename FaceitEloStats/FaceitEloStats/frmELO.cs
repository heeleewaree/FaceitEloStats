using System;
using System.Drawing;
using System.Windows.Forms;
using static FaceitEloStats.Stats;

namespace FaceitEloStats
{
    public partial class frmELO : Form
    {
        public frmELO()
        {
            InitializeComponent();
            PaintFunction();
        }

        #region Paint Function
        public void PaintFunction()
        {
            try
            {
                Bitmap btmp = new Bitmap(this.Width, this.Height);
                Graphics gr = Graphics.FromImage(btmp);
                pbGraph.Image = btmp;
                int X = 50;
                int Y = this.Height - 30;
                int scale = 3;
                int textX = 735;
                int textY = 18;

                gr.DrawLine(new Pen(Color.White), new Point(X, Y), new Point(X + 670, Y));
                gr.DrawLine(new Pen(Color.White), new Point(X, Y), new Point(X, 20));
                gr.DrawLine(new Pen(Color.White), new Point(X + 670, Y), new Point(X + 670, 20));
                gr.DrawLine(new Pen(Color.White), new Point(X + 670, 20), new Point(X, 20));


                #region Elo Lines
                int scaleY = 700 / ((matches * 3) / 2);
                for (int i = 1; i < matches; i++)
                    gr.DrawLine(new Pen(Color.White), new Point(X + (scaleY * (i)), Y + 250 - (elo[i] / scale)), new Point(X + (scaleY * (i - 1)), Y + 250 - (elo[i - 1] / scale)));
                #endregion

                #region Skill Level Elo Lines
                int[] ELO = new int[10] { 1, 801, 951, 1101, 1251, 1401, 1551, 1701, 1851, 2001 };
                SolidBrush brush = new SolidBrush(Color.White);
                for (int i = 1; i < 10; i++)
                {
                    Pen pen = new Pen(Color.White);
                    if (i + 1 < 4)
                    {
                        brush.Color = Color.Green;
                        pen.Color = Color.Green;
                    }
                    else if (i + 1 < 8)
                    {
                        brush.Color = Color.Orange;
                        pen.Color = Color.Orange;
                    }
                    else
                    {
                        brush.Color = Color.Red;
                        pen.Color = Color.Red;
                    }

                    gr.DrawLine(pen, new Point(X - 5, Y + 250 - (ELO[i] / scale)), new Point(X + 670, Y + 250 - (ELO[i] / scale)));
                    gr.DrawString(Convert.ToString(i + 1), new Font("Arial", 8), brush, new Point(X - 25, Y + 245 - (ELO[i] / scale)));
                }
                #endregion

                #region Max Elo Point
                int maxElo = elo[0];
                int numMaxElo = 0;
                for (int i = 0; i < matches; i++)
                {
                    if (elo[i] >= maxElo)
                    {
                        maxElo = elo[i];
                        numMaxElo = i;
                    }
                }
                gr.FillEllipse(new SolidBrush(Color.DeepPink), new Rectangle(X + (scaleY * (numMaxElo)) - 2, (int)(Y + 250 - (maxElo / scale) - 2), 4, 4));
                #endregion

                #region Calculating Values
                int worstElo = elo[0];
                int bestElo = elo[0];
                int interval = 15;
                int wins = 0;
                for (int i = 0; i < matches; i++)
                {
                    if (elo[i] < worstElo)
                        worstElo = elo[i];
                    if (elo[i] > bestElo)
                        bestElo = elo[i];
                    if (result[i] == "win")
                        wins++;
                }
                int lvl = 0;
                int stillElo = 0;
                double stillGames = 0;
                for (int i = 0; i < 10; i++)
                {
                    if (elo[matches - 1] < ELO[i])
                    {
                        lvl = i;
                        stillElo = ELO[i] - elo[matches - 1];
                        stillGames = Math.Round(stillElo / 25.0, 0);
                        break;
                    }
                }
                #endregion

                #region Text
                gr.DrawString("Worst: " + Convert.ToString(worstElo), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY + interval * 2));
                gr.DrawString("Best: " + Convert.ToString(bestElo), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY + interval * 3));
                gr.DrawString("Now: " + Convert.ToString(elo[matches - 1]), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY + interval));
                gr.DrawString("Lvl: " + Convert.ToString(lvl), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY));
                gr.DrawString("Still elo: " + Convert.ToString(stillElo), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY + interval * 8));
                gr.DrawString("Still wins: " + Convert.ToString(stillGames), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY + interval * 9));
                gr.DrawString("Win rate: " + Convert.ToString(Math.Round(100.0 * wins / (matches), 3) + "%"), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY + interval * 7));
                gr.DrawString("Total games: " + Convert.ToString(matches), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY + interval * 4));
                gr.DrawString("Total wins: " + Convert.ToString(wins), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY + interval * 5));
                gr.DrawString("Total losses: " + Convert.ToString(matches - wins), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY + interval * 6));
                //gr.DrawString("Still games: " + Convert.ToString(Math.Round(stillGames / (1.0 * wins / (matches)), 0)), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY + interval * 10));
                #endregion

                #region Wins Line
                gr.DrawLine(new Pen(Color.White), new Point(textX, Y), new Point(textX + 135, Y));
                gr.DrawLine(new Pen(Color.White), new Point(textX, Y - 30), new Point(textX + 135, Y - 30));
                gr.DrawLine(new Pen(Color.White), new Point(textX, Y), new Point(textX, Y - 30));
                gr.DrawLine(new Pen(Color.White), new Point(textX + 135, Y), new Point(textX + 135, Y - 30));

                int winLine = 5;
                for (int i = matches - 1; i > matches - 6; i--)
                {
                    if (result[i] == "win")
                        gr.DrawString("W", new Font("Arial", 12), new SolidBrush(Color.Green), new Point(textX - 23 + (27 * winLine), Y - 23));
                    else
                        gr.DrawString("L", new Font("Arial", 12), new SolidBrush(Color.Red), new Point(textX - 23 + (27 * winLine) + 3, Y - 23));

                    winLine--;
                }
                #endregion

                #region Skill Level
                float minAngle = 156.0f;
                float maxAngle = 228.0f;
                SolidBrush skillLevelBrush = new SolidBrush(Color.Green);
                if (lvl < 2)
                    skillLevelBrush.Color = Color.White;
                else if (lvl < 4)
                    skillLevelBrush.Color = Color.Green;
                else if (lvl < 8)
                    skillLevelBrush.Color = Color.DarkOrange;
                else
                    skillLevelBrush.Color = Color.Red;

                float angle = lvl * (maxAngle / 10.0f);

                int correction = 40;

                gr.FillPie(skillLevelBrush, new Rectangle(textX + 1, Y - 200 + 1 + correction, 134, 133), minAngle, angle);
                gr.DrawPie(new Pen(Color.LightGray, 2), new Rectangle(textX, Y - 200 + correction, 135, 135), minAngle, maxAngle);
                gr.DrawPie(new Pen(Color.LightGray, 2), new Rectangle(textX + 13, Y - 200 + 13 + correction, 110, 110), minAngle, maxAngle);
                gr.DrawLine(new Pen(Color.LightGray, 2), new Point(textX + 1, Y - 200 + 70 + correction), new Point(textX + 135, Y - 200 + 70 + correction));
                gr.FillEllipse(new SolidBrush(Color.FromArgb(20, 20, 20)), new Rectangle(textX + 14, Y - 200 + 14 + correction, 108, 108));
                
                if (lvl != 10)
                    gr.DrawString(Convert.ToString(lvl), new Font("Arial", 55), skillLevelBrush, new Point(textX + 36, Y - 200 + 30 + correction));
                else
                    gr.DrawString(Convert.ToString(lvl), new Font("Arial", 55), skillLevelBrush, new Point(textX + 36 - 23, Y - 200 + 30 + correction));

                #endregion

                gr.Dispose();
            }
            catch
            {
                return;
            }
        }
        #endregion
    }
}

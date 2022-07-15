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
                gr.DrawLine(new Pen(Color.White), new Point(X, Y), new Point(X + 670, Y));
                gr.DrawLine(new Pen(Color.White), new Point(X, Y), new Point(X, 20));
                gr.DrawLine(new Pen(Color.White), new Point(X + 670, Y), new Point(X + 670, 20));
                gr.DrawLine(new Pen(Color.White), new Point(X + 670, 20), new Point(X, 20));

                int scaleY = 700 / ((matches * 3) / 2);
                for (int i = 1; i < matches; i++)
                    gr.DrawLine(new Pen(Color.White), new Point(X + (scaleY * (i)), Y + 250 - (elo[i] / scale)), new Point(X + (scaleY * (i - 1)), Y + 250 - (elo[i - 1] / scale)));

                int[] ELO = new int[10] { 1, 801, 951, 1101, 1251, 1401, 1551, 1701, 1851, 2001 };
                for (int i = 1; i < 10; i++)
                {
                    SolidBrush brush = new SolidBrush(Color.White);
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

                int textX = 735;
                int textY = 18;
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

                gr.DrawString("Worst: " + Convert.ToString(worstElo), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY + interval * 2));
                gr.DrawString("Best: " + Convert.ToString(bestElo), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY + interval * 3));
                gr.DrawString("Now: " + Convert.ToString(elo[matches - 1]), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY + interval));
                gr.DrawString("Lvl: " + Convert.ToString(lvl), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY));
                gr.DrawString("Still elo: " + Convert.ToString(stillElo), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY + interval * 4));
                gr.DrawString("Still games: " + Convert.ToString(stillGames), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY + interval * 5));
                gr.DrawString("Win rate: " + Convert.ToString(Math.Round(100.0 * wins / (matches), 3) + "%"), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY + interval * 6));
                gr.DrawString("Total games: " + Convert.ToString(matches), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY + interval * 7));
                gr.DrawString("Total wins: " + Convert.ToString(wins), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY + interval * 8));
                gr.DrawString("Total losses: " + Convert.ToString(matches - wins), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY + interval * 9));

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

using System;
using System.Drawing;
using System.Windows.Forms;
using static FaceitEloStats.Stats;


namespace FaceitEloStats
{
    public partial class frmKD : Form
    {
        public frmKD()
        {
            InitializeComponent();
            PaintFunction();
        }

        #region Paint Function
        public void PaintFunction()
        {
            Bitmap btmp = new Bitmap(this.Width, this.Height);
            Graphics gr = Graphics.FromImage(btmp);
            pbGraph.Image = btmp;
            int X = 50;
            int Y = this.Height - 30;
            int scale = 100;
            gr.DrawLine(new Pen(Color.White), new Point(X, Y), new Point(X + 670, Y));
            gr.DrawLine(new Pen(Color.White), new Point(X, Y), new Point(X, 20));
            gr.DrawLine(new Pen(Color.White), new Point(X + 670, Y), new Point(X + 670, 20));
            gr.DrawLine(new Pen(Color.White), new Point(X + 670, 20), new Point(X, 20));

            int totalKills = 0;
            int totalDeaths = 0;
            int totalAssists = 0;
            double[] kd = new double[matches];
            double averageKd = 0;
            for (int i = 0; i < matches; i++)
            {
                totalKills += kills[i];
                totalDeaths += deaths[i];
                totalAssists += assists[i];
                kd[i] = Math.Round(1.0 * kills[i] / deaths[i], 3);
            }
            for (int i = 0; i < matches; i++)
            {
                averageKd += kd[i];
            }
            averageKd = averageKd / matches;

            int scaleY = 700 / ((matches * 3) / 2);
            for (int i = 1; i < matches; i++)
                gr.DrawLine(new Pen(Color.White), new Point(X + (scaleY * (i)), Y + 33 - (int)(kd[i] * scale)), new Point(X + (scaleY * (i - 1)), Y + 33 - (int)(kd[i - 1] * scale)));

            double[] KD = new double[10] { 0.5, 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5 };
            for (int i = 0; i < 9; i++)
            {
                SolidBrush brush = new SolidBrush(Color.White);
                Pen pen = new Pen(Color.White);
                if (i + 1 < 3)
                {
                    brush.Color = Color.Green;
                    pen.Color = Color.Green;
                }
                else if (i + 1 < 7)
                {
                    brush.Color = Color.Orange;
                    pen.Color = Color.Orange;
                }
                else
                {
                    brush.Color = Color.Red;
                    pen.Color = Color.Red;
                }

                gr.DrawLine(pen, new Point(X - 5, Y + 33 - (int)(KD[i] * scale)), new Point(X + 670, Y + 33 - (int)(KD[i] * scale)));
                gr.DrawString(Convert.ToString(KD[i]), new Font("Arial", 8), brush, new Point(X - 35, Y + 28 - (int)(KD[i] * scale)));
            }

            int textX = 735;
            int textY = 18;
            double worstKd = kd[0];
            double bestKd = kd[0];
            int interval = 15;
            for (int i = 0; i < matches; i++)
            {
                if (kd[i] < worstKd)
                    worstKd = kd[i];
                if (kd[i] > bestKd)
                    bestKd = kd[i];
            }
            double avg = 0;
            for (int i = matches - 20; i < matches; i++)
            {
                avg += kills[i];
            }

            gr.DrawString("Worst: " + Convert.ToString(worstKd), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY));
            gr.DrawString("Best: " + Convert.ToString(bestKd), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY + interval));
            gr.DrawString("Average: " + Convert.ToString(Math.Round(averageKd, 3)), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY + interval * 2));
            gr.DrawString("Total kills: " + Convert.ToString(totalKills), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY + interval * 3));
            gr.DrawString("Total deaths: " + Convert.ToString(totalDeaths), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY + interval * 4));
            gr.DrawString("Total assists: " + Convert.ToString(totalAssists), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY + interval * 5));
            gr.DrawString("Total avg: " + Convert.ToString(Math.Round(1.0 * totalKills / matches, 3)), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY + interval * 6));
            gr.DrawString("Avg: " + Convert.ToString(Math.Round(1.0 * avg / 20, 3)), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY + interval * 7));
            gr.DrawLine(new Pen(Color.Blue), new Point(X + 670, Y + 33 - (int)((Math.Round(1.0 * averageKd, 3)) * scale)), new Point(X + 460, Y + 33 - (int)((Math.Round(1.0 * averageKd, 3)) * scale)));
            gr.DrawString(Convert.ToString(Math.Round(1.0 * averageKd, 3)), new Font("Arial", 8), new SolidBrush(Color.Blue), new Point(X + 675, Y + 27 - (int)((Math.Round(1.0 * averageKd, 3)) * scale)));


            gr.Dispose();
        }
        #endregion
    }
}

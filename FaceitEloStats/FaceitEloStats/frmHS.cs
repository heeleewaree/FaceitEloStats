using System;
using System.Drawing;
using System.Windows.Forms;
using static FaceitEloStats.Stats;

namespace FaceitEloStats
{
    public partial class frmHS : Form
    {
        public frmHS()
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
                int scale = 5;
                gr.DrawLine(new Pen(Color.White), new Point(X, Y), new Point(X + 670, Y));
                gr.DrawLine(new Pen(Color.White), new Point(X, Y), new Point(X, 20));
                gr.DrawLine(new Pen(Color.White), new Point(X + 670, Y), new Point(X + 670, 20));
                gr.DrawLine(new Pen(Color.White), new Point(X + 670, 20), new Point(X, 20));

                int scaleY = 700 / ((matches * 3) / 2);
                for (int i = 1; i < matches; i++)
                    gr.DrawLine(new Pen(Color.White), new Point(X + (scaleY * (i)), Y + 33 - (hs[i] * scale)), new Point(X + (scaleY * (i - 1)), Y + 33 - (hs[i - 1] * scale)));

                int[] HS = new int[10] { 0, 10, 20, 30, 40, 50, 60, 70, 80, 90 };
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

                    gr.DrawLine(pen, new Point(X - 5, Y + 33 - (HS[i] * scale)), new Point(X + 670, Y + 33 - (HS[i] * scale)));
                    gr.DrawString(Convert.ToString(i * 10) + "%", new Font("Arial", 8), brush, new Point(X - 35, Y + 28 - (HS[i] * scale)));
                }

                #region Max HS Point
                int maxHs = hs[0];
                int numMaxHs = 0;
                for (int i = 0; i < matches; i++)
                {
                    if (hs[i] >= maxHs)
                    {
                        maxHs = hs[i];
                        numMaxHs = i;
                    }
                }
                gr.FillEllipse(new SolidBrush(Color.DeepPink), new Rectangle(X + (scaleY * numMaxHs) - 2, (int)((Y + 33 - (maxHs * scale)) - 2), 4, 4));
                #endregion

                int textX = 735;
                int textY = 18;
                int worstHs = hs[0];
                int bestHs = hs[0];
                int interval = 15;
                int headShotsPercentage = 0;
                for (int i = 0; i < matches; i++)
                {
                    if (hs[i] < worstHs)
                        worstHs = hs[i];
                    if (hs[i] > bestHs)
                        bestHs = hs[i];
                    headShotsPercentage += hs[i];
                }

                gr.DrawString("Worst: " + Convert.ToString(worstHs) + "%", new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY));
                gr.DrawString("Best: " + Convert.ToString(bestHs) + "%", new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY + interval));
                gr.DrawString("Average: " + Convert.ToString(Math.Round(1.0 * headShotsPercentage / (matches), 3) + "%"), new Font("Arial", 9), new SolidBrush(Color.White), new Point(textX, textY + interval * 2));
                gr.DrawLine(new Pen(Color.Blue), new Point(X + 670, Y + 33 - (int)(Math.Round(1.0 * headShotsPercentage / (matches), 3)) * scale), new Point(X + 460, Y + 33 - (int)(Math.Round(1.0 * headShotsPercentage / (matches), 3)) * scale));
                gr.DrawString(Convert.ToString(Math.Round(1.0 * headShotsPercentage / (matches), 3) + "%"), new Font("Arial", 8), new SolidBrush(Color.Blue), new Point(X + 675, Y + 27 - (int)(Math.Round(1.0 * headShotsPercentage / (matches), 3)) * scale));

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

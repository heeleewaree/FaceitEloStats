using System;
using System.Windows.Forms;
using System.IO;
using static FaceitEloStats.Stats;
using System.Diagnostics;

namespace FaceitEloStats
{
    public partial class frmAddGames : Form
    {
        public frmAddGames()
        {
            InitializeComponent();
            dataGridView1.RowCount = 1000;
            InitialDesign();
        }

        #region Global Vars

        String[] line = new String[1000];

        #endregion

        #region Initial Design
        public void InitialDesign()
        {
            int i = 1;
            try
            {
                StreamReader file = new StreamReader(@"C:\FaceitElo Stats\config.cfg");
                line[0] = file.ReadLine();
                while ((line[i - 1] != "") && (i < 998))
                {
                    String _line = line[i - 1];
                    String _cell = "";
                    int check = 0;
                    int p = 0;
                    if (_line != null)
                    {
                        for (int j = 0; j < _line.Length; j++)
                        {
                            if ((_line[j] == '\t') && (check == 0))
                            {
                                for (int k = p; k < j; k++)
                                {
                                    _cell += _line[k];
                                }
                                dataGridView1.Rows[i - 1].Cells[0].Value = _cell;
                                check = 1;
                                _cell = null;
                                j++;
                                p = j;
                            }

                            if ((_line[j] == '\t') && (check == 1))
                            {
                                for (int k = p; k < j; k++)
                                {
                                    _cell += _line[k];
                                }
                                dataGridView1.Rows[i - 1].Cells[1].Value = _cell;
                                kills[i - 1] = Convert.ToInt32(_cell);
                                check = 2;
                                _cell = null;
                                j++;
                                p = j;
                            }

                            if ((_line[j] == '\t') && (check == 2))
                            {
                                for (int k = p; k < j; k++)
                                {
                                    _cell += _line[k];
                                }
                                dataGridView1.Rows[i - 1].Cells[2].Value = _cell;
                                deaths[i - 1] = Convert.ToInt32(_cell);
                                check = 3;
                                _cell = null;
                                j++;
                                p = j;
                            }

                            if ((_line[j] == '\t') && (check == 3))
                            {
                                for (int k = p; k < j; k++)
                                {
                                    _cell += _line[k];
                                }
                                dataGridView1.Rows[i - 1].Cells[3].Value = _cell;
                                assists[i - 1] = Convert.ToInt32(_cell);
                                check = 4;
                                _cell = null;
                                j++;
                                p = j;
                            }

                            if ((_line[j] == '\t') && (check == 4))
                            {
                                for (int k = p; k < j; k++)
                                {
                                    _cell += _line[k];
                                }
                                dataGridView1.Rows[i - 1].Cells[4].Value = _cell;
                                hs[i - 1] = Convert.ToInt32(_cell);
                                check = 5;
                                _cell = null;
                                j++;
                                p = j;
                            }

                            if ((_line[j] == '\t') && (check == 5))
                            {
                                for (int k = p; k < j; k++)
                                {
                                    _cell += _line[k];
                                }
                                dataGridView1.Rows[i - 1].Cells[5].Value = _cell;
                                result[i - 1] = _cell;
                                check = 6;
                                _cell = null;
                                j++;
                                p = j;
                            }

                            if ((_line[j] == '\t') && (check == 6))
                            {
                                for (int k = p; k < j; k++)
                                {
                                    _cell += _line[k];
                                }
                                dataGridView1.Rows[i - 1].Cells[6].Value = _cell;
                                elo[i - 1] = Convert.ToInt32(_cell);
                                check = 7;
                            }
                        }
                    }
                    line[i] = file.ReadLine();
                    i++;
                }
                file.Close();
                int x = 0;
                while (elo[x] != 0)
                {
                    x++;
                }
                matches = x;
            }
            catch
            {
                return;
            }
        }
        #endregion

        #region Saving Stats To File
        public void SavingStats()
        {
            try
            {
                StreamWriter file = new StreamWriter(@"C:\FaceitElo Stats\config.cfg");
                for (int i = 0; i < 998; i++)
                {
                    file.WriteLine(dataGridView1.Rows[i].Cells[0].Value + "\t" + dataGridView1.Rows[i].Cells[1].Value + "\t" + dataGridView1.Rows[i].Cells[2].Value + "\t" + dataGridView1.Rows[i].Cells[3].Value + "\t" + dataGridView1.Rows[i].Cells[4].Value + "\t" + dataGridView1.Rows[i].Cells[5].Value + "\t" + dataGridView1.Rows[i].Cells[6].Value + "\t");
                }

                file.Close();
            }
            catch
            {
                return;
            }
        }
        #endregion

        #region Button Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            SavingStats();
            InitialDesign();
            this.Close();
        }
        #endregion
    }
}

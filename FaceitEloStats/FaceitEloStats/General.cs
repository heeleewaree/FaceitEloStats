using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static FaceitEloStats.Stats;

namespace FaceitEloStats
{
    public partial class General : Form
    {
        public General()
        {
            InitializeComponent();
            this.Text = "FaceitElo Stats";
            this.BackColor = Color.FromArgb(20, 20, 20);
            this.Width = 900;
            this.Height = 600;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            UsingClass();

            #region Version
            lblVersion.Text = "version 1.4.8";
            lblVersion.Location = new Point(lblVersion.Location.X - 25, lblVersion.Location.Y);
            #endregion
        }


        #region Global Vars

        String[] line = new String[maxGames];
        bool formEloIsOpen = false;
        bool formKdIsOpen = false;
        bool formHsIsOpen = false;
        bool formAddGamesIsOpen = false;

        #endregion

        #region Using Class
        public void UsingClass()
        {
            int i = 1;
            try
            {
                StreamReader file = new StreamReader(@"C:\FaceitElo Stats\config.cfg");
                line[0] = file.ReadLine();
                while ((line[i - 1] != "") && (i < maxGames - 2))
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

        #region Open SubForm
        private new Form ActiveForm = null;
        private void OpenSubForm(Form SubForm)
        {
            if (ActiveForm != null)
                ActiveForm.Close();
            ActiveForm = SubForm;
            SubForm.TopLevel = false;
            SubForm.FormBorderStyle = FormBorderStyle.None;
            SubForm.Dock = DockStyle.Fill;
            SubFormPanel.Controls.Add(SubForm);
            SubFormPanel.Tag = SubForm;
            SubForm.BringToFront();
            SubForm.Show();
        }
        #endregion

        #region Button Add Games
        private void btnAddGames_Click(object sender, EventArgs e)
        {
            if (formAddGamesIsOpen)
            {
                ActiveForm.Close();
                formAddGamesIsOpen = false;
            }
            else
            {
                OpenSubForm(new frmAddGames());
                formAddGamesIsOpen = true;
                formEloIsOpen = false;
                formHsIsOpen = false;
                formKdIsOpen = false;
            }
        }
        #endregion

        #region Button ELO
        private void btnElo_Click(object sender, EventArgs e)
        {
            if (formEloIsOpen)
            {
                ActiveForm.Close();
                formEloIsOpen = false;
            }
            else
            {
                OpenSubForm(new frmELO());
                formEloIsOpen = true;
                formHsIsOpen = false;
                formKdIsOpen = false;
                formAddGamesIsOpen = false;
            }
        }
        #endregion

        #region Button HS
        private void btnHs_Click(object sender, EventArgs e)
        {
            if (formHsIsOpen)
            {
                ActiveForm.Close();
                formHsIsOpen = false;
            }
            else
            {
                OpenSubForm(new frmHS());
                formHsIsOpen = true;
                formKdIsOpen = false;
                formAddGamesIsOpen = false;
                formEloIsOpen = false;
            }
        }
        #endregion

        #region Button KD
        private void btnKD_Click(object sender, EventArgs e)
        {
            if (formKdIsOpen)
            {
                ActiveForm.Close();
                formKdIsOpen = false;
            }
            else
            {
                OpenSubForm(new frmKD());
                formKdIsOpen = true;
                formAddGamesIsOpen = false;
                formEloIsOpen = false;
                formHsIsOpen = false;
            }
        }
        #endregion
    }
}

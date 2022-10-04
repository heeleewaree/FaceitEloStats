
namespace FaceitEloStats
{
    partial class General
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(General));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnKD = new System.Windows.Forms.Button();
            this.btnAddGames = new System.Windows.Forms.Button();
            this.btnHs = new System.Windows.Forms.Button();
            this.btnElo = new System.Windows.Forms.Button();
            this.SubFormPanel = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.SubFormPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.panel1.Controls.Add(this.btnKD);
            this.panel1.Controls.Add(this.btnAddGames);
            this.panel1.Controls.Add(this.btnHs);
            this.panel1.Controls.Add(this.btnElo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 53);
            this.panel1.TabIndex = 0;
            // 
            // btnKD
            // 
            this.btnKD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKD.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnKD.ForeColor = System.Drawing.Color.White;
            this.btnKD.Location = new System.Drawing.Point(445, 3);
            this.btnKD.Name = "btnKD";
            this.btnKD.Size = new System.Drawing.Size(215, 47);
            this.btnKD.TabIndex = 3;
            this.btnKD.Text = "KD";
            this.btnKD.UseVisualStyleBackColor = true;
            this.btnKD.Click += new System.EventHandler(this.btnKD_Click);
            // 
            // btnAddGames
            // 
            this.btnAddGames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGames.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddGames.ForeColor = System.Drawing.Color.White;
            this.btnAddGames.Location = new System.Drawing.Point(666, 3);
            this.btnAddGames.Name = "btnAddGames";
            this.btnAddGames.Size = new System.Drawing.Size(215, 47);
            this.btnAddGames.TabIndex = 5;
            this.btnAddGames.Text = "ADD GAMES";
            this.btnAddGames.UseVisualStyleBackColor = true;
            this.btnAddGames.Click += new System.EventHandler(this.btnAddGames_Click);
            // 
            // btnHs
            // 
            this.btnHs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHs.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnHs.ForeColor = System.Drawing.Color.White;
            this.btnHs.Location = new System.Drawing.Point(224, 3);
            this.btnHs.Name = "btnHs";
            this.btnHs.Size = new System.Drawing.Size(215, 47);
            this.btnHs.TabIndex = 2;
            this.btnHs.Text = "HS";
            this.btnHs.UseVisualStyleBackColor = true;
            this.btnHs.Click += new System.EventHandler(this.btnHs_Click);
            // 
            // btnElo
            // 
            this.btnElo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnElo.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnElo.ForeColor = System.Drawing.Color.White;
            this.btnElo.Location = new System.Drawing.Point(3, 3);
            this.btnElo.Name = "btnElo";
            this.btnElo.Size = new System.Drawing.Size(215, 47);
            this.btnElo.TabIndex = 1;
            this.btnElo.Text = "ELO";
            this.btnElo.UseVisualStyleBackColor = true;
            this.btnElo.Click += new System.EventHandler(this.btnElo_Click);
            // 
            // SubFormPanel
            // 
            this.SubFormPanel.BackColor = System.Drawing.Color.Transparent;
            this.SubFormPanel.Controls.Add(this.lblVersion);
            this.SubFormPanel.Controls.Add(this.label1);
            this.SubFormPanel.Controls.Add(this.pbLogo);
            this.SubFormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubFormPanel.Location = new System.Drawing.Point(0, 53);
            this.SubFormPanel.Name = "SubFormPanel";
            this.SubFormPanel.Size = new System.Drawing.Size(884, 508);
            this.SubFormPanel.TabIndex = 2;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.White;
            this.lblVersion.Font = new System.Drawing.Font("Impact", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblVersion.Location = new System.Drawing.Point(545, 75);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(235, 60);
            this.lblVersion.TabIndex = 8;
            this.lblVersion.Text = "version 1.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Impact", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.label1.Location = new System.Drawing.Point(422, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(459, 60);
            this.label1.TabIndex = 7;
            this.label1.Text = "made by heeleewaree";
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbLogo.InitialImage")));
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(884, 508);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 9;
            this.pbLogo.TabStop = false;
            // 
            // General
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.SubFormPanel);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(900, 600);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "General";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.SubFormPanel.ResumeLayout(false);
            this.SubFormPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnKD;
        private System.Windows.Forms.Button btnHs;
        private System.Windows.Forms.Button btnElo;
        private System.Windows.Forms.Button btnAddGames;
        private System.Windows.Forms.Panel SubFormPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.PictureBox pbLogo;
    }
}


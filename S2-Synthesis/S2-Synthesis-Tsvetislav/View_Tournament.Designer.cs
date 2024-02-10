
namespace S2_Synthesis_Tsvetislav
{
    partial class View_Tournament
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Player1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Player2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Player1Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Player2Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGenerateSchedule = new System.Windows.Forms.Button();
            this.btnViewGame = new System.Windows.Forms.Button();
            this.lblCurrentPlayers = new System.Windows.Forms.Label();
            this.lblPlayersRegistered = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMinPlayers = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMaxPlayers = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Player1,
            this.Player2,
            this.Player1Score,
            this.Player2Score});
            this.dataGridView1.Location = new System.Drawing.Point(13, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(443, 403);
            this.dataGridView1.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Player1
            // 
            this.Player1.HeaderText = "Player1";
            this.Player1.Name = "Player1";
            // 
            // Player2
            // 
            this.Player2.HeaderText = "Player2";
            this.Player2.Name = "Player2";
            // 
            // Player1Score
            // 
            this.Player1Score.HeaderText = "Player 1 Score";
            this.Player1Score.Name = "Player1Score";
            // 
            // Player2Score
            // 
            this.Player2Score.HeaderText = "Player 2 Score";
            this.Player2Score.Name = "Player2Score";
            // 
            // btnGenerateSchedule
            // 
            this.btnGenerateSchedule.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGenerateSchedule.Location = new System.Drawing.Point(502, 241);
            this.btnGenerateSchedule.Name = "btnGenerateSchedule";
            this.btnGenerateSchedule.Size = new System.Drawing.Size(125, 23);
            this.btnGenerateSchedule.TabIndex = 1;
            this.btnGenerateSchedule.Text = "Generate Schedule";
            this.btnGenerateSchedule.UseVisualStyleBackColor = false;
            this.btnGenerateSchedule.Click += new System.EventHandler(this.btnGenerateSchedule_Click);
            // 
            // btnViewGame
            // 
            this.btnViewGame.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnViewGame.Location = new System.Drawing.Point(633, 241);
            this.btnViewGame.Name = "btnViewGame";
            this.btnViewGame.Size = new System.Drawing.Size(122, 23);
            this.btnViewGame.TabIndex = 2;
            this.btnViewGame.Text = "View Game";
            this.btnViewGame.UseVisualStyleBackColor = false;
            this.btnViewGame.Click += new System.EventHandler(this.btnViewGame_Click);
            // 
            // lblCurrentPlayers
            // 
            this.lblCurrentPlayers.AutoSize = true;
            this.lblCurrentPlayers.Location = new System.Drawing.Point(502, 35);
            this.lblCurrentPlayers.Name = "lblCurrentPlayers";
            this.lblCurrentPlayers.Size = new System.Drawing.Size(105, 15);
            this.lblCurrentPlayers.TabIndex = 3;
            this.lblCurrentPlayers.Text = "Players Registered:";
            // 
            // lblPlayersRegistered
            // 
            this.lblPlayersRegistered.AutoSize = true;
            this.lblPlayersRegistered.Location = new System.Drawing.Point(613, 35);
            this.lblPlayersRegistered.Name = "lblPlayersRegistered";
            this.lblPlayersRegistered.Size = new System.Drawing.Size(0, 15);
            this.lblPlayersRegistered.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(502, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Minimum Players:";
            // 
            // lblMinPlayers
            // 
            this.lblMinPlayers.AutoSize = true;
            this.lblMinPlayers.Location = new System.Drawing.Point(613, 70);
            this.lblMinPlayers.Name = "lblMinPlayers";
            this.lblMinPlayers.Size = new System.Drawing.Size(0, 15);
            this.lblMinPlayers.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(502, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Maximum Players:";
            // 
            // lblMaxPlayers
            // 
            this.lblMaxPlayers.AutoSize = true;
            this.lblMaxPlayers.Location = new System.Drawing.Point(613, 99);
            this.lblMaxPlayers.Name = "lblMaxPlayers";
            this.lblMaxPlayers.Size = new System.Drawing.Size(0, 15);
            this.lblMaxPlayers.TabIndex = 8;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBack.Location = new System.Drawing.Point(553, 270);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(146, 35);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "Back to Tournaments";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // View_Tournament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblMaxPlayers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMinPlayers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPlayersRegistered);
            this.Controls.Add(this.lblCurrentPlayers);
            this.Controls.Add(this.btnViewGame);
            this.Controls.Add(this.btnGenerateSchedule);
            this.Controls.Add(this.dataGridView1);
            this.Name = "View_Tournament";
            this.Text = "View_Tournament";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnGenerateSchedule;
        private System.Windows.Forms.Button btnViewGame;
        private System.Windows.Forms.Label lblCurrentPlayers;
        private System.Windows.Forms.Label lblPlayersRegistered;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMinPlayers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMaxPlayers;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Player1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Player2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Player1Score;
        private System.Windows.Forms.DataGridViewTextBoxColumn Player2Score;
        private System.Windows.Forms.Button btnBack;
    }
}
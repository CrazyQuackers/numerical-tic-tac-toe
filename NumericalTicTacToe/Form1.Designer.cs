namespace NumericalTicTacToe
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuLabel = new System.Windows.Forms.Label();
            this.pvpButton = new System.Windows.Forms.Button();
            this.pveButton = new System.Windows.Forms.Button();
            this.turnCounter = new System.Windows.Forms.Label();
            this.restartButton = new System.Windows.Forms.Button();
            this.chunkyRunky = new System.Windows.Forms.Label();
            this.rules = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // menuLabel
            // 
            this.menuLabel.AutoSize = true;
            this.menuLabel.Font = new System.Drawing.Font("Corbel", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuLabel.ForeColor = System.Drawing.Color.White;
            this.menuLabel.Location = new System.Drawing.Point(279, 50);
            this.menuLabel.Name = "menuLabel";
            this.menuLabel.Size = new System.Drawing.Size(356, 45);
            this.menuLabel.TabIndex = 0;
            this.menuLabel.Text = "Numerical Tic Tac Toe";
            // 
            // pvpButton
            // 
            this.pvpButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pvpButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pvpButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.pvpButton.FlatAppearance.BorderSize = 2;
            this.pvpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pvpButton.Font = new System.Drawing.Font("Corbel", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pvpButton.ForeColor = System.Drawing.Color.Black;
            this.pvpButton.Location = new System.Drawing.Point(179, 212);
            this.pvpButton.Name = "pvpButton";
            this.pvpButton.Size = new System.Drawing.Size(120, 120);
            this.pvpButton.TabIndex = 1;
            this.pvpButton.Text = "PvP";
            this.pvpButton.UseVisualStyleBackColor = false;
            this.pvpButton.Click += new System.EventHandler(this.mode_Click);
            // 
            // pveButton
            // 
            this.pveButton.BackColor = System.Drawing.Color.Gold;
            this.pveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pveButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.pveButton.FlatAppearance.BorderSize = 2;
            this.pveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pveButton.Font = new System.Drawing.Font("Corbel", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pveButton.ForeColor = System.Drawing.Color.Black;
            this.pveButton.Location = new System.Drawing.Point(617, 212);
            this.pveButton.Name = "pveButton";
            this.pveButton.Size = new System.Drawing.Size(120, 120);
            this.pveButton.TabIndex = 1;
            this.pveButton.Text = "PvE";
            this.pveButton.UseVisualStyleBackColor = false;
            this.pveButton.Click += new System.EventHandler(this.mode_Click);
            // 
            // turnCounter
            // 
            this.turnCounter.AutoSize = true;
            this.turnCounter.Font = new System.Drawing.Font("Corbel", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnCounter.ForeColor = System.Drawing.Color.White;
            this.turnCounter.Location = new System.Drawing.Point(344, 600);
            this.turnCounter.Name = "turnCounter";
            this.turnCounter.Size = new System.Drawing.Size(0, 45);
            this.turnCounter.TabIndex = 0;
            // 
            // restartButton
            // 
            this.restartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(170)))), ((int)(((byte)(2)))));
            this.restartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.restartButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.restartButton.FlatAppearance.BorderSize = 2;
            this.restartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restartButton.Font = new System.Drawing.Font("Corbel", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restartButton.ForeColor = System.Drawing.Color.Black;
            this.restartButton.Location = new System.Drawing.Point(10, 609);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(120, 120);
            this.restartButton.TabIndex = 1;
            this.restartButton.Text = "Restart";
            this.restartButton.UseVisualStyleBackColor = false;
            this.restartButton.Visible = false;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // chunkyRunky
            // 
            this.chunkyRunky.AutoSize = true;
            this.chunkyRunky.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chunkyRunky.ForeColor = System.Drawing.Color.White;
            this.chunkyRunky.Location = new System.Drawing.Point(664, 706);
            this.chunkyRunky.Name = "chunkyRunky";
            this.chunkyRunky.Size = new System.Drawing.Size(224, 23);
            this.chunkyRunky.TabIndex = 0;
            this.chunkyRunky.Text = "Created by Chunky Runky";
            // 
            // rules
            // 
            this.rules.AllowDrop = true;
            this.rules.AutoEllipsis = true;
            this.rules.Font = new System.Drawing.Font("Corbel", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rules.ForeColor = System.Drawing.Color.White;
            this.rules.Location = new System.Drawing.Point(189, 413);
            this.rules.Name = "rules";
            this.rules.Size = new System.Drawing.Size(641, 284);
            this.rules.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.ClientSize = new System.Drawing.Size(900, 741);
            this.Controls.Add(this.pveButton);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.pvpButton);
            this.Controls.Add(this.turnCounter);
            this.Controls.Add(this.chunkyRunky);
            this.Controls.Add(this.rules);
            this.Controls.Add(this.menuLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Numerical Tic Tac Toe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label menuLabel;
        private System.Windows.Forms.Button pvpButton;
        private System.Windows.Forms.Button pveButton;
        private System.Windows.Forms.Label turnCounter;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Label chunkyRunky;
        private System.Windows.Forms.Label rules;
    }
}


namespace DotNetTips._2022
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
            this.btnVermelho = new System.Windows.Forms.Button();
            this.btnVerde = new System.Windows.Forms.Button();
            this.btnAmarelo = new System.Windows.Forms.Button();
            this.btnAzul = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lbJogadorVez = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnVermelho
            // 
            this.btnVermelho.BackColor = System.Drawing.Color.Red;
            this.btnVermelho.Location = new System.Drawing.Point(495, 106);
            this.btnVermelho.Name = "btnVermelho";
            this.btnVermelho.Size = new System.Drawing.Size(134, 93);
            this.btnVermelho.TabIndex = 1;
            this.btnVermelho.UseVisualStyleBackColor = false;
            this.btnVermelho.Click += new System.EventHandler(this.btnVermelho_Click);
            // 
            // btnVerde
            // 
            this.btnVerde.BackColor = System.Drawing.Color.Green;
            this.btnVerde.Location = new System.Drawing.Point(355, 106);
            this.btnVerde.Name = "btnVerde";
            this.btnVerde.Size = new System.Drawing.Size(134, 93);
            this.btnVerde.TabIndex = 2;
            this.btnVerde.UseVisualStyleBackColor = false;
            this.btnVerde.Click += new System.EventHandler(this.btnVerde_Click);
            // 
            // btnAmarelo
            // 
            this.btnAmarelo.BackColor = System.Drawing.Color.Yellow;
            this.btnAmarelo.Location = new System.Drawing.Point(355, 205);
            this.btnAmarelo.Name = "btnAmarelo";
            this.btnAmarelo.Size = new System.Drawing.Size(134, 93);
            this.btnAmarelo.TabIndex = 3;
            this.btnAmarelo.UseVisualStyleBackColor = false;
            this.btnAmarelo.Click += new System.EventHandler(this.btnAmarelo_Click);
            // 
            // btnAzul
            // 
            this.btnAzul.BackColor = System.Drawing.Color.Blue;
            this.btnAzul.Location = new System.Drawing.Point(495, 205);
            this.btnAzul.Name = "btnAzul";
            this.btnAzul.Size = new System.Drawing.Size(134, 93);
            this.btnAzul.TabIndex = 4;
            this.btnAzul.UseVisualStyleBackColor = false;
            this.btnAzul.Click += new System.EventHandler(this.btnAzul_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 42);
            this.button1.TabIndex = 5;
            this.button1.Text = "NOVO JOGO";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbJogadorVez
            // 
            this.lbJogadorVez.AutoSize = true;
            this.lbJogadorVez.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbJogadorVez.Location = new System.Drawing.Point(31, 390);
            this.lbJogadorVez.Name = "lbJogadorVez";
            this.lbJogadorVez.Size = new System.Drawing.Size(199, 39);
            this.lbJogadorVez.TabIndex = 6;
            this.lbJogadorVez.Text = "JogadorVez";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbJogadorVez);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAzul);
            this.Controls.Add(this.btnAmarelo);
            this.Controls.Add(this.btnVerde);
            this.Controls.Add(this.btnVermelho);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVermelho;
        private System.Windows.Forms.Button btnVerde;
        private System.Windows.Forms.Button btnAmarelo;
        private System.Windows.Forms.Button btnAzul;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbJogadorVez;
    }
}


﻿namespace CapaPresentacion
{
    partial class Login
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
            label1 = new Label();
            label2 = new Label();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            Ingresar = new FontAwesome.Sharp.IconButton();
            Cancelar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.DarkGray;
            label1.Dock = DockStyle.Left;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(250, 256);
            label1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.DarkGray;
            label2.Font = new Font("Segoe UI", 15F);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(32, 181);
            label2.Name = "label2";
            label2.Size = new Size(194, 28);
            label2.TabIndex = 1;
            label2.Text = "SISTEMA DE VENTAS";
            label2.Click += label2_Click;
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = Color.DarkGray;
            iconPictureBox1.ForeColor = SystemColors.ButtonHighlight;
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Store;
            iconPictureBox1.IconColor = SystemColors.ButtonHighlight;
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 166;
            iconPictureBox1.Location = new Point(41, 12);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(185, 166);
            iconPictureBox1.TabIndex = 2;
            iconPictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(287, 83);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(263, 23);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(287, 143);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(263, 23);
            textBox2.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(289, 65);
            label3.Name = "label3";
            label3.Size = new Size(93, 15);
            label3.TabIndex = 5;
            label3.Text = "Nro Documento";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(289, 125);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 6;
            label4.Text = "Contraseña";
            // 
            // Ingresar
            // 
            Ingresar.BackColor = Color.Blue;
            Ingresar.FlatAppearance.BorderColor = Color.Black;
            Ingresar.FlatAppearance.CheckedBackColor = Color.Black;
            Ingresar.FlatAppearance.MouseDownBackColor = Color.Black;
            Ingresar.FlatAppearance.MouseOverBackColor = Color.Black;
            Ingresar.FlatStyle = FlatStyle.Flat;
            Ingresar.ForeColor = SystemColors.ControlLightLight;
            Ingresar.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            Ingresar.IconColor = Color.White;
            Ingresar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            Ingresar.IconSize = 21;
            Ingresar.Location = new Point(315, 190);
            Ingresar.Name = "Ingresar";
            Ingresar.Size = new Size(100, 33);
            Ingresar.TabIndex = 7;
            Ingresar.Text = "Ingresar";
            Ingresar.TextAlign = ContentAlignment.MiddleRight;
            Ingresar.TextImageRelation = TextImageRelation.ImageBeforeText;
            Ingresar.UseVisualStyleBackColor = false;
            Ingresar.Click += iconButton1_Click;
            // 
            // Cancelar
            // 
            Cancelar.BackColor = Color.Red;
            Cancelar.FlatAppearance.BorderColor = Color.Black;
            Cancelar.FlatAppearance.CheckedBackColor = Color.Black;
            Cancelar.FlatAppearance.MouseDownBackColor = Color.Black;
            Cancelar.FlatAppearance.MouseOverBackColor = Color.Black;
            Cancelar.FlatStyle = FlatStyle.Flat;
            Cancelar.ForeColor = SystemColors.ControlLightLight;
            Cancelar.IconChar = FontAwesome.Sharp.IconChar.XmarkCircle;
            Cancelar.IconColor = Color.White;
            Cancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            Cancelar.IconSize = 21;
            Cancelar.Location = new Point(421, 190);
            Cancelar.Name = "Cancelar";
            Cancelar.Size = new Size(106, 33);
            Cancelar.TabIndex = 8;
            Cancelar.Text = "Cancelar";
            Cancelar.TextAlign = ContentAlignment.MiddleRight;
            Cancelar.TextImageRelation = TextImageRelation.ImageBeforeText;
            Cancelar.UseVisualStyleBackColor = false;
            Cancelar.Click += iconButton2_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(603, 256);
            Controls.Add(Cancelar);
            Controls.Add(Ingresar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(iconPictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label3;
        private Label label4;
        private FontAwesome.Sharp.IconButton Ingresar;
        private FontAwesome.Sharp.IconButton Cancelar;
    }
}
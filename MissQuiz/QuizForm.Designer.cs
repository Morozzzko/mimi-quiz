﻿using System.ComponentModel;
using System.Windows.Forms;

namespace MissQuiz
{
    partial class QuizForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuizForm));
            this.label1 = new System.Windows.Forms.Label();
            this.questionPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.questionPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Georgia", 21F, System.Drawing.FontStyle.Italic);
            this.label1.Location = new System.Drawing.Point(10, 422);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(600, 40);
            this.label1.TabIndex = 1;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // questionPicture
            // 
            this.questionPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.questionPicture.Location = new System.Drawing.Point(0, 0);
            this.questionPicture.Name = "questionPicture";
            this.questionPicture.Size = new System.Drawing.Size(1008, 730);
            this.questionPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.questionPicture.TabIndex = 2;
            this.questionPicture.TabStop = false;
            this.questionPicture.Visible = false;
            this.questionPicture.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // QuizForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.questionPicture);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QuizForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.QuizForm_Load);
            this.ResizeEnd += new System.EventHandler(this.Form2_ResizeEnd);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form2_Paint);
            this.Resize += new System.EventHandler(this.Form2_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.questionPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Label label1;
        public PictureBox questionPicture;
    }
}
﻿
namespace TestCaseWinforms
{
    partial class Form1
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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.openFile = new System.Windows.Forms.Button();
            this.kadrNumber = new System.Windows.Forms.Label();
            this.kadrName = new System.Windows.Forms.Label();
            this.frameViewer1 = new TestCaseWinforms.FrameViewer();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(10, 515);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(1274, 45);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.Value = 1;
            this.trackBar1.ValueChanged += new System.EventHandler(this.TrackBar1_ValueChanged);
            // 
            // openFile
            // 
            this.openFile.Location = new System.Drawing.Point(12, 11);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(75, 23);
            this.openFile.TabIndex = 2;
            this.openFile.Text = "Открыть";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.openFile_click);
            // 
            // kadrNumber
            // 
            this.kadrNumber.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kadrNumber.Location = new System.Drawing.Point(1294, 524);
            this.kadrNumber.Name = "kadrNumber";
            this.kadrNumber.Size = new System.Drawing.Size(69, 24);
            this.kadrNumber.TabIndex = 3;
            this.kadrNumber.Text = "1";
            this.kadrNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kadrName
            // 
            this.kadrName.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kadrName.Location = new System.Drawing.Point(1289, 498);
            this.kadrName.Name = "kadrName";
            this.kadrName.Size = new System.Drawing.Size(74, 26);
            this.kadrName.TabIndex = 4;
            this.kadrName.Text = "КАДР";
            // 
            // frameViewer1
            // 
            this.frameViewer1.Location = new System.Drawing.Point(12, 41);
            this.frameViewer1.Name = "frameViewer1";
            this.frameViewer1.Size = new System.Drawing.Size(1316, 458);
            this.frameViewer1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1377, 570);
            this.Controls.Add(this.frameViewer1);
            this.Controls.Add(this.kadrName);
            this.Controls.Add(this.kadrNumber);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.trackBar1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.Label kadrNumber;
        private System.Windows.Forms.Label kadrName;
        private FrameViewer frameViewer1;
    }
}


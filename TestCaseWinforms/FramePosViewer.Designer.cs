namespace TestCaseWinforms
{
    partial class FramePosViewer
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.scaleX1 = new System.Windows.Forms.RadioButton();
            this.scaleX2 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // scaleX1
            // 
            this.scaleX1.AutoSize = true;
            this.scaleX1.Checked = true;
            this.scaleX1.Location = new System.Drawing.Point(442, 724);
            this.scaleX1.Name = "scaleX1";
            this.scaleX1.Size = new System.Drawing.Size(43, 21);
            this.scaleX1.TabIndex = 0;
            this.scaleX1.TabStop = true;
            this.scaleX1.Text = "x1";
            this.scaleX1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.scaleX1.UseVisualStyleBackColor = true;
            this.scaleX1.CheckedChanged += new System.EventHandler(this.scale_CheckedChanged);
            // 
            // scaleX2
            // 
            this.scaleX2.AutoSize = true;
            this.scaleX2.Location = new System.Drawing.Point(505, 724);
            this.scaleX2.Name = "scaleX2";
            this.scaleX2.Size = new System.Drawing.Size(43, 21);
            this.scaleX2.TabIndex = 1;
            this.scaleX2.TabStop = true;
            this.scaleX2.Text = "x2";
            this.scaleX2.UseVisualStyleBackColor = true;
            // 
            // FramePosViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scaleX2);
            this.Controls.Add(this.scaleX1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FramePosViewer";
            this.Size = new System.Drawing.Size(1287, 758);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FramePosViewer_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FramePosViewer_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton scaleX1;
        private System.Windows.Forms.RadioButton scaleX2;
    }
}

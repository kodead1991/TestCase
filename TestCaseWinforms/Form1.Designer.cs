
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
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonHEX = new System.Windows.Forms.RadioButton();
            this.radioButtonDEC = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.frameViewer1 = new TestCaseWinforms.FrameViewer();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(13, 634);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(1677, 56);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.Value = 1;
            this.trackBar1.ValueChanged += new System.EventHandler(this.TrackBar1_ValueChanged);
            // 
            // openFile
            // 
            this.openFile.Location = new System.Drawing.Point(16, 14);
            this.openFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(100, 28);
            this.openFile.TabIndex = 2;
            this.openFile.Text = "Открыть";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.openFile_click);
            // 
            // kadrNumber
            // 
            this.kadrNumber.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kadrNumber.Location = new System.Drawing.Point(1699, 645);
            this.kadrNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kadrNumber.Name = "kadrNumber";
            this.kadrNumber.Size = new System.Drawing.Size(92, 30);
            this.kadrNumber.TabIndex = 3;
            this.kadrNumber.Text = "1";
            this.kadrNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kadrName
            // 
            this.kadrName.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kadrName.Location = new System.Drawing.Point(1691, 613);
            this.kadrName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kadrName.Name = "kadrName";
            this.kadrName.Size = new System.Drawing.Size(99, 32);
            this.kadrName.TabIndex = 4;
            this.kadrName.Text = "КАДР";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(237, 602);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "Формат слов данных";
            // 
            // radioButtonHEX
            // 
            this.radioButtonHEX.AutoSize = true;
            this.radioButtonHEX.Checked = true;
            this.radioButtonHEX.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonHEX.Location = new System.Drawing.Point(496, 599);
            this.radioButtonHEX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonHEX.Name = "radioButtonHEX";
            this.radioButtonHEX.Size = new System.Drawing.Size(67, 26);
            this.radioButtonHEX.TabIndex = 7;
            this.radioButtonHEX.TabStop = true;
            this.radioButtonHEX.Text = "HEX";
            this.radioButtonHEX.UseVisualStyleBackColor = true;
            this.radioButtonHEX.CheckedChanged += new System.EventHandler(this.RadioButtonHEX_CheckedChanged);
            // 
            // radioButtonDEC
            // 
            this.radioButtonDEC.AutoSize = true;
            this.radioButtonDEC.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonDEC.Location = new System.Drawing.Point(579, 599);
            this.radioButtonDEC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonDEC.Name = "radioButtonDEC";
            this.radioButtonDEC.Size = new System.Drawing.Size(67, 26);
            this.radioButtonDEC.TabIndex = 8;
            this.radioButtonDEC.Text = "DEC";
            this.radioButtonDEC.UseVisualStyleBackColor = true;
            this.radioButtonDEC.CheckedChanged += new System.EventHandler(this.radioButtonDEC_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "1";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.Location = new System.Drawing.Point(661, 599);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(309, 30);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 9;
            this.comboBox1.ValueMember = "1";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // frameViewer1
            // 
            this.frameViewer1.Location = new System.Drawing.Point(16, 50);
            this.frameViewer1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.frameViewer1.MaximumSize = new System.Drawing.Size(1720, 542);
            this.frameViewer1.MinimumSize = new System.Drawing.Size(1720, 542);
            this.frameViewer1.Name = "frameViewer1";
            this.frameViewer1.Size = new System.Drawing.Size(1720, 542);
            this.frameViewer1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1792, 702);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.radioButtonDEC);
            this.Controls.Add(this.radioButtonHEX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.frameViewer1);
            this.Controls.Add(this.kadrName);
            this.Controls.Add(this.kadrNumber);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.trackBar1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonHEX;
        private System.Windows.Forms.RadioButton radioButtonDEC;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}


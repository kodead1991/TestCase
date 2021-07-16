
namespace TestCaseWinforms
{
    partial class FormMain
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
            this.frameTrackBar = new System.Windows.Forms.TrackBar();
            this.openFileButton = new System.Windows.Forms.Button();
            this.currentFrameNumber = new System.Windows.Forms.Label();
            this.frameLabel = new System.Windows.Forms.Label();
            this.wordFormatText = new System.Windows.Forms.Label();
            this.radioButtonHEX = new System.Windows.Forms.RadioButton();
            this.radioButtonDEC = new System.Windows.Forms.RadioButton();
            this.comboBoxWordFormat = new System.Windows.Forms.ComboBox();
            this.frameViewer = new TestCaseWinforms.FrameViewer();
            ((System.ComponentModel.ISupportInitialize)(this.frameTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // frameTrackBar
            // 
            this.frameTrackBar.Location = new System.Drawing.Point(13, 634);
            this.frameTrackBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.frameTrackBar.Minimum = 1;
            this.frameTrackBar.Name = "frameTrackBar";
            this.frameTrackBar.Size = new System.Drawing.Size(1677, 56);
            this.frameTrackBar.TabIndex = 1;
            this.frameTrackBar.Value = 1;
            this.frameTrackBar.ValueChanged += new System.EventHandler(this.TrackBar1_ValueChanged);
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(16, 14);
            this.openFileButton.Margin = new System.Windows.Forms.Padding(4);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(100, 28);
            this.openFileButton.TabIndex = 2;
            this.openFileButton.Text = "Открыть";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.OpenFile_click);
            // 
            // currentFrameNumber
            // 
            this.currentFrameNumber.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentFrameNumber.Location = new System.Drawing.Point(1699, 645);
            this.currentFrameNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentFrameNumber.Name = "currentFrameNumber";
            this.currentFrameNumber.Size = new System.Drawing.Size(92, 30);
            this.currentFrameNumber.TabIndex = 3;
            this.currentFrameNumber.Text = "1";
            this.currentFrameNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frameLabel
            // 
            this.frameLabel.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.frameLabel.Location = new System.Drawing.Point(1691, 613);
            this.frameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.frameLabel.Name = "frameLabel";
            this.frameLabel.Size = new System.Drawing.Size(99, 32);
            this.frameLabel.TabIndex = 4;
            this.frameLabel.Text = "КАДР";
            this.frameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wordFormatText
            // 
            this.wordFormatText.AutoSize = true;
            this.wordFormatText.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wordFormatText.Location = new System.Drawing.Point(237, 602);
            this.wordFormatText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.wordFormatText.Name = "wordFormatText";
            this.wordFormatText.Size = new System.Drawing.Size(226, 22);
            this.wordFormatText.TabIndex = 6;
            this.wordFormatText.Text = "Формат слов данных";
            // 
            // radioButtonHEX
            // 
            this.radioButtonHEX.AutoSize = true;
            this.radioButtonHEX.Checked = true;
            this.radioButtonHEX.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonHEX.Location = new System.Drawing.Point(496, 599);
            this.radioButtonHEX.Margin = new System.Windows.Forms.Padding(4);
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
            this.radioButtonDEC.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonDEC.Name = "radioButtonDEC";
            this.radioButtonDEC.Size = new System.Drawing.Size(67, 26);
            this.radioButtonDEC.TabIndex = 8;
            this.radioButtonDEC.Text = "DEC";
            this.radioButtonDEC.UseVisualStyleBackColor = true;
            // 
            // comboBoxWordFormat
            // 
            this.comboBoxWordFormat.DisplayMember = "1";
            this.comboBoxWordFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWordFormat.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxWordFormat.Location = new System.Drawing.Point(661, 599);
            this.comboBoxWordFormat.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxWordFormat.Name = "comboBoxWordFormat";
            this.comboBoxWordFormat.Size = new System.Drawing.Size(309, 30);
            this.comboBoxWordFormat.Sorted = true;
            this.comboBoxWordFormat.TabIndex = 9;
            this.comboBoxWordFormat.ValueMember = "1";
            this.comboBoxWordFormat.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // frameViewer
            // 
            this.frameViewer.FrameToShow = null;
            this.frameViewer.Location = new System.Drawing.Point(16, 50);
            this.frameViewer.Margin = new System.Windows.Forms.Padding(5);
            this.frameViewer.MaximumSize = new System.Drawing.Size(1720, 542);
            this.frameViewer.MinimumSize = new System.Drawing.Size(1720, 542);
            this.frameViewer.MousePos = new System.Drawing.Point(7, 27);
            this.frameViewer.Name = "frameViewer";
            this.frameViewer.Param = null;
            this.frameViewer.Path = null;
            this.frameViewer.Radix = null;
            this.frameViewer.Size = new System.Drawing.Size(1720, 542);
            this.frameViewer.TabIndex = 5;
            this.frameViewer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.frameViewer_MouseClick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1792, 702);
            this.Controls.Add(this.comboBoxWordFormat);
            this.Controls.Add(this.radioButtonDEC);
            this.Controls.Add(this.radioButtonHEX);
            this.Controls.Add(this.wordFormatText);
            this.Controls.Add(this.frameViewer);
            this.Controls.Add(this.frameLabel);
            this.Controls.Add(this.currentFrameNumber);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.frameTrackBar);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.frameTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar frameTrackBar;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Label currentFrameNumber;
        private System.Windows.Forms.Label frameLabel;
        private FrameViewer frameViewer;
        private System.Windows.Forms.Label wordFormatText;
        private System.Windows.Forms.RadioButton radioButtonHEX;
        private System.Windows.Forms.RadioButton radioButtonDEC;
        private System.Windows.Forms.ComboBox comboBoxWordFormat;
    }
}


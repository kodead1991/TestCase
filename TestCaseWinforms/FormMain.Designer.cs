
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.frameView = new System.Windows.Forms.TabPage();
            this.frameViewer = new TestCaseWinforms.FrameViewer();
            this.gistoView = new System.Windows.Forms.TabPage();
            this.gistoViewer = new TestCaseWinforms.GistoViewer();
            ((System.ComponentModel.ISupportInitialize)(this.frameTrackBar)).BeginInit();
            this.tabControl.SuspendLayout();
            this.frameView.SuspendLayout();
            this.gistoView.SuspendLayout();
            this.SuspendLayout();
            // 
            // frameTrackBar
            // 
            this.frameTrackBar.Location = new System.Drawing.Point(11, 890);
            this.frameTrackBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.frameTrackBar.Minimum = 1;
            this.frameTrackBar.Name = "frameTrackBar";
            this.frameTrackBar.Size = new System.Drawing.Size(1671, 56);
            this.frameTrackBar.TabIndex = 1;
            this.frameTrackBar.Value = 1;
            this.frameTrackBar.ValueChanged += new System.EventHandler(this.TrackBar_ValueChanged);
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
            this.currentFrameNumber.Location = new System.Drawing.Point(1695, 901);
            this.currentFrameNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentFrameNumber.Name = "currentFrameNumber";
            this.currentFrameNumber.Size = new System.Drawing.Size(88, 30);
            this.currentFrameNumber.TabIndex = 3;
            this.currentFrameNumber.Text = "1";
            this.currentFrameNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frameLabel
            // 
            this.frameLabel.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.frameLabel.Location = new System.Drawing.Point(1689, 869);
            this.frameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.frameLabel.Name = "frameLabel";
            this.frameLabel.Size = new System.Drawing.Size(93, 32);
            this.frameLabel.TabIndex = 4;
            this.frameLabel.Text = "КАДР";
            this.frameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wordFormatText
            // 
            this.wordFormatText.AutoSize = true;
            this.wordFormatText.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wordFormatText.Location = new System.Drawing.Point(229, 858);
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
            this.radioButtonHEX.Location = new System.Drawing.Point(488, 855);
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
            this.radioButtonDEC.Location = new System.Drawing.Point(571, 855);
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
            this.comboBoxWordFormat.Location = new System.Drawing.Point(659, 855);
            this.comboBoxWordFormat.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxWordFormat.Name = "comboBoxWordFormat";
            this.comboBoxWordFormat.Size = new System.Drawing.Size(303, 30);
            this.comboBoxWordFormat.Sorted = true;
            this.comboBoxWordFormat.TabIndex = 9;
            this.comboBoxWordFormat.ValueMember = "1";
            this.comboBoxWordFormat.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.frameView);
            this.tabControl.Controls.Add(this.gistoView);
            this.tabControl.Location = new System.Drawing.Point(16, 50);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1880, 800);
            this.tabControl.TabIndex = 10;
            // 
            // frameView
            // 
            this.frameView.Controls.Add(this.frameViewer);
            this.frameView.Location = new System.Drawing.Point(4, 25);
            this.frameView.Name = "frameView";
            this.frameView.Padding = new System.Windows.Forms.Padding(3);
            this.frameView.Size = new System.Drawing.Size(1756, 575);
            this.frameView.TabIndex = 0;
            this.frameView.Text = "Кадр";
            this.frameView.UseVisualStyleBackColor = true;
            // 
            // frameViewer
            // 
            this.frameViewer.FrameToShow = null;
            this.frameViewer.Location = new System.Drawing.Point(18, 16);
            this.frameViewer.Margin = new System.Windows.Forms.Padding(5);
            this.frameViewer.MaximumSize = new System.Drawing.Size(1720, 542);
            this.frameViewer.MinimumSize = new System.Drawing.Size(1720, 542);
            this.frameViewer.MousePos = new System.Drawing.Point(7, 27);
            this.frameViewer.Name = "frameViewer";
            this.frameViewer.Param = null;
            this.frameViewer.Path = null;
            this.frameViewer.Radix = null;
            this.frameViewer.Size = new System.Drawing.Size(1720, 542);
            this.frameViewer.TabIndex = 6;
            // 
            // gistoView
            // 
            this.gistoView.Controls.Add(this.gistoViewer);
            this.gistoView.Location = new System.Drawing.Point(4, 25);
            this.gistoView.Name = "gistoView";
            this.gistoView.Padding = new System.Windows.Forms.Padding(3);
            this.gistoView.Size = new System.Drawing.Size(1872, 771);
            this.gistoView.TabIndex = 1;
            this.gistoView.Text = "Гистограмма";
            this.gistoView.UseVisualStyleBackColor = true;
            // 
            // gistoViewer
            // 
            this.gistoViewer.FrameToShow = null;
            this.gistoViewer.Location = new System.Drawing.Point(16, 16);
            this.gistoViewer.Margin = new System.Windows.Forms.Padding(4);
            this.gistoViewer.MaximumSize = new System.Drawing.Size(1840, 742);
            this.gistoViewer.MinimumSize = new System.Drawing.Size(1720, 542);
            this.gistoViewer.Name = "gistoViewer";
            this.gistoViewer.Param = null;
            this.gistoViewer.Path = null;
            this.gistoViewer.Radix = null;
            this.gistoViewer.Size = new System.Drawing.Size(1840, 742);
            this.gistoViewer.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 953);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.comboBoxWordFormat);
            this.Controls.Add(this.radioButtonDEC);
            this.Controls.Add(this.radioButtonHEX);
            this.Controls.Add(this.wordFormatText);
            this.Controls.Add(this.frameLabel);
            this.Controls.Add(this.currentFrameNumber);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.frameTrackBar);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1920, 1000);
            this.MinimumSize = new System.Drawing.Size(1810, 803);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.frameTrackBar)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.frameView.ResumeLayout(false);
            this.gistoView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar frameTrackBar;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Label currentFrameNumber;
        private System.Windows.Forms.Label frameLabel;
        private System.Windows.Forms.Label wordFormatText;
        private System.Windows.Forms.RadioButton radioButtonHEX;
        private System.Windows.Forms.RadioButton radioButtonDEC;
        private System.Windows.Forms.ComboBox comboBoxWordFormat;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage frameView;
        private FrameViewer frameViewer;
        private System.Windows.Forms.TabPage gistoView;
        private GistoViewer gistoViewer;
    }
}


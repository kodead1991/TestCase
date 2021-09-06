
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
            this.framePosView = new System.Windows.Forms.TabPage();
            this.deleteKadrPosView_button = new System.Windows.Forms.Button();
            this.addKadrPosView_button = new System.Windows.Forms.Button();
            this.framePosBox = new System.Windows.Forms.ListBox();
            this.framePosViewer = new TestCaseWinforms.FramePosViewer();
            ((System.ComponentModel.ISupportInitialize)(this.frameTrackBar)).BeginInit();
            this.tabControl.SuspendLayout();
            this.frameView.SuspendLayout();
            this.gistoView.SuspendLayout();
            this.framePosView.SuspendLayout();
            this.SuspendLayout();
            // 
            // frameTrackBar
            // 
            this.frameTrackBar.Location = new System.Drawing.Point(8, 723);
            this.frameTrackBar.Margin = new System.Windows.Forms.Padding(2);
            this.frameTrackBar.Minimum = 1;
            this.frameTrackBar.Name = "frameTrackBar";
            this.frameTrackBar.Size = new System.Drawing.Size(1253, 45);
            this.frameTrackBar.TabIndex = 1;
            this.frameTrackBar.Value = 1;
            this.frameTrackBar.ValueChanged += new System.EventHandler(this.TrackBar_ValueChanged);
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(12, 11);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(75, 23);
            this.openFileButton.TabIndex = 2;
            this.openFileButton.Text = "Открыть";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.OpenFile_click);
            // 
            // currentFrameNumber
            // 
            this.currentFrameNumber.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentFrameNumber.Location = new System.Drawing.Point(1271, 732);
            this.currentFrameNumber.Name = "currentFrameNumber";
            this.currentFrameNumber.Size = new System.Drawing.Size(107, 24);
            this.currentFrameNumber.TabIndex = 3;
            this.currentFrameNumber.Text = "1";
            this.currentFrameNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frameLabel
            // 
            this.frameLabel.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.frameLabel.Location = new System.Drawing.Point(1267, 706);
            this.frameLabel.Name = "frameLabel";
            this.frameLabel.Size = new System.Drawing.Size(111, 26);
            this.frameLabel.TabIndex = 4;
            this.frameLabel.Text = "КАДР";
            this.frameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wordFormatText
            // 
            this.wordFormatText.AutoSize = true;
            this.wordFormatText.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wordFormatText.Location = new System.Drawing.Point(172, 697);
            this.wordFormatText.Name = "wordFormatText";
            this.wordFormatText.Size = new System.Drawing.Size(188, 18);
            this.wordFormatText.TabIndex = 6;
            this.wordFormatText.Text = "Формат слов данных";
            // 
            // radioButtonHEX
            // 
            this.radioButtonHEX.AutoSize = true;
            this.radioButtonHEX.Checked = true;
            this.radioButtonHEX.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonHEX.Location = new System.Drawing.Point(366, 695);
            this.radioButtonHEX.Name = "radioButtonHEX";
            this.radioButtonHEX.Size = new System.Drawing.Size(56, 22);
            this.radioButtonHEX.TabIndex = 7;
            this.radioButtonHEX.TabStop = true;
            this.radioButtonHEX.Text = "HEX";
            this.radioButtonHEX.UseVisualStyleBackColor = true;
            this.radioButtonHEX.CheckedChanged += new System.EventHandler(this.RadioButtonRadix_CheckedChanged);
            // 
            // radioButtonDEC
            // 
            this.radioButtonDEC.AutoSize = true;
            this.radioButtonDEC.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonDEC.Location = new System.Drawing.Point(428, 695);
            this.radioButtonDEC.Name = "radioButtonDEC";
            this.radioButtonDEC.Size = new System.Drawing.Size(56, 22);
            this.radioButtonDEC.TabIndex = 8;
            this.radioButtonDEC.Text = "DEC";
            this.radioButtonDEC.UseVisualStyleBackColor = true;
            // 
            // comboBoxWordFormat
            // 
            this.comboBoxWordFormat.DisplayMember = "1";
            this.comboBoxWordFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWordFormat.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxWordFormat.Location = new System.Drawing.Point(494, 695);
            this.comboBoxWordFormat.Name = "comboBoxWordFormat";
            this.comboBoxWordFormat.Size = new System.Drawing.Size(228, 26);
            this.comboBoxWordFormat.Sorted = true;
            this.comboBoxWordFormat.TabIndex = 9;
            this.comboBoxWordFormat.ValueMember = "1";
            this.comboBoxWordFormat.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.frameView);
            this.tabControl.Controls.Add(this.gistoView);
            this.tabControl.Controls.Add(this.framePosView);
            this.tabControl.Location = new System.Drawing.Point(12, 40);
            this.tabControl.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1410, 650);
            this.tabControl.TabIndex = 10;
            // 
            // frameView
            // 
            this.frameView.Controls.Add(this.frameViewer);
            this.frameView.Location = new System.Drawing.Point(4, 22);
            this.frameView.Margin = new System.Windows.Forms.Padding(2);
            this.frameView.Name = "frameView";
            this.frameView.Padding = new System.Windows.Forms.Padding(2);
            this.frameView.Size = new System.Drawing.Size(1402, 624);
            this.frameView.TabIndex = 0;
            this.frameView.Text = "Кадр";
            this.frameView.UseVisualStyleBackColor = true;
            // 
            // frameViewer
            // 
            this.frameViewer.FrameToShow = null;
            this.frameViewer.Location = new System.Drawing.Point(14, 13);
            this.frameViewer.Margin = new System.Windows.Forms.Padding(4);
            this.frameViewer.MaximumSize = new System.Drawing.Size(1290, 440);
            this.frameViewer.MinimumSize = new System.Drawing.Size(1290, 440);
            this.frameViewer.MousePos = new System.Drawing.Point(7, 27);
            this.frameViewer.Name = "frameViewer";
            this.frameViewer.Param = null;
            this.frameViewer.Path = null;
            this.frameViewer.Radix = null;
            this.frameViewer.SelectedIndex = 0;
            this.frameViewer.Size = new System.Drawing.Size(1290, 440);
            this.frameViewer.TabIndex = 6;
            // 
            // gistoView
            // 
            this.gistoView.Controls.Add(this.gistoViewer);
            this.gistoView.Location = new System.Drawing.Point(4, 22);
            this.gistoView.Margin = new System.Windows.Forms.Padding(2);
            this.gistoView.Name = "gistoView";
            this.gistoView.Padding = new System.Windows.Forms.Padding(2);
            this.gistoView.Size = new System.Drawing.Size(1402, 624);
            this.gistoView.TabIndex = 1;
            this.gistoView.Text = "Гистограмма";
            this.gistoView.UseVisualStyleBackColor = true;
            // 
            // gistoViewer
            // 
            this.gistoViewer.FrameToShow = null;
            this.gistoViewer.Location = new System.Drawing.Point(12, 13);
            this.gistoViewer.MaximumSize = new System.Drawing.Size(1380, 603);
            this.gistoViewer.MinimumSize = new System.Drawing.Size(1290, 440);
            this.gistoViewer.Name = "gistoViewer";
            this.gistoViewer.Param = null;
            this.gistoViewer.Path = null;
            this.gistoViewer.Radix = null;
            this.gistoViewer.SelectedIndex = 0;
            this.gistoViewer.Size = new System.Drawing.Size(1380, 603);
            this.gistoViewer.TabIndex = 0;
            // 
            // framePosView
            // 
            this.framePosView.Controls.Add(this.deleteKadrPosView_button);
            this.framePosView.Controls.Add(this.addKadrPosView_button);
            this.framePosView.Controls.Add(this.framePosBox);
            this.framePosView.Controls.Add(this.framePosViewer);
            this.framePosView.Location = new System.Drawing.Point(4, 22);
            this.framePosView.Name = "framePosView";
            this.framePosView.Padding = new System.Windows.Forms.Padding(3);
            this.framePosView.Size = new System.Drawing.Size(1402, 624);
            this.framePosView.TabIndex = 2;
            this.framePosView.Text = "График";
            this.framePosView.UseVisualStyleBackColor = true;
            // 
            // deleteKadrPosView_button
            // 
            this.deleteKadrPosView_button.Enabled = false;
            this.deleteKadrPosView_button.Location = new System.Drawing.Point(6, 589);
            this.deleteKadrPosView_button.Name = "deleteKadrPosView_button";
            this.deleteKadrPosView_button.Size = new System.Drawing.Size(147, 23);
            this.deleteKadrPosView_button.TabIndex = 3;
            this.deleteKadrPosView_button.Text = "Удалить позицию кадра";
            this.deleteKadrPosView_button.UseVisualStyleBackColor = true;
            this.deleteKadrPosView_button.Click += new System.EventHandler(this.DeleteKadrPosView_Click);
            // 
            // addKadrPosView_button
            // 
            this.addKadrPosView_button.Enabled = false;
            this.addKadrPosView_button.Location = new System.Drawing.Point(6, 560);
            this.addKadrPosView_button.Name = "addKadrPosView_button";
            this.addKadrPosView_button.Size = new System.Drawing.Size(147, 23);
            this.addKadrPosView_button.TabIndex = 2;
            this.addKadrPosView_button.Text = "Добавить позицию кадра";
            this.addKadrPosView_button.UseVisualStyleBackColor = true;
            this.addKadrPosView_button.Click += new System.EventHandler(this.AddKadrPosView_Click);
            // 
            // framePosBox
            // 
            this.framePosBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.framePosBox.FormattingEnabled = true;
            this.framePosBox.Location = new System.Drawing.Point(4, 4);
            this.framePosBox.Name = "framePosBox";
            this.framePosBox.Size = new System.Drawing.Size(149, 550);
            this.framePosBox.TabIndex = 1;
            this.framePosBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FramePosBox_MouseClick);
            this.framePosBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.FramePosBox_DrawItem);
            this.framePosBox.SelectedIndexChanged += new System.EventHandler(this.FramePosBox_SelectedIndexChanged);
            this.framePosBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FramePosBox_MouseDoubleClick);
            // 
            // framePosViewer
            // 
            this.framePosViewer.Frames = null;
            this.framePosViewer.ListBoxSelectedIndex = -1;
            this.framePosViewer.Location = new System.Drawing.Point(159, 6);
            this.framePosViewer.MousePos = new System.Drawing.Point(0, 0);
            this.framePosViewer.Name = "framePosViewer";
            this.framePosViewer.Param = null;
            this.framePosViewer.Radix = null;
            this.framePosViewer.Size = new System.Drawing.Size(1237, 612);
            this.framePosViewer.StartFramePos = 0;
            this.framePosViewer.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1426, 774);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.comboBoxWordFormat);
            this.Controls.Add(this.radioButtonDEC);
            this.Controls.Add(this.radioButtonHEX);
            this.Controls.Add(this.wordFormatText);
            this.Controls.Add(this.frameLabel);
            this.Controls.Add(this.currentFrameNumber);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.frameTrackBar);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1444, 820);
            this.MinimumSize = new System.Drawing.Size(1362, 660);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.frameTrackBar)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.frameView.ResumeLayout(false);
            this.gistoView.ResumeLayout(false);
            this.framePosView.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage framePosView;
        private FramePosViewer framePosViewer;
        private System.Windows.Forms.ListBox framePosBox;
        private System.Windows.Forms.Button addKadrPosView_button;
        private System.Windows.Forms.Button deleteKadrPosView_button;
    }
}


using System.Windows.Forms;

namespace TestCaseWinforms
{
    partial class FramePosDialog
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
            this.colorChooseButton = new System.Windows.Forms.Button();
            this.colorButton = new System.Windows.Forms.Button();
            this.lineType_label = new System.Windows.Forms.Label();
            this.lineType_comboBox = new MyComboBox();
            this.SuspendLayout();
            // 
            // colorChooseButton
            // 
            this.colorChooseButton.BackColor = System.Drawing.SystemColors.Control;
            this.colorChooseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.colorChooseButton.Location = new System.Drawing.Point(16, 15);
            this.colorChooseButton.Margin = new System.Windows.Forms.Padding(4);
            this.colorChooseButton.Name = "colorChooseButton";
            this.colorChooseButton.Size = new System.Drawing.Size(127, 28);
            this.colorChooseButton.TabIndex = 0;
            this.colorChooseButton.Text = "Выбор цвета";
            this.colorChooseButton.UseVisualStyleBackColor = false;
            this.colorChooseButton.Click += new System.EventHandler(this.colorChooseButton_Click);
            // 
            // colorButton
            // 
            this.colorButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.colorButton.Location = new System.Drawing.Point(151, 15);
            this.colorButton.Margin = new System.Windows.Forms.Padding(4);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(100, 28);
            this.colorButton.TabIndex = 1;
            this.colorButton.UseVisualStyleBackColor = false;
            // 
            // lineType_label
            // 
            this.lineType_label.AutoSize = true;
            this.lineType_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lineType_label.Location = new System.Drawing.Point(36, 51);
            this.lineType_label.Name = "lineType_label";
            this.lineType_label.Size = new System.Drawing.Size(94, 20);
            this.lineType_label.TabIndex = 2;
            this.lineType_label.Text = "Тип линии";
            // 
            // lineType_comboBox
            // 
            this.lineType_comboBox.FormattingEnabled = true;
            this.lineType_comboBox.Location = new System.Drawing.Point(151, 51);
            this.lineType_comboBox.Name = "lineType_comboBox";
            this.lineType_comboBox.Size = new System.Drawing.Size(100, 24);
            this.lineType_comboBox.TabIndex = 3;
            // 
            // FramePosDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.lineType_comboBox);
            this.Controls.Add(this.lineType_label);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.colorChooseButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FramePosDialog";
            this.Text = "FramePosDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button colorChooseButton;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Label lineType_label;
        private System.Windows.Forms.ComboBox lineType_comboBox;
    }
}
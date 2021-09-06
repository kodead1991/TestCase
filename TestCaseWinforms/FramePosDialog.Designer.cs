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
            this.colorChoose_button = new System.Windows.Forms.Button();
            this.selectedColor_button = new System.Windows.Forms.Button();
            this.lineType_label = new System.Windows.Forms.Label();
            this.lineType_comboBox = new System.Windows.Forms.ComboBox();
            this.kadrPos_label = new System.Windows.Forms.Label();
            this.kadrPos_textbox = new System.Windows.Forms.TextBox();
            this.OK_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // colorChoose_button
            // 
            this.colorChoose_button.BackColor = System.Drawing.SystemColors.Control;
            this.colorChoose_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.colorChoose_button.Location = new System.Drawing.Point(12, 12);
            this.colorChoose_button.Name = "colorChoose_button";
            this.colorChoose_button.Size = new System.Drawing.Size(95, 23);
            this.colorChoose_button.TabIndex = 0;
            this.colorChoose_button.Text = "Палитра";
            this.colorChoose_button.UseVisualStyleBackColor = false;
            this.colorChoose_button.Click += new System.EventHandler(this.colorChooseButton_Click);
            // 
            // selectedColor_button
            // 
            this.selectedColor_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.selectedColor_button.Location = new System.Drawing.Point(113, 12);
            this.selectedColor_button.Name = "selectedColor_button";
            this.selectedColor_button.Size = new System.Drawing.Size(75, 23);
            this.selectedColor_button.TabIndex = 1;
            this.selectedColor_button.UseVisualStyleBackColor = false;
            this.selectedColor_button.MouseEnter += new System.EventHandler(this.SelectedColor_button_MouseEnter);
            // 
            // lineType_label
            // 
            this.lineType_label.AutoSize = true;
            this.lineType_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lineType_label.Location = new System.Drawing.Point(27, 41);
            this.lineType_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lineType_label.Name = "lineType_label";
            this.lineType_label.Size = new System.Drawing.Size(66, 15);
            this.lineType_label.TabIndex = 2;
            this.lineType_label.Text = "Тип линии";
            // 
            // lineType_comboBox
            // 
            this.lineType_comboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lineType_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lineType_comboBox.FormattingEnabled = true;
            this.lineType_comboBox.Location = new System.Drawing.Point(113, 41);
            this.lineType_comboBox.Margin = new System.Windows.Forms.Padding(2);
            this.lineType_comboBox.Name = "lineType_comboBox";
            this.lineType_comboBox.Size = new System.Drawing.Size(76, 21);
            this.lineType_comboBox.TabIndex = 3;
            this.lineType_comboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.LineType_comboBox_DrawItem);
            this.lineType_comboBox.MouseEnter += new System.EventHandler(this.LineType_comboBox_MouseEnter);
            // 
            // kadrPos_label
            // 
            this.kadrPos_label.AutoSize = true;
            this.kadrPos_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kadrPos_label.Location = new System.Drawing.Point(14, 70);
            this.kadrPos_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.kadrPos_label.Name = "kadrPos_label";
            this.kadrPos_label.Size = new System.Drawing.Size(94, 15);
            this.kadrPos_label.TabIndex = 4;
            this.kadrPos_label.Text = "Позиция кадра";
            // 
            // kadrPos_textbox
            // 
            this.kadrPos_textbox.Location = new System.Drawing.Point(113, 69);
            this.kadrPos_textbox.Name = "kadrPos_textbox";
            this.kadrPos_textbox.Size = new System.Drawing.Size(76, 20);
            this.kadrPos_textbox.TabIndex = 5;
            this.kadrPos_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KadrPos_textbox_KeyPress);
            this.kadrPos_textbox.MouseEnter += new System.EventHandler(this.KadrPos_textbox_MouseEnter);
            // 
            // OK_button
            // 
            this.OK_button.Location = new System.Drawing.Point(17, 99);
            this.OK_button.Name = "OK_button";
            this.OK_button.Size = new System.Drawing.Size(75, 23);
            this.OK_button.TabIndex = 6;
            this.OK_button.Text = "ОК";
            this.OK_button.UseVisualStyleBackColor = true;
            this.OK_button.Click += new System.EventHandler(this.OK_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(110, 99);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.TabIndex = 7;
            this.cancel_button.Text = "ОТМЕНА";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // FramePosDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 133);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.OK_button);
            this.Controls.Add(this.kadrPos_textbox);
            this.Controls.Add(this.kadrPos_label);
            this.Controls.Add(this.lineType_comboBox);
            this.Controls.Add(this.lineType_label);
            this.Controls.Add(this.selectedColor_button);
            this.Controls.Add(this.colorChoose_button);
            this.Name = "FramePosDialog";
            this.Text = "FramePosDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button colorChoose_button;
        private System.Windows.Forms.Button selectedColor_button;
        private System.Windows.Forms.Label lineType_label;
        private System.Windows.Forms.ComboBox lineType_comboBox;
        private Label kadrPos_label;
        private TextBox kadrPos_textbox;
        private Button OK_button;
        private Button cancel_button;
    }
}
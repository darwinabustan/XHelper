namespace XHelper
{
    partial class XFind
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
            this.buttonFindNext = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelFind = new System.Windows.Forms.Label();
            this.textFind = new System.Windows.Forms.TextBox();
            this.checkBoxMatchCase = new System.Windows.Forms.CheckBox();
            this.groupBoxDirection = new System.Windows.Forms.GroupBox();
            this.radioButtonUp = new System.Windows.Forms.RadioButton();
            this.radioButtonDown = new System.Windows.Forms.RadioButton();
            this.groupBoxDirection.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonFindNext
            // 
            this.buttonFindNext.Location = new System.Drawing.Point(373, 21);
            this.buttonFindNext.Name = "buttonFindNext";
            this.buttonFindNext.Size = new System.Drawing.Size(94, 27);
            this.buttonFindNext.TabIndex = 5;
            this.buttonFindNext.Text = "Find Next";
            this.buttonFindNext.UseVisualStyleBackColor = true;
            this.buttonFindNext.Click += new System.EventHandler(this.buttonFindNext_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(373, 54);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 27);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelFind
            // 
            this.labelFind.AutoSize = true;
            this.labelFind.Location = new System.Drawing.Point(13, 21);
            this.labelFind.Name = "labelFind";
            this.labelFind.Size = new System.Drawing.Size(72, 17);
            this.labelFind.TabIndex = 2;
            this.labelFind.Text = "Find what:";
            // 
            // textFind
            // 
            this.textFind.Location = new System.Drawing.Point(103, 21);
            this.textFind.Name = "textFind";
            this.textFind.Size = new System.Drawing.Size(252, 22);
            this.textFind.TabIndex = 0;
            // 
            // checkBoxMatchCase
            // 
            this.checkBoxMatchCase.AutoSize = true;
            this.checkBoxMatchCase.Location = new System.Drawing.Point(16, 103);
            this.checkBoxMatchCase.Name = "checkBoxMatchCase";
            this.checkBoxMatchCase.Size = new System.Drawing.Size(102, 21);
            this.checkBoxMatchCase.TabIndex = 1;
            this.checkBoxMatchCase.Text = "Match case";
            this.checkBoxMatchCase.UseVisualStyleBackColor = true;
            // 
            // groupBoxDirection
            // 
            this.groupBoxDirection.Controls.Add(this.radioButtonDown);
            this.groupBoxDirection.Controls.Add(this.radioButtonUp);
            this.groupBoxDirection.Location = new System.Drawing.Point(210, 54);
            this.groupBoxDirection.Name = "groupBoxDirection";
            this.groupBoxDirection.Size = new System.Drawing.Size(145, 70);
            this.groupBoxDirection.TabIndex = 2;
            this.groupBoxDirection.TabStop = false;
            this.groupBoxDirection.Text = "Direction";
            // 
            // radioButtonUp
            // 
            this.radioButtonUp.AutoSize = true;
            this.radioButtonUp.Location = new System.Drawing.Point(15, 32);
            this.radioButtonUp.Name = "radioButtonUp";
            this.radioButtonUp.Size = new System.Drawing.Size(47, 21);
            this.radioButtonUp.TabIndex = 3;
            this.radioButtonUp.TabStop = true;
            this.radioButtonUp.Text = "Up";
            this.radioButtonUp.UseVisualStyleBackColor = true;
            // 
            // radioButtonDown
            // 
            this.radioButtonDown.AutoSize = true;
            this.radioButtonDown.Checked = true;
            this.radioButtonDown.Location = new System.Drawing.Point(68, 32);
            this.radioButtonDown.Name = "radioButtonDown";
            this.radioButtonDown.Size = new System.Drawing.Size(64, 21);
            this.radioButtonDown.TabIndex = 4;
            this.radioButtonDown.TabStop = true;
            this.radioButtonDown.Text = "Down";
            this.radioButtonDown.UseVisualStyleBackColor = true;
            // 
            // XFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 141);
            this.Controls.Add(this.groupBoxDirection);
            this.Controls.Add(this.checkBoxMatchCase);
            this.Controls.Add(this.textFind);
            this.Controls.Add(this.labelFind);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonFindNext);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XFind";
            this.Text = "Find";
            this.TopMost = true;
            this.groupBoxDirection.ResumeLayout(false);
            this.groupBoxDirection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFindNext;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelFind;
        private System.Windows.Forms.TextBox textFind;
        private System.Windows.Forms.CheckBox checkBoxMatchCase;
        private System.Windows.Forms.GroupBox groupBoxDirection;
        private System.Windows.Forms.RadioButton radioButtonDown;
        private System.Windows.Forms.RadioButton radioButtonUp;
    }
}
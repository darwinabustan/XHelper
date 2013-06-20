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
            this.radioButtonDown = new System.Windows.Forms.RadioButton();
            this.radioButtonUp = new System.Windows.Forms.RadioButton();
            this.findTabs = new System.Windows.Forms.TabControl();
            this.findTab = new System.Windows.Forms.TabPage();
            this.replaceTab = new System.Windows.Forms.TabPage();
            this.groupBoxDirection.SuspendLayout();
            this.findTabs.SuspendLayout();
            this.findTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonFindNext
            // 
            this.buttonFindNext.Location = new System.Drawing.Point(278, 5);
            this.buttonFindNext.Margin = new System.Windows.Forms.Padding(2);
            this.buttonFindNext.Name = "buttonFindNext";
            this.buttonFindNext.Size = new System.Drawing.Size(70, 22);
            this.buttonFindNext.TabIndex = 5;
            this.buttonFindNext.Text = "Find Next";
            this.buttonFindNext.UseVisualStyleBackColor = true;
            this.buttonFindNext.Click += new System.EventHandler(this.buttonFindNext_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(278, 32);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(70, 22);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelFind
            // 
            this.labelFind.AutoSize = true;
            this.labelFind.Location = new System.Drawing.Point(8, 8);
            this.labelFind.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFind.Name = "labelFind";
            this.labelFind.Size = new System.Drawing.Size(56, 13);
            this.labelFind.TabIndex = 2;
            this.labelFind.Text = "Find what:";
            // 
            // textFind
            // 
            this.textFind.Location = new System.Drawing.Point(75, 5);
            this.textFind.Margin = new System.Windows.Forms.Padding(2);
            this.textFind.Name = "textFind";
            this.textFind.Size = new System.Drawing.Size(190, 20);
            this.textFind.TabIndex = 0;
            // 
            // checkBoxMatchCase
            // 
            this.checkBoxMatchCase.AutoSize = true;
            this.checkBoxMatchCase.Location = new System.Drawing.Point(10, 72);
            this.checkBoxMatchCase.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxMatchCase.Name = "checkBoxMatchCase";
            this.checkBoxMatchCase.Size = new System.Drawing.Size(82, 17);
            this.checkBoxMatchCase.TabIndex = 1;
            this.checkBoxMatchCase.Text = "Match case";
            this.checkBoxMatchCase.UseVisualStyleBackColor = true;
            // 
            // groupBoxDirection
            // 
            this.groupBoxDirection.Controls.Add(this.radioButtonDown);
            this.groupBoxDirection.Controls.Add(this.radioButtonUp);
            this.groupBoxDirection.Location = new System.Drawing.Point(156, 32);
            this.groupBoxDirection.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxDirection.Name = "groupBoxDirection";
            this.groupBoxDirection.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxDirection.Size = new System.Drawing.Size(109, 57);
            this.groupBoxDirection.TabIndex = 2;
            this.groupBoxDirection.TabStop = false;
            this.groupBoxDirection.Text = "Direction";
            // 
            // radioButtonDown
            // 
            this.radioButtonDown.AutoSize = true;
            this.radioButtonDown.Checked = true;
            this.radioButtonDown.Location = new System.Drawing.Point(51, 26);
            this.radioButtonDown.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonDown.Name = "radioButtonDown";
            this.radioButtonDown.Size = new System.Drawing.Size(53, 17);
            this.radioButtonDown.TabIndex = 4;
            this.radioButtonDown.TabStop = true;
            this.radioButtonDown.Text = "Down";
            this.radioButtonDown.UseVisualStyleBackColor = true;
            // 
            // radioButtonUp
            // 
            this.radioButtonUp.AutoSize = true;
            this.radioButtonUp.Location = new System.Drawing.Point(11, 26);
            this.radioButtonUp.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonUp.Name = "radioButtonUp";
            this.radioButtonUp.Size = new System.Drawing.Size(39, 17);
            this.radioButtonUp.TabIndex = 3;
            this.radioButtonUp.TabStop = true;
            this.radioButtonUp.Text = "Up";
            this.radioButtonUp.UseVisualStyleBackColor = true;
            // 
            // findTabs
            // 
            this.findTabs.Controls.Add(this.findTab);
            this.findTabs.Controls.Add(this.replaceTab);
            this.findTabs.Location = new System.Drawing.Point(2, 1);
            this.findTabs.Name = "findTabs";
            this.findTabs.SelectedIndex = 0;
            this.findTabs.Size = new System.Drawing.Size(361, 125);
            this.findTabs.TabIndex = 7;
            // 
            // findTab
            // 
            this.findTab.Controls.Add(this.textFind);
            this.findTab.Controls.Add(this.groupBoxDirection);
            this.findTab.Controls.Add(this.buttonFindNext);
            this.findTab.Controls.Add(this.checkBoxMatchCase);
            this.findTab.Controls.Add(this.buttonCancel);
            this.findTab.Controls.Add(this.labelFind);
            this.findTab.Location = new System.Drawing.Point(4, 22);
            this.findTab.Name = "findTab";
            this.findTab.Padding = new System.Windows.Forms.Padding(3);
            this.findTab.Size = new System.Drawing.Size(353, 99);
            this.findTab.TabIndex = 0;
            this.findTab.Text = "Find";
            this.findTab.UseVisualStyleBackColor = true;
            // 
            // replaceTab
            // 
            this.replaceTab.Location = new System.Drawing.Point(4, 22);
            this.replaceTab.Name = "replaceTab";
            this.replaceTab.Padding = new System.Windows.Forms.Padding(3);
            this.replaceTab.Size = new System.Drawing.Size(353, 99);
            this.replaceTab.TabIndex = 1;
            this.replaceTab.Text = "Replace";
            this.replaceTab.UseVisualStyleBackColor = true;
            // 
            // XFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 126);
            this.Controls.Add(this.findTabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XFind";
            this.Text = "Find";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formClose_Click);
            this.groupBoxDirection.ResumeLayout(false);
            this.groupBoxDirection.PerformLayout();
            this.findTabs.ResumeLayout(false);
            this.findTab.ResumeLayout(false);
            this.findTab.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TabControl findTabs;
        private System.Windows.Forms.TabPage findTab;
        private System.Windows.Forms.TabPage replaceTab;
    }
}
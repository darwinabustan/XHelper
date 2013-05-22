namespace XHelper
{
    partial class XPathExpression
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
            this.textExpression = new System.Windows.Forms.TextBox();
            this.buttonApply = new System.Windows.Forms.Button();
            this.textResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textExpression
            // 
            this.textExpression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textExpression.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textExpression.Location = new System.Drawing.Point(12, 12);
            this.textExpression.Name = "textExpression";
            this.textExpression.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textExpression.Size = new System.Drawing.Size(365, 22);
            this.textExpression.TabIndex = 10;
            this.textExpression.Text = "<XPATH EXPRESSION> [<PREFIX>=<NAMESPACE>]";
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApply.Location = new System.Drawing.Point(386, 9);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(99, 28);
            this.buttonApply.TabIndex = 11;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // textResult
            // 
            this.textResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textResult.Location = new System.Drawing.Point(12, 46);
            this.textResult.Multiline = true;
            this.textResult.Name = "textResult";
            this.textResult.ReadOnly = true;
            this.textResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textResult.Size = new System.Drawing.Size(473, 197);
            this.textResult.TabIndex = 13;
            // 
            // XPathExpression
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 255);
            this.Controls.Add(this.textResult);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.textExpression);
            this.Name = "XPathExpression";
            this.Text = "Test XPath";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textExpression;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.TextBox textResult;
    }
}
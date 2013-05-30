using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace XHelper
{
    

    public delegate void FindNextEventHandler(object sender, EventArgs e);

    public delegate void CancelEventHandler(object sender, EventArgs e);

    public delegate void CloseEventHandler(object sender, EventArgs e);


    public partial class XFind : Form
    {

        public ArrayList FindItemIndexes;
        public int CurrentFindItem;

        public string FindString
        {
            get
            {
                return textFind.Text;
            }
            set
            {
                textFind.Text = value;
            }
        }

        public bool MatchCase
        {
            get
            {
                return checkBoxMatchCase.Checked;
            }
            set
            {
                checkBoxMatchCase.Checked = value;
            }
        }

        public bool SearchDown
        {
            get
            {
                return radioButtonDown.Checked;
            }
            set
            {
                radioButtonDown.Checked = value;
            }
        }

        public event FindNextEventHandler FindNext;
        public event CancelEventHandler Cancel;
        public event CloseEventHandler Close;

        public XFind()
        {
            InitializeComponent();
            this.AcceptButton = buttonFindNext;
            this.FindItemIndexes = new ArrayList();
            this.CurrentFindItem = 0;
        }

        private void buttonFindNext_Click(object sender, EventArgs e)
        {
            if(FindNext!=null)
            {
                FindNext(sender,e);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (Cancel != null)
            {
                Cancel(sender, e);
            }
        }

        private void formClose_Click(object sender, EventArgs e)
        {
            Close(sender, e);
        }

        public void FindResults(string textToSearch)
        {
            int index = textToSearch.IndexOf(textFind.Text);
            if(index != -1)
            {
                this.FindItemIndexes.Add(index);
                FindResults(textToSearch.Substring(index + textFind.Text.Length));
            }
        }

    }
}

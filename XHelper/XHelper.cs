using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.IO;
using System.IO.Compression;


namespace XHelper
{

    public partial class XHelper : Form
    {
        public const string DEFAULT_FILE_DIALOG_FILTER = "xml files (*.xml)|*.xml|txt files (*.txt)|*.txt|All files (*.*)|*.*";
        public const int DEFAULT_FILE_DIALOG_FILTER_INDEX = 3;
        public string CurrentFile;
        public bool IsTextChanged;
        public XFind xFind;

        public XHelper()
        {
            InitializeComponent();
            //Initialise Globals
            this.CurrentFile = string.Empty;
            this.IsTextChanged = false;
            XHelperTextUpdate();
            xFind = null;
        }

        #region File Menu
        
        private void menuFileNew_Click(object sender, EventArgs e)
        {
            if (FileSavePrompt() != DialogResult.Cancel)
            {
                this.textData.Clear();
                this.CurrentFile = string.Empty;
                this.IsTextChanged = false;
                XHelperTextUpdate();
            }
        }

        private void menuFileOpen_Click(object sender, EventArgs e)
        {
            if (FileSavePrompt() != DialogResult.Cancel)
            {
                Stream myStream = null;
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.Filter = DEFAULT_FILE_DIALOG_FILTER;
                openFileDialog.FilterIndex = DEFAULT_FILE_DIALOG_FILTER_INDEX;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if ((myStream = openFileDialog.OpenFile()) != null)
                        {
                            using (myStream)
                            {
                                using (StreamReader reader = new StreamReader(myStream))
                                {
                                    this.textData.Text = reader.ReadToEnd();
                                    this.CurrentFile = openFileDialog.FileName;
                                    this.IsTextChanged = false;
                                    XHelperTextUpdate();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowError(ex);
                    }
                }
            }
        }

        private void menuFileSave_Click(object sender, EventArgs e)
        {
            if (this.CurrentFile.Length != 0)
            {
                try
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = DEFAULT_FILE_DIALOG_FILTER,
                        FilterIndex = DEFAULT_FILE_DIALOG_FILTER_INDEX,
                        RestoreDirectory = true,
                        FileName = this.CurrentFile
                    };


                    using (Stream myStream = saveFileDialog.OpenFile())
                    {
                        if (myStream != null)
                        {
                            using (StreamWriter writer = new StreamWriter(myStream))
                            {
                                writer.AutoFlush = true;
                                writer.Write(this.textData.Text);
                                this.IsTextChanged = false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
            else
            {
                menuFileSaveAs_Click(sender, e);
            }
        }

        private void menuFileSaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = DEFAULT_FILE_DIALOG_FILTER,
                    FilterIndex = DEFAULT_FILE_DIALOG_FILTER_INDEX,
                    RestoreDirectory = true
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (Stream myStream = saveFileDialog.OpenFile())
                    {
                        if (myStream != null)
                        {
                            using (StreamWriter writer = new StreamWriter(myStream))
                            {
                                writer.AutoFlush = true;
                                writer.Write(this.textData.Text);
                                this.CurrentFile = saveFileDialog.FileName;
                                this.IsTextChanged = false;
                                XHelperTextUpdate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            if (FileSavePrompt() != DialogResult.Cancel)
            {
                this.Close();
            }
        }

        #endregion

        #region Tools Menu

        private void menuToolsDecodeURL_Click(object sender, EventArgs e)
        {
            try
            {
                textData.Text = HttpUtility.UrlDecode(textData.Text);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void menuToolsDecodeBase64_Click(object sender, EventArgs e)
        {
            try
            {
                textData.Text = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(textData.Text));
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void menuToolsDecodeHTML_Click(object sender, EventArgs e)
        {
            try
            {
                textData.Text = HttpUtility.HtmlDecode(textData.Text);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void menuToolsEncodeURL_Click(object sender, EventArgs e)
        {
            try
            {
                this.textData.Text = HttpUtility.UrlEncode(this.textData.Text);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void menuToolsEncodeBase64_Click(object sender, EventArgs e)
        {
            try
            {
                textData.Text = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(textData.Text));
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void menuToolsEncodeHTML_Click(object sender, EventArgs e)
        {
            try
            {
                this.textData.Text = HttpUtility.HtmlEncode(this.textData.Text);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void menuToolsSignature_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                XSignature xSignature = new XSignature();
                if (xSignature.Check(this.textData.Text))
                {
                    MessageBox.Show("The signature checks out OK.");
                }
                else
                {
                    MessageBox.Show("The signature FAILED validation.");
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                ShowError(ex);
            }
            this.Cursor = Cursors.Default;
        }

        private void menuToolsTransform_Click(object sender, EventArgs e)
        {
            try
            {
                FileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Stylesheet files (*.xsl)|*.xsl|All files (*.*)|*.*";
                dialog.FilterIndex = 1;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    XslCompiledTransform transform = new XslCompiledTransform();

                    // Loading the stylesheet 
                    transform.Load(dialog.FileName);

                    // Transforming the XML Data
                    StringBuilder sb = new StringBuilder();
                    XmlWriter writer = XmlWriter.Create(sb);
                    XmlDocument originalXml = new XmlDocument();
                    originalXml.LoadXml(textData.Text);
                    transform.Transform(originalXml, writer);
                    using (writer)
                    {
                        this.textData.Text = this.FormatXml(sb.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void menuToolsTestXPath_Click(object sender, EventArgs e)
        {
            XPathExpression xPathExpression = new XPathExpression(textData.Text);
            xPathExpression.ShowDialog(this);
        }

        #endregion
        
        #region Format Menu

        private void menuFormatIndent_Click(object sender, EventArgs e)
        {
            try
            {
                textData.Text = FormatXml(textData.Text);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void menuFormatWordWrap_Click(object sender, EventArgs e)
        {
            textData.WordWrap = !textData.WordWrap;
        }

        #endregion

        #region Help Menu

        private void menuHelpAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Application.ProductName + " Version: " + Application.ProductVersion, "About " + Application.ProductName, MessageBoxButtons.OK);
        }

        #endregion

        #region XHelper Events

        private void XHelper_Load(object sender, EventArgs e)
        {
            textData.Select();
        }

        private void XHelper_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FileSavePrompt() == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region TextData Events

        private void textData_Enter(object sender, EventArgs e)
        {
            textData.SelectAll();
        }

        private void textData_TextChanged(object sender, EventArgs e)
        {
            this.IsTextChanged = true;
        }

        private void textData_KeyDown(object sender, KeyEventArgs e)
        {
            TextBoxSelectAll(sender, e);
        }

        private void textData_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void textData_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if ((s.Length > 0) && (FileSavePrompt() != DialogResult.Cancel))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(s[0]))
                    {
                        this.textData.Text = reader.ReadToEnd();
                        this.CurrentFile = s[0];
                        this.IsTextChanged = false;
                        XHelperTextUpdate();
                    }
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }

        }

        #endregion

        #region Helper Functions

        public static void TextBoxSelectAll(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.A))
            {
                ((TextBox)sender).SelectAll();

                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        public DialogResult FileSavePrompt()
        {
            DialogResult messageBoxResponse = DialogResult.Cancel;
            if (!this.IsTextChanged)
            {
                messageBoxResponse = DialogResult.Yes;
            }
            else
            {
                messageBoxResponse = MessageBox.Show("Do you want to save changes to " + this.CurrentFileNameGet() + "?", Application.ProductName, MessageBoxButtons.YesNoCancel);
                if (messageBoxResponse == System.Windows.Forms.DialogResult.Yes)
                {
                    menuFileSave_Click(null, null);
                }
            }
            return messageBoxResponse;
        }

        public string CurrentFileNameGet()
        {
            string myFileName = string.Empty;
            if (this.CurrentFile.Length == 0)
            {
                myFileName = "Untitled";
            }
            else
            {
                myFileName = this.CurrentFile;
            }
            return myFileName;
        }

        public void XHelperTextUpdate()
        {
            if (this.CurrentFile.Length == 0)
            {
                this.Text = "Untitled - " + Application.ProductName;
            }
            else
            {
                string[] fileNamePath = this.CurrentFile.Split('\\');
                string myFileNameWithExtension = fileNamePath[fileNamePath.Length - 1];
                string[] fileNameWithExtention = myFileNameWithExtension.Split('.');
                if (fileNameWithExtention.Length > 1)
                {
                    this.Text = fileNameWithExtention[fileNameWithExtention.Length - 2] + " - " + Application.ProductName;
                }
                else
                {
                    this.Text = fileNameWithExtention[fileNameWithExtention.Length - 1] + " - " + Application.ProductName;
                }
            }
        }

        public void ShowError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private string FormatXml(string sUnformattedXml)
        {
            //load unformatted xml into a dom
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(sUnformattedXml);

            //will hold formatted xml
            StringBuilder sb = new StringBuilder();

            //pumps the formatted xml into the StringBuilder above
            StringWriter sw = new StringWriter(sb);

            //does the formatting
            XmlTextWriter xtw = null;

            try
            {
                //point the xtw at the StringWriter
                xtw = new XmlTextWriter(sw);

                //we want the output formatted
                xtw.Formatting = Formatting.Indented;
                xtw.Indentation = 4;

                //get the dom to dump its contents into the xtw 
                xd.WriteTo(xtw);
            }
            finally
            {
                //clean up even if error
                if (xtw != null)
                    xtw.Close();
            }

            //return the formatted xml
            return sb.ToString();
        }

        #endregion

        private void menuEditUndo_Click(object sender, EventArgs e)
        {
            textData.Undo();
        }

        private void menuEditCut_Click(object sender, EventArgs e)
        {
            textData.Cut();
        }

        private void menuEditCopy_Click(object sender, EventArgs e)
        {
            textData.Copy();
        }

        private void menuEditPaste_Click(object sender, EventArgs e)
        {
            textData.Paste();
        }

        private void menuEditDelete_Click(object sender, EventArgs e)
        {
            textData.SelectedText = "";
        }

        private void menuEditFind_Click(object sender, EventArgs e)
        {
            if(xFind == null)
            {
                xFind = new XFind();
                xFind.FindNext += new FindNextEventHandler(menuEditFindNext_Click);
            }
            xFind.Show();
        }

        private void menuEditFindNext_Click(object sender, EventArgs e)
        {
            int currentIndex;
            int currentLength;
            currentIndex = textData.SelectionStart;
            currentLength = textData.SelectedText.Length;
            textData.Focus();
            if (xFind != null)
            {
                currentLength = xFind.FindString.Length;
                if(xFind.SearchDown)
                {
                    if(xFind.MatchCase)
                    {
                        currentIndex = textData.Text.Substring(currentIndex + currentLength, textData.Text.Length - currentIndex - currentLength).IndexOf(xFind.FindString);
                    }
                    else
                    {
                        currentIndex = textData.Text.ToLower().Substring(currentIndex + currentLength, textData.Text.Length - currentIndex - currentLength).IndexOf(xFind.FindString.ToLower());
                    }
                }
                else
                {
                }
                textData.Select(currentIndex,currentLength);
            }
        }
        
        private void menuEditSelectAll_Click(object sender, EventArgs e)
        {
            textData.SelectAll();
        }

        private void menuEditTimeDate_Click(object sender, EventArgs e)
        {
            textData.SelectedText = DateTime.Now.ToString();
        }

        private void menuToolsSchemaValidate_Click(object sender, EventArgs e)
        {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Schema files (*.xsd)|*.xsd|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Select Schema";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XSchemaValidator xsv = new XSchemaValidator();
                        if (!xsv.XValidate(this.textData.Text, null, openFileDialog.FileName))
                        {
                            MessageBox.Show(xsv.ValidationError);
                        }
                        else
                        {
                            MessageBox.Show("The XML is valid against this schema.");
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowError(ex);
                    }
                }
        }

        private static string DeflateDecompress(string text)
        {
            byte[] bytesToInflate;
            bytesToInflate = Convert.FromBase64String(text);

            string inflatedBase64String;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (DeflateStream inflateStream = new DeflateStream(memoryStream, CompressionMode.Decompress, true))
                {
                    using (StreamReader streamReader = new StreamReader(inflateStream))
                    {
                        memoryStream.Write(bytesToInflate, 0, bytesToInflate.Length);
                        memoryStream.Flush();
                        memoryStream.Seek(0, SeekOrigin.Begin);

                        inflatedBase64String = streamReader.ReadToEnd();
                    }
                }
            }
            return inflatedBase64String;
        }

        private void menuToolsDeflateDecompress_Click(object sender, EventArgs e)
        {
            try
            {
                textData.Text = DeflateDecompress(textData.Text);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }
    }
}

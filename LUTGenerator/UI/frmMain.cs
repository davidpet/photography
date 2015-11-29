using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Petrofsky.Photography.LUTGenerator
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (dlgGenerateReference.ShowDialog() == DialogResult.OK)
            {
                //create the in-memory image
                try
                {
                    referenceImage = new Graphics.ReferenceImage((int)numDimension.Value, (int)numBlockSize.Value);
                }
                catch (Exception exception)
                {
                    showError("There was a problem creating the reference image: " + exception.Message);
                    return;
                }

                //save to disk
                try
                {
                    referenceImage.Save(dlgGenerateReference.FileName);
                }
                catch (Exception exception)
                {
                    showError("There was a problem saving the reference image: " + exception.Message);
                    return;
                }

                //sync the controls
                syncControlsToImage();
                }
        }

        private static void showError(string text, string caption = null)
        {
            MessageBox.Show(text, caption ?? "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (dlgLoadReference.ShowDialog() == DialogResult.OK)
            {
                //load the image into memory
                try
                {
                    referenceImage = new Graphics.ReferenceImage(dlgLoadReference.FileName);
                }
                catch (Exception exception)
                {
                    showError("There was a problem loading the reference image: " + exception.Message);
                    return;
                }

                //sync the controls
                syncControlsToImage();
            }
        }

        private void syncChannelControls(NumericUpDown numericControl,TextBox textControl)
        {
            numericControl.Enabled = false;
            numericControl.Maximum = referenceImage.Dimension - 1;
            numericControl.Value = 0;
            numericControl.Enabled = true;

            textControl.Enabled = true;
        }

        private void syncControlsToImage()
        {
            pctSample.Enabled = true;

            numDimension.Value = referenceImage.Dimension;
            numBlockSize.Value = referenceImage.BlockSize;

            syncChannelControls(numRedIndex, txtRed);
            syncChannelControls(numGreenIndex, txtGreen);
            syncChannelControls(numBlueIndex, txtBlue);

            btnCreateLUT.Enabled = true;
            chkUseScript.Enabled = true;

            setCurrentColor(referenceImage.GetSample((int)numRedIndex.Value, (int)numGreenIndex.Value, (int)numBlueIndex.Value));
        }

        #region Private Data
            private Graphics.ReferenceImage referenceImage;
        #endregion

            private void numIndex_ValueChanged(object sender, EventArgs e)
            {
                Control control = (Control)sender;
                
                if (control.Enabled)
                    setCurrentColor(referenceImage.GetSample((int)numRedIndex.Value,(int) numGreenIndex.Value, (int)numBlueIndex.Value));
            }

            private void setCurrentColor(Color color)
            {
                txtRed.Text = color.R.ToString();
                txtGreen.Text = color.G.ToString();
                txtBlue.Text = color.B.ToString();

                pctSample.BackColor = color;
            }

            private void btnCreateLUT_Click(object sender, EventArgs e)
            {
                if (dlgCreateLUT.ShowDialog() == DialogResult.OK)
                {
                    Scripting.ScriptFilter filter = null;
                    if (chkUseScript.Enabled && chkUseScript.Checked)
                        filter = new Scripting.ScriptFilter(txtScript.Text);

                    try
                    {
                        referenceImage.CreateLUT(dlgCreateLUT.FileName,filter);
                    }
                    catch (System.Exception exception)
                    {
                        showError("There was a problem creating the LUT file: " + exception.Message);
                        return;
                    }
                }
            }

            private void btnLoadScript_Click(object sender, EventArgs e)
            {
                if (dlgLoadScript.ShowDialog() == DialogResult.OK)
                {
                    StreamReader reader = new StreamReader(dlgLoadScript.FileName, true);
                    txtScript.Text = reader.ReadToEnd();
                    reader.Close();
                }
            }

            private void btnSaveScript_Click(object sender, EventArgs e)
            {
                if (dlgSaveScript.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writer = new StreamWriter(dlgSaveScript.FileName);
                    writer.Write(txtScript.Text);
                    writer.Close();
                }
            }
    }
}

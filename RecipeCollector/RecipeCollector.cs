using System;
using System.IO;
using System.Windows.Forms;

namespace RecipeCollector
{
    public partial class RecipeCollector : Form
    {
        public RecipeCollector()
        {
            InitializeComponent();
        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {
            CheckDownloadEnable();
        }

        private void btnDirectorySelect_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.ShowNewFolderButton = true;
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtFolder.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {

        }

        private void CheckDownloadEnable()
        {
            Uri uriResult;
            bool uriValid = Uri.TryCreate(txtUrl.Text, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            bool folderValid = Directory.Exists(txtFolder.Text);
            btnDownload.Enabled = uriValid && folderValid;
        }
    }
}

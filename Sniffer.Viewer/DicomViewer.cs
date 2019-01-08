using System;
using System.Windows.Forms;
using Sniffer.Dicom;

namespace Sniffer.Viewer
{
    public partial class DicomViewer : Form
    {
        private DicomHelper _dHelper = new DicomHelper();
        public DicomViewer()
        {
            InitializeComponent();            
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            txtFilePath.Text = string.Empty;
            using (var ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = "D:\\";
                ofd.Filter = @"dicom files (*.dcm)|*.dcm|All files(*.*)|*.*";
                ofd.FilterIndex = 2;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var filePath = ofd.FileName;
                    txtFilePath.Text = ofd.FileName;
                    gvTags.DataSource = _dHelper.GetDicomTags(filePath);
                    gvTags.AutoResizeColumns();
                }
            }
        }                
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Dicom;

namespace DicomFileViewer
{
    public partial class DicomViewer : Form
    {
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
                    var dicomFileInfo = GetDicomFileInfo(filePath);
                }
            }
        }

        private IEnumerable<string> GetDicomFileInfo(string path)
        {
            var file = DicomFile.Open(path);
            var patientIds = file.Dataset.GetValues<string>(DicomTag.PatientID);
            return patientIds;
        }

        /*
        /// <summary>
        /// Gets and prints information about DICOM file.
        /// </summary>
        /// <param name="filePath">Path to a DICOm file.</param>
        private List<DicomDataElementMetadata> GetDicomFileInfo(string filePath)
        {
            var dicomFileInfo = new List<DicomDataElementMetadata>();

            // open DICOM file
            using (var file = new DicomFile(filePath, true))
            {
                // show file name and page count
                Console.WriteLine($@"File: {Path.GetFileName(filePath)} Page count: {file.Pages.Count}");
                
                // get DICOM file metadata
                var fileMetadata = new DicomFrameMetadata(file);

                // for each metadata node
                foreach (var children in fileMetadata)
                {
                    dicomFileInfo.Add(GetMetadataNodeInfo(children));
                }
            }

            return dicomFileInfo;
        }

        /// <summary>
        /// Return metadata node if it is only a Metadata node. Otherwise recursively get the information
        /// </summary>
        /// <param name="node">Metadata node.</param>
        private DicomDataElementMetadata GetMetadataNodeInfo(MetadataNode node)
        {
            // if node is DicomDataElementMetadata
            if (node is DicomDataElementMetadata dataElementMetadata)
            {
                return dataElementMetadata;
            }

            // show children info
            foreach (var children in node)
                GetMetadataNodeInfo(children);

            throw new Exception("Node is not DicomDataElementMetadata");
        }
        */
    }
}

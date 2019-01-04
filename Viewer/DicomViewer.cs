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
                    gvTags.DataSource = GetDicomTags(filePath);
                    gvTags.AutoResizeColumns();
                }
            }
        }
        
        private IEnumerable<DicomTag> GetDicomTags(string path)
        {
            var file = DicomFile.Open(path);
            var value = string.Empty;

            var tags = file.Dataset
                .Where(x => x.ValueRepresentation != null && x.ValueRepresentation.IsString)
                .Select(x => new DicomTag
                {
                    Tag = x.ToString(),
                    Name = x.Tag.DictionaryEntry.Name,
                    Value = file.Dataset.GetString(x.Tag),
                    Group = x.Tag.Group,
                    Element = x.Tag.Element
                })
                .OrderBy(i => i.Group)
                .ThenBy(i => i.Name)
                .ToList();

            return tags;
        }        
    }
}

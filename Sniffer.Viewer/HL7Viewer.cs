using Sniffer.HL7;
using System;
using System.Windows.Forms;

namespace Sniffer.Viewer
{
    public partial class HL7Viewer : Form
    {
        private HL7Helper _hlHelper = new HL7Helper();
        public HL7Viewer()
        {
            InitializeComponent();
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHl7Input.Text.Trim()))
            {
                MessageBox.Show("Please input the HL7 text");
                return;
            }

            gvHl7Results.DataSource = _hlHelper.ParseHL7Text(txtHl7Input.Text.Trim());
            gvHl7Results.AutoResizeColumns();
        }
    }
}

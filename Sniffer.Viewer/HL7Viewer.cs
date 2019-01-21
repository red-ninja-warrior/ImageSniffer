using Sniffer.HL7;
using Sniffer.HL7.SegmentType;
using System;
using System.Collections.Generic;
using System.Data;
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

            DrawGridView(_hlHelper.ParseHL7Message(txtHl7Input.Text.Trim()));            
        }

        private void DrawGridView(List<Segment> segments)
        {
            var dtSegments = new DataTable();
            dtSegments.Columns.Add("Id", typeof(int));
            dtSegments.Columns.Add("Segment", typeof(string));

            var dtDetails = new DataTable();
            dtDetails.Columns.Add("Id", typeof(int));
            dtDetails.Columns.Add("Field", typeof(string));
            dtDetails.Columns.Add("Value", typeof(string));

            foreach(var s in segments)
            {
                dtSegments.Rows.Add(s.SegmentId, s.SegmentName);
                foreach(var sd in s.Descendents)
                {
                    dtDetails.Rows.Add(s.SegmentId, sd.Field, sd.Value);
                }
            }

            var ds = new DataSet();
            ds.Tables.Add(dtSegments);
            ds.Tables.Add(dtDetails);

            var relation = new DataRelation("Relation", ds.Tables[0].Columns[0], ds.Tables[1].Columns[0], true);
            ds.Relations.Add(relation);

            dgHl7Results.DataSource = ds.Tables[0];
            dgHl7Results.PreferredColumnWidth = 60;
        }
    }
}

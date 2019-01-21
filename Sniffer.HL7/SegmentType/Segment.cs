using System.Collections.Generic;

namespace Sniffer.HL7.SegmentType
{
    public class Segment
    {
        public Segment()
        {
            Descendents = new List<Descendent>(); 
        }

        public int SegmentId { get; set; }
        public string SegmentName { get; set; }
        public List<Descendent> Descendents { get; set; }
    }

    public class Descendent
    {
        public string Field { get; set; }
        public string Value { get; set; }
    }
}

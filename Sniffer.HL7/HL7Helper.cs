using Sniffer.HL7.SegmentType;
using System.Collections.Generic;

namespace Sniffer.HL7
{
    public class HL7Helper
    {
        public List<Segment> ParseHL7Message(string hl7Message)
        {
            var message = hl7Message.Split('\n');
            var segments = new List<Segment>();
            var i = 1;
            foreach (var m in message)
            {
                var messageType = m.Substring(0, 3);
                var segment = new Segment {SegmentId = i++, SegmentName = messageType };
                segments.Add(segment);
                switch (messageType)
                {
                    case "MSH":
                        segment.Descendents = MSH.GetElements(m);
                        break;
                    case "DG1":
                        segment.Descendents = Common.GetElements<DG1>(m);
                        break;
                    case "OBR":
                        segment.Descendents = Common.GetElements<OBR>(m);
                        break;
                    case "ORC":
                        segment.Descendents = Common.GetElements<ORC>(m);
                        break;
                    case "PD1":
                        segment.Descendents = Common.GetElements<PD1>(m);
                        break;
                    case "PID":
                        segment.Descendents = Common.GetElements<PID>(m);
                        break;
                    case "PV1":
                        segment.Descendents = Common.GetElements<PV1>(m);
                        break;
                    case "RXR":
                        segment.Descendents = Common.GetElements<RXR>(m);
                        break;
                    case "RXA":
                        segment.Descendents = Common.GetElements<RXA>(m);
                        break;
                    case "NK1":
                        segment.Descendents = Common.GetElements<NK1>(m);
                        break;
                    case "OBX":
                        segment.Descendents = Common.GetElements<OBX>(m);
                        break;
                    case "IN1":
                        segment.Descendents = Common.GetElements<IN1>(m);
                        break;
                    default:
                        break;

                }
            }
            return segments;
        }
    }
}

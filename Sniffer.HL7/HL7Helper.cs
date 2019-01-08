using HL7.Dotnetcore;
using System.Collections.Generic;

namespace Sniffer.HL7
{
    public class HL7Helper
    {
        public List<Segment> ParseHL7Text(string text)
        {
            var message = new Message(text);

            var isParsed = message.ParseMessage();

            var segList = message.Segments();
            return segList;
        }
    }
}

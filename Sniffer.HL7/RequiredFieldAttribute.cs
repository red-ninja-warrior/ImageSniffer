using System;

namespace Sniffer.HL7
{
    public class RequiredFieldAttribute: Attribute
    {
        public bool Required { get; private set; }
        public RequiredFieldAttribute()
        {
            Required = true;
        }
    }
}

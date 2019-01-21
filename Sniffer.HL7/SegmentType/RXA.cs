using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sniffer.HL7.SegmentType
{
    public class RXA
    {
        public string GiveSubIdCounter { get; set; }
        public string AdministrationSubIdCounter { get; set; }
        public string AdministrationStartDateTime { get; set; }
        public string AdministrationEndDateTime { get; set; }
        public string AdministeredCode { get; set; }
        public string AdministeredAmount { get; set; }
        public string AdministeredUnits { get; set; }
        public string AdministeredDosageForm { get; set; }
        public string AdministrationNotes { get; set; }
        public string AdministeringProvider { get; set; }
        public string AdministeredLocation { get; set; }
        public string AdministeredPer { get; set; }
        public string AdministeredStrength { get; set; }
        public string AdministeredStrengthUnits { get; set; }
        public string SubstanceLotNumber { get; set; }
        public string SubstanceExpirationDate { get; set; }
        public string SubstanceManufacturerName { get; set; }
        public string SubstanceRefusalReason { get; set; }
        public string Indication { get; set; }
        public string CompletionStatus { get; set; }
        public string RxaActionCode { get; set; }
        public string SystemEntryDateTime { get; set; }        
    }
}

using System;
using System.Linq;

namespace Sniffer.HL7.SegmentType
{
    /// <summary>
    /// Patient Visit
    /// </summary>
    public class PV1
    {
        public string SetId { get; set; }

        //[RequiredField]
        public string PatientClass { get; set; }
        public string AssignedPatientLocation { get; set; }
        public string AdmissionType { get; set; }
        public string PreadmitNumber { get; set; }
        public string PriorPatientLocation { get; set; }
        public string AttendingDoctor { get; set; }
        public string ReferringDoctor { get; set; }
        public string ConsultingDoctor { get; set; }
        public string HospitalService { get; set; }
        public string TemporaryLocation { get; set; }
        public string PreadmitTestIndicator { get; set; }
        public string ReAdmissionIndicator { get; set; }
        public string AdmitSource { get; set; }
        public string AmbulatoryStatus { get; set; }
        public string VIPIndicator { get; set; }
        public string AdmittingDoctor { get; set; }
        public string PatientType { get; set; }
        public string VisitNumber { get; set; }
        public string FinancialClass { get; set; }
        public string ChargePriceIndicator { get; set; }
        public string CourtesyCode { get; set; }
        public string CreditRating { get; set; }
        public string ContractCode { get; set; }
        public string ContractEffectiveDate { get; set; }
        public string ContractAmount { get; set; }
        public string ContractPeriod { get; set; }
        public string InterestCode { get; set; }
        public string TransfertoBadDebtCode { get; set; }
        public string TransfertoBadDebtDate { get; set; }
        public string BadDebtAgencyCode { get; set; }
        public string BadDebtTransferAmount { get; set; }
        public string BadDebtRecoveryAmount { get; set; }
        public string DeleteAccountIndicator { get; set; }
        public string DeleteAccountDate { get; set; }
        public string DischargeDisposition { get; set; }
        public string DischargedtoLocation { get; set; }
        public string DietType { get; set; }
        public string ServicingFacility { get; set; }
        public string BedStatus { get; set; }
        public string AccountStatus { get; set; }
        public string PendingLocation { get; set; }
        public string PriorTemporaryLocation { get; set; }
        public string AdmitDateTime { get; set; }
        public string DischargeDateTime { get; set; }
        public string CurrentPatientBalance { get; set; }
        public string TotalCharges { get; set; }
        public string TotalAdjustments { get; set; }
        public string TotalPayments { get; set; }
        public string AlternateVisitID { get; set; }
        public string VisitIndicator { get; set; }
        public string OtherHealthcareProvider { get; set; }


        public PV1 GetSegment(string segmentText)
        {
            var segment = new PV1();
            const string messageSegmentType = "PV1";

            if (string.IsNullOrWhiteSpace(segmentText) || segmentText.Substring(0, messageSegmentType.Length) != messageSegmentType)
            {
                throw new Exception($"{messageSegmentType}: {segmentText} does not start with {messageSegmentType}");
            }

            segmentText = segmentText.Substring(messageSegmentType.Length, segmentText.Length - messageSegmentType.Length);

            var fieldSeparator = char.Parse(segmentText.Substring(0, 1));
            segmentText = segmentText.Substring(1, segmentText.Length - 1); //Remove the first field Separator
            var fields = segmentText.Split(fieldSeparator);

            var propertyInfo = segment.GetType().GetProperties();
            for (var i = 0; i < propertyInfo.Length; i++)
            {
                var attribute = (RequiredFieldAttribute)propertyInfo[i].GetCustomAttributes(typeof(RequiredFieldAttribute), false).FirstOrDefault();

                if (attribute != null && attribute.Required && string.IsNullOrWhiteSpace(fields[i]))
                {
                    throw new Exception($"{messageSegmentType}: {segmentText} does not have mandatory field {propertyInfo[i].Name} at position {i + 1}");
                }

                if (i < fields.Length)
                {
                    propertyInfo[i].SetValue(segment, fields[i]);
                }
            }

            return segment;
        }
    }
}

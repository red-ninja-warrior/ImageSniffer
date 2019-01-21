using System;
using System.Collections.Generic;
using System.Text;

namespace Sniffer.HL7.SegmentType
{
    public class IN1
    {
        public string SetId { get; set; }
        public string InsurancePlanId { get; set; }
        public string InsuranceCompanyId { get; set; }
        public string InsuranceCompanyName { get; set; }
        public string InsuranceCompanyAddress { get; set; }
        public string InsuranceCoContactPerson { get; set; }
        public string InsuranceCoPhoneNumber { get; set; }
        public string GroupNumber { get; set; }
        public string GroupName { get; set; }
        public string InsuredGroupEmpId { get; set; }
        public string InsuredGroupEmpName { get; set; }
        public string PlanEffectiveDate { get; set; }
        public string PlanExpirationDate { get; set; }
        public string AuthorizationInformation { get; set; }
        public string PlanType { get; set; }
        public string NameOfInsured { get; set; }
        public string InsuredsRelationshipToPatient { get; set; }
        public string InsuredsDateOfBirth { get; set; }
        public string InsuredsAddress { get; set; }
        public string AssignmentOfBenefits { get; set; }
        public string CoordinationOfBenefits { get; set; }
        public string CoordOfBenPriority { get; set; }
        public string NoticeOfAdmissionFlag { get; set; }
        public string NoticeOfAdmissionDate { get; set; }
        public string ReportOfEligibilityFlag { get; set; }
        public string ReportOfEligibilityDate { get; set; }
        public string ReleaseInformationCode { get; set; }
        public string PreAdmitCert { get; set; }
        public string VerificationDateTime { get; set; }
        public string VerificationBy { get; set; }
        public string TypeOfAgreementCode { get; set; }
        public string BillingStatus { get; set; }
        public string LifetimeReserveDays { get; set; }
        public string DelayBeforeLRDay { get; set; }
        public string CompanyPlanCode { get; set; }
        public string PolicyNumber { get; set; }
        public string PolicyDeductible { get; set; }
        public string PolicyLimitAmount { get; set; }
        public string PolicyLimitDays { get; set; }
        public string RoomRateSemiPrivate { get; set; }
        public string RoomRatePrivate { get; set; }
        public string InsuredsEmploymentStatus { get; set; }
        public string InsuredsAdministrativeSex { get; set; }
        public string InsuredsEmployersAddress { get; set; }
        public string VerificationStatus { get; set; }
        public string PriorInsurancePlanId { get; set; }
        public string CoverageType { get; set; }
        public string Handicap { get; set; }
        public string InsuredsIdNumber { get; set; }
        public string SignatureCode { get; set; }
        public string SignatureCodeDate { get; set; }
        public string InsuredsBirthPlace { get; set; }
        public string VipIndicator { get; set; }

    }
}
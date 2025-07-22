using System;
using System.Collections.Generic;

namespace ShriramInsight;

public partial class TblGiPolicyBook
{
    public int AgentTypeId { get; set; }

    public decimal OrderNo { get; set; }

    public int CentreNo { get; set; }

    public string CustomerName { get; set; } = null!;

    public int? Age { get; set; }

    public string? ContactNo { get; set; }

    public string? EmailId { get; set; }

    public string Address { get; set; } = null!;

    public int StateNo { get; set; }

    public int? Pin { get; set; }

    public string? PolicyNo { get; set; }

    public DateTime? PolicyDate { get; set; }

    public byte PolicyPartyTypeId { get; set; }

    public byte RenewalPolicyId { get; set; }

    public string? VehicleNo { get; set; }

    public string VehicleMake { get; set; } = null!;

    public byte VehicleTypeId { get; set; }

    public string? VehicleModel { get; set; }

    public string? VehicleVariant { get; set; }

    public string? EngineNo { get; set; }

    public string? ChassisNo { get; set; }

    public string? Rtocode { get; set; }

    public int? ManufacturingYear { get; set; }

    public decimal? Idv { get; set; }

    public byte? IsClaimLastYear { get; set; }

    public decimal? PrevNcb { get; set; }

    public DateTime? PolicyExpDate { get; set; }

    public string? PreviousPolicyNo { get; set; }

    public string? PreviousInsuranceCompany { get; set; }

    public byte InsuranceCoId { get; set; }

    public decimal? AmountRecvFromParty { get; set; }

    public decimal? CommissionPayoutInCash { get; set; }

    public decimal? DamagePremiumAmount { get; set; }

    public decimal? ThirdPartyPremiumAmount { get; set; }

    public int EntryUserNo { get; set; }

    public int? ModifiedUserNo { get; set; }

    public DateTime ProcessDateTime { get; set; }

    public DateTime? ModifiedDateTime { get; set; }

    public int PolicyStatusNo { get; set; }

    public DateTime? MoneyRecptDate { get; set; }

    public string? Remarks { get; set; }

    public string? AdditionalInfo { get; set; }

    public decimal? CommissionPer { get; set; }

    public decimal? CommissionAmount { get; set; }

    public byte? IsPaymentMode { get; set; }

    public byte? IsUrgent { get; set; }

    public byte? OtherRtoState { get; set; }

    public string? BankDetails { get; set; }

    public byte? ChqRecvId { get; set; }

    public byte? MemberType { get; set; }

    public string? NomineeDetails { get; set; }

    public string? RelationWithNominee { get; set; }

    public int? NomineeAge { get; set; }

    public string? GuardianDetails { get; set; }

    public byte? CoverageType { get; set; }

    public byte? PersonalAccident { get; set; }

    public byte? RoadSideAssistance { get; set; }

    public byte? AddOnservice { get; set; }

    public byte? FuelType { get; set; }

    public byte? HypothecatedBy { get; set; }

    public decimal? Ncbdiscount { get; set; }

    public decimal? TotalPremiumAmount { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedWhen { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedWhen { get; set; }

    public bool IsActive { get; set; }
}

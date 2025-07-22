using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ShriramInsight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblGiPolicyBookController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TblGiPolicyBookController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string ConnectionString => _configuration.GetConnectionString("DefaultConnection");

        // ✅ GET: Fetch all active policies
        [HttpGet]
        public IActionResult GetAll()
        {
            var policies = new List<TblGiPolicyBook>();

            using var conn = new SqlConnection(ConnectionString);
            using var cmd = new SqlCommand("GetAll_tbl_gi_policy_book", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                policies.Add(new TblGiPolicyBook
                {
                    OrderNo = (decimal)reader["OrderNo"],
                    AgentTypeId = (byte)reader["AgentTypeId"],
                    CentreNo = (int)reader["CentreNo"],
                    CustomerName = reader["CustomerName"].ToString(),
                    Age = reader["Age"] as int?,
                    ContactNo = reader["ContactNo"]?.ToString(),
                    EmailId = reader["EmailId"]?.ToString(),
                    Address = reader["Address"]?.ToString(),
                    StateNo = (int)reader["StateNo"],
                    Pin = reader["Pin"] as int?,
                    PolicyNo = reader["PolicyNo"]?.ToString(),
                    PolicyDate = reader["PolicyDate"] as DateTime?,
                    PolicyPartyTypeId = (byte)reader["PolicyPartyTypeId"],
                    RenewalPolicyId = (byte)reader["RenewalPolicyId"],
                    VehicleNo = reader["VehicleNo"]?.ToString(),
                    VehicleMake = reader["VehicleMake"]?.ToString(),
                    VehicleTypeId = (byte)reader["VehicleTypeId"],
                    VehicleModel = reader["VehicleModel"]?.ToString(),
                    VehicleVariant = reader["VehicleVariant"]?.ToString(),
                    EngineNo = reader["EngineNo"]?.ToString(),
                    ChassisNo = reader["ChassisNo"]?.ToString(),
                    Rtocode = reader["RTOCode"]?.ToString(),
                    ManufacturingYear = reader["ManufacturingYear"] as int?,
                    Idv = reader["IDV"] as decimal?,
                    IsClaimLastYear = reader["IsClaimLastYear"] as byte?,
                    PrevNcb = reader["Prev_NCB"] as decimal?,
                    PolicyExpDate = reader["PolicyExpDate"] as DateTime?,
                    PreviousPolicyNo = reader["PreviousPolicyNo"]?.ToString(),
                    PreviousInsuranceCompany = reader["PreviousInsuranceCompany"]?.ToString(),
                    InsuranceCoId = (byte)reader["InsuranceCoId"],
                    AmountRecvFromParty = reader["AmountRecvFromParty"] as decimal?,
                    CommissionPayoutInCash = reader["CommissionPayoutInCash"] as decimal?,
                    DamagePremiumAmount = reader["DamagePremiumAmount"] as decimal?,
                    ThirdPartyPremiumAmount = reader["ThirdPartyPremiumAmount"] as decimal?,
                    EntryUserNo = (int)reader["EntryUserNo"],
                    ModifiedUserNo = reader["ModifiedUserNo"] as int?,
                    ProcessDateTime = (DateTime)reader["ProcessDateTime"],
                    ModifiedDateTime = reader["ModifiedDateTime"] as DateTime?,
                    PolicyStatusNo = (int)reader["PolicyStatusNo"],
                    MoneyRecptDate = reader["MoneyRecptDate"] as DateTime?,
                    Remarks = reader["Remarks"]?.ToString(),
                    AdditionalInfo = reader["AdditionalInfo"]?.ToString(),
                    CommissionPer = reader["CommissionPer"] as decimal?,
                    CommissionAmount = reader["CommissionAmount"] as decimal?,
                    IsPaymentMode = reader["IsPaymentMode"] as byte?,
                    IsUrgent = reader["IsUrgent"] as byte?,
                    OtherRtoState = reader["OtherRtoState"] as byte?,
                    BankDetails = reader["BankDetails"]?.ToString(),
                    ChqRecvId = reader["ChqRecvId"] as byte?,
                    MemberType = reader["memberType"] as byte?,
                    NomineeDetails = reader["NomineeDetails"]?.ToString(),
                    RelationWithNominee = reader["RelationWithNominee"]?.ToString(),
                    NomineeAge = reader["NomineeAge"] as int?,
                    GuardianDetails = reader["GuardianDetails"]?.ToString(),
                    CoverageType = reader["CoverageType"] as byte?,
                    PersonalAccident = reader["personalAccident"] as byte?,
                    RoadSideAssistance = reader["roadSideAssistance"] as byte?,
                    AddOnservice = reader["addOnservice"] as byte?,
                    FuelType = reader["fuelType"] as byte?,
                    HypothecatedBy = reader["hypothecatedBy"] as byte?,
                    Ncbdiscount = reader["NCBDiscount"] as decimal?,
                    TotalPremiumAmount = reader["TotalPremiumAmount"] as decimal?,
                    CreatedBy = reader["CreatedBy"]?.ToString(),
                    CreatedWhen = (DateTime)reader["CreatedWhen"],
                    UpdatedBy = reader["UpdatedBy"]?.ToString(),
                    UpdatedWhen = reader["UpdatedWhen"] as DateTime?,
                    IsActive = (bool)reader["IsActive"]
                });
            }
            return Ok(policies);
        }

        // ✅ POST: Insert a new policy
        [HttpPost]
        public IActionResult Insert([FromBody] TblGiPolicyBook model)
        {
            using var conn = new SqlConnection(ConnectionString);
            using var cmd = new SqlCommand("InsertInto_tbl_gi_policy_book", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Required parameters
            cmd.Parameters.AddWithValue("@AgentTypeId", model.AgentTypeId);
            cmd.Parameters.AddWithValue("@OrderNo", model.OrderNo);
            cmd.Parameters.AddWithValue("@CentreNo", model.CentreNo);
            cmd.Parameters.AddWithValue("@CustomerName", model.CustomerName);
            cmd.Parameters.AddWithValue("@Age", (object?)model.Age ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Address", model.Address);
            cmd.Parameters.AddWithValue("@StateNo", model.StateNo);
            cmd.Parameters.AddWithValue("@Pin", (object?)model.Pin ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@EmailId", (object?)model.EmailId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ContactNo", (object?)model.ContactNo ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@PolicyPartyTypeId", model.PolicyPartyTypeId);
            cmd.Parameters.AddWithValue("@RenewalPolicyId", model.RenewalPolicyId);
            cmd.Parameters.AddWithValue("@VehicleNo", (object?)model.VehicleNo ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@VehicleMake", model.VehicleMake);
            cmd.Parameters.AddWithValue("@VehicleTypeId", model.VehicleTypeId);
            cmd.Parameters.AddWithValue("@VehicleModel", (object?)model.VehicleModel ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@VehicleVariant", (object?)model.VehicleVariant ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@EngineNo", (object?)model.EngineNo ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ChassisNo", (object?)model.ChassisNo ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@RTOCode", (object?)model.Rtocode ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ManufacturingYear", (object?)model.ManufacturingYear ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@IDV", (object?)model.Idv ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@IsClaimLastYear", (object?)model.IsClaimLastYear ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Prev_NCB", (object?)model.PrevNcb ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@PolicyExpDate", (object?)model.PolicyExpDate ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@PreviousPolicyNo", (object?)model.PreviousPolicyNo ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@PreviousInsuranceCompany", (object?)model.PreviousInsuranceCompany ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@InsuranceCoId", model.InsuranceCoId);
            cmd.Parameters.AddWithValue("@AmountRecvFromParty", (object?)model.AmountRecvFromParty ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CommissionPayoutInCash", (object?)model.CommissionPayoutInCash ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@DamagePremiumAmount", (object?)model.DamagePremiumAmount ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ThirdPartyPremiumAmount", (object?)model.ThirdPartyPremiumAmount ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@EntryUserNo", model.EntryUserNo);
            cmd.Parameters.AddWithValue("@PolicyStatusNo", model.PolicyStatusNo);
            cmd.Parameters.AddWithValue("@ProcessDateTime", model.ProcessDateTime);
            cmd.Parameters.AddWithValue("@PolicyNo", (object?)model.PolicyNo ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CommissionPer", (object?)model.CommissionPer ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CommissionAmount", (object?)model.CommissionAmount ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@IsPaymentMode", (object?)model.IsPaymentMode ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@IsUrgent", (object?)model.IsUrgent ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@OtherRtoState", (object?)model.OtherRtoState ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@BankDetails", (object?)model.BankDetails ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ChqRecvId", (object?)model.ChqRecvId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@memberType", (object?)model.MemberType ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@NomineeDetails", (object?)model.NomineeDetails ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@RelationWithNominee", (object?)model.RelationWithNominee ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@NomineeAge", (object?)model.NomineeAge ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@GuardianDetails", (object?)model.GuardianDetails ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CoverageType", (object?)model.CoverageType ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@personalAccident", (object?)model.PersonalAccident ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@roadSideAssistance", (object?)model.RoadSideAssistance ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@addOnservice", (object?)model.AddOnservice ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@fuelType", (object?)model.FuelType ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@hypothecatedBy", (object?)model.HypothecatedBy ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@NCBDiscount", (object?)model.Ncbdiscount ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@TotalPremiumAmount", (object?)model.TotalPremiumAmount ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy ?? "SYSTEM");

            conn.Open();
            cmd.ExecuteNonQuery();

            return Ok(new { message = "Policy inserted successfully." });
        }

        // ✅ PUT: Update existing policy (limited fields)
        [HttpPut("{orderNo}")]
        public IActionResult Update(decimal orderNo, [FromBody] TblGiPolicyBook model)
        {
            using var conn = new SqlConnection(ConnectionString);
            using var cmd = new SqlCommand("Update_tbl_gi_policy_book", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@OrderNo", orderNo);
            cmd.Parameters.AddWithValue("@CustomerName", model.CustomerName);
            cmd.Parameters.AddWithValue("@Age", (object?)model.Age ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ContactNo", (object?)model.ContactNo ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@EmailId", (object?)model.EmailId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Address", model.Address);
            cmd.Parameters.AddWithValue("@Pin", (object?)model.Pin ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@PolicyNo", (object?)model.PolicyNo ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@PolicyDate", (object?)model.PolicyDate ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@VehicleNo", (object?)model.VehicleNo ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@VehicleMake", model.VehicleMake);
            cmd.Parameters.AddWithValue("@VehicleModel", (object?)model.VehicleModel ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@VehicleVariant", (object?)model.VehicleVariant ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@EngineNo", (object?)model.EngineNo ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ChassisNo", (object?)model.ChassisNo ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@UpdatedBy", model.UpdatedBy ?? "SYSTEM");

            conn.Open();
            int rows = cmd.ExecuteNonQuery();

            return rows > 0
                ? Ok(new { message = "Policy updated successfully." })
                : NotFound(new { message = "Policy not found or inactive." });
        }

        // ✅ DELETE: Soft delete policy
        [HttpDelete("{orderNo}")]
        public IActionResult SoftDelete(decimal orderNo, [FromQuery] string updatedBy)
        {
            using var conn = new SqlConnection(ConnectionString);
            using var cmd = new SqlCommand("SoftDelete_tbl_gi_policy_book", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@OrderNo", orderNo);
            cmd.Parameters.AddWithValue("@UpdatedBy", updatedBy ?? "SYSTEM");

            conn.Open();
            int rows = cmd.ExecuteNonQuery();

            return rows > 0
                ? Ok(new { message = "Policy soft deleted successfully." })
                : NotFound(new { message = "Policy not found or already inactive." });
        }
    }
}
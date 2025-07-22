using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ShriramInsight;
using System.Data;

namespace ShriramInsight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblProposedInsurerController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TblProposedInsurerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // ✅ GET: Fetch all active insurers
        [HttpGet]
        public IActionResult GetAll()
        {
            var insurers = new List<TblProposedInsurer>();

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("GetAllProposedInsurers", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                insurers.Add(new TblProposedInsurer
                {
                    InsurerId = Convert.ToInt32(reader["InsurerId"]),
                    InsurerName = reader["InsurerName"].ToString(),
                    CreatedBy = reader["CreatedBy"]?.ToString(),
                    CreatedWhen = reader["CreatedWhen"] as DateTime?,
                    UpdatedBy = reader["UpdatedBy"]?.ToString(),
                    UpdatedWhen = reader["UpdatedWhen"] as DateTime?,
                    IsActive = Convert.ToBoolean(reader["IsActive"])
                });
            }
            return Ok(insurers);
        }

        // ✅ POST: Insert new insurer
        [HttpPost]
        public IActionResult Insert([FromBody] TblProposedInsurer model)
        {
            if (string.IsNullOrEmpty(model.InsurerName))
                return BadRequest("InsurerName is required.");

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("InsertInto_tbl_proposed_insurer", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@InsurerName", model.InsurerName);
            cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy ?? (object)DBNull.Value);

            conn.Open();
            cmd.ExecuteNonQuery();

            return Ok("Insurer inserted successfully.");
        }

        // ✅ PUT: Update insurer
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TblProposedInsurer model)
        {
            if (string.IsNullOrEmpty(model.InsurerName))
                return BadRequest("InsurerName is required.");

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("Update_tbl_proposed_insurer", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@InsurerId", id);
            cmd.Parameters.AddWithValue("@InsurerName", model.InsurerName);
            cmd.Parameters.AddWithValue("@UpdatedBy", model.UpdatedBy ?? (object)DBNull.Value);

            conn.Open();
            cmd.ExecuteNonQuery();

            return Ok("Insurer updated successfully.");
        }

        // ✅ DELETE: Soft delete
        [HttpDelete("{id}")]
        public IActionResult SoftDelete(int id)
        {
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("SoftDelete_tbl_proposed_insurer", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@InsurerId", id);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();

            return rows > 0
                ? Ok(new { message = "Insurer soft deleted successfully." })
                : NotFound(new { message = "Insurer not found." });
        }
    }
}
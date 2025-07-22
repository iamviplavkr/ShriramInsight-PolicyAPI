using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ShriramInsight;
using System.Collections.Generic;
using System.Data;

namespace ShriramInsight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblPolicyTypeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TblPolicyTypeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var policyTypes = new List<TblPolicyType>();

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("GetAllPolicyTypes", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                policyTypes.Add(new TblPolicyType
                {
                    PolicyTypeId = Convert.ToInt32(reader["PolicyTypeId"]),
                    PolicyTypeDesc = reader["PolicyTypeDesc"].ToString(),
                    CreatedBy = reader["CreatedBy"]?.ToString(),
                    CreatedWhen = reader["CreatedWhen"] as DateTime?,
                    UpdatedBy = reader["UpdatedBy"]?.ToString(),
                    UpdatedWhen = reader["UpdatedWhen"] as DateTime?,
                    IsActive = Convert.ToBoolean(reader["IsActive"])
                });
            }

            return Ok(policyTypes);
        }


        [HttpPost]
        public IActionResult Insert([FromBody] TblPolicyType model)
        {
            if (string.IsNullOrEmpty(model.PolicyTypeDesc))
                return BadRequest("PolicyTypeDesc is required.");

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("InsertInto_tbl_policy_type", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@PolicyTypeDesc", model.PolicyTypeDesc);
            cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy ?? (object)DBNull.Value);

            conn.Open();
            cmd.ExecuteNonQuery();

            return Ok("Policy Type inserted successfully.");
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TblPolicyType model)
        {
            if (string.IsNullOrEmpty(model.PolicyTypeDesc))
                return BadRequest("PolicyTypeDesc is required.");

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("Update_tbl_policy_type", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@PolicyTypeId", id);
            cmd.Parameters.AddWithValue("@PolicyTypeDesc", model.PolicyTypeDesc);
            cmd.Parameters.AddWithValue("@UpdatedBy", model.UpdatedBy ?? (object)DBNull.Value);

            conn.Open();
            cmd.ExecuteNonQuery();

            return Ok("Policy Type updated successfully.");
        }

        // ✅ DELETE: Soft Delete (IsActive = 0)
        [HttpDelete("{id}")]
        public IActionResult SoftDelete(int id)
        {
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("SoftDelete_tbl_policy_type", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@PolicyTypeId", id);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();

            return rows > 0
                ? Ok(new { message = "Policy Type soft deleted successfully." })
                : NotFound(new { message = "Policy Type not found." });
        }
    }
}
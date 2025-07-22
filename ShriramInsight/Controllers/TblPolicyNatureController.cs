using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ShriramInsight;
using System.Collections.Generic;
using System.Data;

namespace ShriramInsight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblPolicyNatureController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TblPolicyNatureController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET all (only active)
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = new List<TblPolicyNature>();

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("SELECT * FROM tbl_policy_nature WHERE IsActive = 1", conn);

            conn.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                result.Add(new TblPolicyNature
                {
                    PolicyNatureId = Convert.ToInt32(reader["PolicyNatureId"]),
                    PolicyNatureDesc = reader["PolicyNatureDesc"].ToString(),
                    CreatedBy = reader["CreatedBy"]?.ToString(),
                    CreatedWhen = reader["CreatedWhen"] as DateTime?,
                    UpdatedBy = reader["UpdatedBy"]?.ToString(),
                    UpdatedWhen = reader["UpdatedWhen"] as DateTime?,
                    IsActive = Convert.ToBoolean(reader["IsActive"])
                });
            }

            return Ok(result);
        }

        // POST
        [HttpPost]
        public IActionResult Insert([FromBody] TblPolicyNature model)
        {
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("InsertInto_tbl_policy_nature", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@PolicyNatureDesc", model.PolicyNatureDesc);
            cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy ?? (object)DBNull.Value);

            conn.Open();
            cmd.ExecuteNonQuery();

            return Ok("Policy nature inserted successfully.");
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TblPolicyNature model)
        {
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("Update_tbl_policy_nature", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@PolicyNatureId", id);
            cmd.Parameters.AddWithValue("@PolicyNatureDesc", model.PolicyNatureDesc);
            cmd.Parameters.AddWithValue("@UpdatedBy", model.UpdatedBy ?? (object)DBNull.Value);

            conn.Open();
            cmd.ExecuteNonQuery();

            return Ok("Policy nature updated successfully.");
        }

        // Soft DELETE
        [HttpDelete("{id}")]
        public IActionResult SoftDelete(int id)
        {
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("SoftDelete_tbl_policy_nature", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@PolicyNatureId", id);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();

            return rows > 0
                ? Ok("Policy nature soft-deleted successfully.")
                : NotFound("Policy nature not found.");
        }
    }
}

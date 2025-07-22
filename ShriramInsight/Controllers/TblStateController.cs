using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ShriramInsight;
using System.Data;

namespace ShriramInsight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblStateController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TblStateController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // ✅ GET: Fetch all active states
        [HttpGet]
        public IActionResult GetAll()
        {
            var states = new List<TblState>();

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("GetAllStates", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                states.Add(new TblState
                {
                    StateId = Convert.ToInt32(reader["StateId"]),
                    StateDesc = reader["StateDesc"].ToString(),
                    Zone = reader["Zone"] as byte?,
                    CreatedBy = reader["CreatedBy"]?.ToString(),
                    CreatedWhen = reader["CreatedWhen"] as DateTime?,
                    UpdatedBy = reader["UpdatedBy"]?.ToString(),
                    UpdatedWhen = reader["UpdatedWhen"] as DateTime?,
                    IsActive = Convert.ToBoolean(reader["IsActive"])
                });
            }
            return Ok(states);
        }

        // ✅ POST: Insert new state
        [HttpPost]
        public IActionResult Insert([FromBody] TblState model)
        {
            if (model.StateId <= 0 || string.IsNullOrEmpty(model.StateDesc))
                return BadRequest("StateId and StateDesc are required.");

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("InsertInto_tbl_state", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@StateId", model.StateId);
            cmd.Parameters.AddWithValue("@StateDesc", model.StateDesc);
            cmd.Parameters.AddWithValue("@Zone", model.Zone ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy ?? (object)DBNull.Value);

            conn.Open();
            cmd.ExecuteNonQuery();

            return Ok("State inserted successfully.");
        }

        // ✅ PUT: Update state
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TblState model)
        {
            if (string.IsNullOrEmpty(model.StateDesc))
                return BadRequest("StateDesc is required.");

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("Update_tbl_state", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@StateId", id);
            cmd.Parameters.AddWithValue("@StateDesc", model.StateDesc);
            cmd.Parameters.AddWithValue("@Zone", model.Zone ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@UpdatedBy", model.UpdatedBy ?? (object)DBNull.Value);

            conn.Open();
            cmd.ExecuteNonQuery();

            return Ok("State updated successfully.");
        }

        // ✅ DELETE: Soft delete state
        [HttpDelete("{id}")]
        public IActionResult SoftDelete(int id)
        {
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("SoftDelete_tbl_state", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@StateId", id);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();

            return rows > 0
                ? Ok(new { message = "State soft deleted successfully." })
                : NotFound(new { message = "State not found." });
        }
    }
}
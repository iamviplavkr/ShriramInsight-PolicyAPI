using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ShriramInsight;
using System.Data;

namespace ShriramInsight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblMemberTypeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TblMemberTypeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var memberTypes = new List<TblMemberType>();

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("GetAllFrom_tbl_member_type", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                memberTypes.Add(new TblMemberType
                {
                    MemberTypeId = Convert.ToByte(reader["MemberTypeId"]),
                    MemberTypeDesc = reader["MemberTypeDesc"].ToString(),
                    CreatedBy = reader["CreatedBy"]?.ToString(),
                    CreatedWhen = reader["CreatedWhen"] as DateTime?,
                    UpdatedBy = reader["UpdatedBy"]?.ToString(),
                    UpdatedWhen = reader["UpdatedWhen"] as DateTime?,
                    IsActive = Convert.ToBoolean(reader["IsActive"])
                });
            }
            return Ok(memberTypes);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] TblMemberType model)
        {
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("InsertInto_tbl_member_type", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@MemberTypeDesc", model.MemberTypeDesc);
            cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy ?? (object)DBNull.Value);

            conn.Open();
            cmd.ExecuteNonQuery();

            return Ok("Member type inserted successfully.");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TblMemberType model)
        {
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("Update_tbl_member_type", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Fix casting to byte for SQL tinyint
            cmd.Parameters.AddWithValue("@MemberTypeId", (byte)id);
            cmd.Parameters.AddWithValue("@MemberTypeDesc", model.MemberTypeDesc);
            cmd.Parameters.AddWithValue("@UpdatedBy", model.UpdatedBy ?? (object)DBNull.Value);

            conn.Open();
            cmd.ExecuteNonQuery();

            return Ok("Member type updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult SoftDelete(int id)
        {
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("SoftDelete_tbl_member_type", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            // 👇 Fix casting to byte
            cmd.Parameters.AddWithValue("@MemberTypeId", (byte)id);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            return rows > 0
                ? Ok(new { message = "Member type soft-deleted." })
                : NotFound(new { message = "Member type not found." });
        }
    }
}

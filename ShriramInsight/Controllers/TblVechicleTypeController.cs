using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ShriramInsight;
using System.Data;

namespace ShriramInsight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblVehicleTypeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TblVehicleTypeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // ✅ GET: Fetch all active vehicle types
        [HttpGet]
        public IActionResult GetAll()
        {
            var vehicleTypes = new List<TblVehicleType>();

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("GetAllVehicleTypes", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                vehicleTypes.Add(new TblVehicleType
                {
                    VehicleTypeId = Convert.ToInt32(reader["VehicleTypeId"]),
                    VehicleTypeDesc = reader["VehicleTypeDesc"].ToString(),
                    CreatedBy = reader["CreatedBy"]?.ToString(),
                    CreatedWhen = reader["CreatedWhen"] as DateTime?,
                    UpdatedBy = reader["UpdatedBy"]?.ToString(),
                    UpdatedWhen = reader["UpdatedWhen"] as DateTime?,
                    IsActive = Convert.ToBoolean(reader["IsActive"])
                });
            }
            return Ok(vehicleTypes);
        }

        // ✅ POST: Insert new vehicle type
        [HttpPost]
        public IActionResult Insert([FromBody] TblVehicleType model)
        {
            if (string.IsNullOrEmpty(model.VehicleTypeDesc))
                return BadRequest("VehicleTypeDesc is required.");

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("InsertInto_tbl_vehicle_type", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@VehicleTypeDesc", model.VehicleTypeDesc);
            cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy ?? (object)DBNull.Value);

            conn.Open();
            cmd.ExecuteNonQuery();

            return Ok("Vehicle type inserted successfully.");
        }

        // ✅ PUT: Update vehicle type
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TblVehicleType model)
        {
            if (string.IsNullOrEmpty(model.VehicleTypeDesc))
                return BadRequest("VehicleTypeDesc is required.");

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("Update_tbl_vehicle_type", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@VehicleTypeId", id);
            cmd.Parameters.AddWithValue("@VehicleTypeDesc", model.VehicleTypeDesc);
            cmd.Parameters.AddWithValue("@UpdatedBy", model.UpdatedBy ?? (object)DBNull.Value);

            conn.Open();
            cmd.ExecuteNonQuery();

            return Ok("Vehicle type updated successfully.");
        }

        // ✅ DELETE: Soft delete vehicle type
        [HttpDelete("{id}")]
        public IActionResult SoftDelete(int id)
        {
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("SoftDelete_tbl_vehicle_type", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@VehicleTypeId", id);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();

            return rows > 0
                ? Ok(new { message = "Vehicle type soft deleted successfully." })
                : NotFound(new { message = "Vehicle type not found." });
        }
    }
}

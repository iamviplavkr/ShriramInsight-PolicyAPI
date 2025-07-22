
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ShriramInsight;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Last.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblFuelTypeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TblFuelTypeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetFuelTypes()
        {
            var fuelTypes = new List<TblFuelType>();

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("GetAllFrom_tbl_fuel_type", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                fuelTypes.Add(new TblFuelType
                {
                    FuelTypeId = Convert.ToByte(reader["FuelTypeId"]),
                    FuelTypeDesc = reader["FuelTypeDesc"].ToString(),
                    CreatedBy = reader["CreatedBy"]?.ToString(),
                    CreatedWhen = reader["CreatedWhen"] as DateTime?,
                    UpdatedBy = reader["UpdatedBy"]?.ToString(),
                    UpdatedWhen = reader["UpdatedWhen"] as DateTime?,
                    IsActive = Convert.ToBoolean(reader["IsActive"])
                });
            }

            return Ok(fuelTypes);
        }


        [HttpPost]
        public IActionResult InsertFuelType([FromBody] TblFuelType model)
        {
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("InsertInto_tbl_fuel_type", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@FuelTypeDesc", model.FuelTypeDesc);
            cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy ?? (object)DBNull.Value);
            // No CreatedWhen here!


            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            return Ok("Fuel type inserted successfully.");
        }


        [HttpPut("{id}")]
        public IActionResult UpdateFuelType(int id, [FromBody] TblFuelType model)
        {
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("Update_tbl_fuel_type", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@FuelTypeId", id);
            cmd.Parameters.AddWithValue("@FuelTypeDesc", model.FuelTypeDesc);
            cmd.Parameters.AddWithValue("@UpdatedBy", model.UpdatedBy ?? (object)DBNull.Value);
            // No UpdatedWhen here!


            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            return Ok("Fuel type updated successfully.");
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteFuelType(byte id)
        {
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("SoftDelete_tbl_fuel_type", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@FuelTypeId", id);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();

            if (rows > 0)
                return Ok(new { message = "Fuel type deleted successfully." });
            else
                return NotFound(new { message = $"Fuel type with ID = {id} not found." });
        }



    }
}

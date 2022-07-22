using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Telex.Models;
using Telex.Repository;

namespace Telex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewController : ControllerBase
    {
        private readonly INewRepository _companyRepo;
        public NewController(INewRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }

        // Insert the sessionkey

        [HttpPost("Session")]
        public async Task<IActionResult> INS(Session ses)
        {
            try
            {

                var ins = await _companyRepo.INS(ses);
                return Ok(ins);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        // Insert Logout Date


        [HttpPut("Logout")]
        public async Task<IActionResult> LOGOUT(Logout LOGOUTTIME)
        {
            try
            {
                var logout = await _companyRepo.LOGOUT(LOGOUTTIME);
                return Ok("Updated");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Get the InActive Employee

        [HttpGet("{Status}")]
        public async Task<IActionResult> GETEMP(string Status)
        {
            try
            {
                var emp = await _companyRepo.GETEMP(Status);
                return Ok(emp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        // Increase the Salary 10%

        [HttpPut("Update Salary")]
        public async Task<IActionResult> salary()
        {
            try
            {
                var update = await _companyRepo.salary();
                return Ok("Successfully Updated");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Get Particular Department Employee Details.


        [HttpGet("{DepartmentName}/id")]
        public async Task<IActionResult> GETDNID(string DepartmentName)
        {
            try
            {
                var id = await _companyRepo.GETDN(DepartmentName);
                var dep = await _companyRepo.GETID(id);                    //Get above return ID and return EMP details
                return Ok(dep);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Get the InActive DepartmentID and Delete the Employee based on DepartmentID.

        [HttpDelete("{Status}/Delete")]
        public async Task<IActionResult> GETDEL(string Status)
        {
            try
            {
                var id = await _companyRepo.GETDELID(Status);
                var dep = await _companyRepo.DEL1(id);            // Get above Return ID and Delete the Emp  on table1
                var dep2 = await _companyRepo.DEL2(id);          // Get above Return ID and Delete the Emp  on table2
                return Ok("Sucessfully Deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Insert new employee Based on store procedure.

        [HttpPost("InsertEmp")]
        public async Task<IActionResult> InsertEmp(Insert creat)
        {
            try
            {
                var create = await _companyRepo.InsertEmp(creat);
                return Ok("Insert successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        // Get the IN Active EmpID  ANd Updated any one EmpID

        [HttpPut("{Status}/Change Active")]
    
        public async Task<IActionResult> GETST(string Status)
        {
            try
            {
                var id=await _companyRepo.GETST(Status);
                var dep = await _companyRepo.UpdateAct(id);            // Get the above ID  and update In Active to Active.
                return Ok("Successfully updated");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }

}




using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Telex.Context;
using Telex.Models;

namespace Telex.Repository
{
    public class NewRepository : INewRepository
    {

        private readonly DapperContext _context;
        public NewRepository(DapperContext context)
        {
            _context = context;
        }

        // Insert Sessionkey.

        public async Task<Session> INS(Session ses)    
        {
            var query = "insert into Login (EmployeeEmailID,EmployeeID,Sessionkey,LoggedInDateTime,CreatedBY,CreatedDate,ModifiedBY,ModifiedDate) values (@EmployeeEmailID,@EmployeeID,@Sessionkey,@LoggedInDateTime,@CreatedBY,@CreatedDate,@ModifiedBY,@ModifiedDate)";
            using (var connecion = _context.Createconnection())
            {
                var parameters = new DynamicParameters();
            parameters.Add("EmployeeEmailID", ses.EmployeeEmailID, DbType.String); 
            parameters.Add("EmployeeID", ses.EmployeeID, DbType.Int32);
            parameters.Add("Sessionkey", ses.Sessionkey, DbType.String);
            parameters.Add("CreatedBY", ses.CreatedBY, DbType.Int32);
            parameters.Add("LoggedInDateTime", ses.LoggedInDateTime, DbType.DateTime);

            parameters.Add("CreatedDate", ses.CreatedDate, DbType.DateTime);
            parameters.Add("ModifiedBY", ses.ModifiedBY, DbType.Int32);
            parameters.Add("ModifiedDate", ses.ModifiedDate, DbType.DateTime);
      
                var com= await connecion.QueryFirstOrDefaultAsync(query,parameters);
                return com;
            }
        }


        // Insert Logout Date

        public async Task<Logout> LOGOUT(Logout LOGOUTTIME)
        {
             
            var query = @"update Login set LoggedOutDateTime=@LoggedOutDateTime where EmployeeEmailID=@EmployeeEmailID AND Sessionkey=@Sessionkey";
            
            using (var connecion = _context.Createconnection())
            {
                var Sal = await connecion.QuerySingleOrDefaultAsync<Logout>(query, LOGOUTTIME);

                return Sal;

            }
        }


        // Get the InActive Employee

        public async Task<IEnumerable<Getall>> GETEMP(string Status)       
        {
            var query = "select o.EmployeeID,o.EmployeeEmailID,o.EmployeePassword,o.EmployeeDepartmentID,o.EmployeeFirstName,o.EmployeeLastName,o.EmployeeCity,o.Status,o.CreatedBY,o.CreatedDate,o.ModifiedBY,o.ModifiedDate,l.EmployeeSalary,l.EmployeeRole from Employee o left join EmployeeInfo l on o.EmployeeID=l.EmployeeID where o.Status=@Status ";
            using (var connecion = _context.Createconnection())
            {
                var emp = await connecion.QueryAsync<Getall>(query, new {Status});

                return emp.ToList();

            }
        }


        // Increase  the Salary 10%

        public async Task<Getall> salary()         
        {
            
                var query = @"update employeeinfo set employeesalary=(employeesalary /100) * 110";
            using (var connecion = _context.Createconnection())
            {
                var Sal = await connecion.QuerySingleOrDefaultAsync<Getall>(query);

                return Sal;

            }
        }


        // Get Particular Department Employee Details.


        public async Task<int> GETDN(string DepartmentName)
        {
            var query = "SELECT * FROM DepartmentMaster WHERE DepartmentName=@DepartmentName ";
            using (var connection = _context.Createconnection())
            {
                var id = await connection.QuerySingleOrDefaultAsync<GetID>(query, new { DepartmentName });
                return id.DepartmentID;
            }
        }


        // Above return ID will enter into the function.


        public async Task<List<Getall>> GETID(int id)
        {
            var query = "select o.EmployeeID,o.EmployeeEmailID,o.EmployeePassword,o.EmployeeDepartmentID,o.EmployeeFirstName,o.EmployeeLastName,o.EmployeeCity,o.Status,o.CreatedBY,o.CreatedDate,o.ModifiedBY,o.ModifiedDate,l.EmployeeSalary,l.EmployeeRole from Employee o left join EmployeeInfo l on o.EmployeeID=l.EmployeeID WHERE o.EmployeeDepartmentID=@id";
            using (var connection = _context.Createconnection())
            {
                var quality = await connection.QueryAsync<Getall>(query, new { id });
                return quality.ToList();
            }
        }


        // Get the InActive DepartmentID and Delete the Employee based on DepartmentID.

        public async Task<int> GETDELID(string Status)
        {
            var query = "SELECT * FROM DepartmentMaster WHERE Status=@Status ";
            using (var connection = _context.Createconnection())
            {
                var id = await connection.QuerySingleOrDefaultAsync<GetID>(query, new { Status });
                return id.DepartmentID;
            }
        }

        // Get above Return ID and Delete the Emp  on table1

        public async Task<Delete> DEL1(int id)
        {
            var query = "delete  FROM EmployeeInfo WHERE EmployeeDepartmentID=@id";
            using (var connection = _context.Createconnection())
            {
                var quality = await connection.QueryAsync<Delete>(query, new { id });
                return null;
            }
        }


        // Get above Return ID and Delete the Emp  on table2

        public async Task<Delete> DEL2(int id)
        {
            var query = "delete  FROM Employee WHERE EmployeeDepartmentID=@id";
            using (var connection = _context.Createconnection())
            {
                var quality = await connection.QueryAsync<Delete>(query, new { id });
                return null;
            }
        }


        // Insert new employee Based on store procedure.


        public async Task<int> InsertEmp(Insert prod)
        {

            using (var connection = _context.Createconnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("EmployeeEmailID", prod.EmployeeEmailID, DbType.String);
                parameters.Add("EmployeePassword", prod.EmployeePassword, DbType.String);
                parameters.Add("EmployeeFirstName", prod.EmployeeFirstName, DbType.String);
                parameters.Add("EmployeeLastName", prod.EmployeeLastName, DbType.String);
                parameters.Add("EmployeeCity", prod.EmployeeCity, DbType.String);
                parameters.Add("Status", prod.Status, DbType.String);
                parameters.Add("CreatedBY", prod.CreatedBY, DbType.Int32);
                parameters.Add("EmployeeDepartmentID", prod.EmployeeDepartmentID, DbType.Int32);

                parameters.Add("CreatedDate", prod.CreatedDate, DbType.DateTime); 
                parameters.Add("ModifiedBY", prod.ModifiedBY, DbType.Int32);
                parameters.Add("ModifiedDate", prod.ModifiedDate, DbType.DateTime);
                parameters.Add("EmployeeRole", prod.EmployeeRole, DbType.String);
                parameters.Add("EmployeeSalary", prod.EmployeeSalary, DbType.String);

                var response = await connection.ExecuteAsync(
                                        "Marlen",
                                        parameters,
                                        commandType: CommandType.StoredProcedure);
                return response;
            } 
            
        }


        // Get the IN Active EmpID  And Updated any one EmpID


        public async Task<int> GETST(string Status)
        {
            var query = "SELECT * FROM Employee WHERE Status=@Status ";
            query.FirstOrDefault();
            using (var connection = _context.Createconnection())
            {
                var  listNames= await connection.QueryAsync<GetID>(query, new { Status });
                return listNames.FirstOrDefault().EmployeeID;
            }
        }


        // Get the above ID  and update In Active to Active.

        public async Task<Getall> UpdateAct(int id)
        {
            var query = "UPDATE Employee set Status='Active' where EmployeeID=@id";
            using (var connection = _context.Createconnection())
            {
                var upt = await connection.QuerySingleOrDefaultAsync<Getall>(query, new {id});
                return upt;
            }
        }
    }
}

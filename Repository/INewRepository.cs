using System.Collections.Generic;
using System.Threading.Tasks;
using Telex.Models;

namespace Telex.Repository
{
    public interface INewRepository
    {
        public Task<Session> INS(Session ses);
        public Task<Logout> LOGOUT(Logout LOGOUTTIME);
        public Task<IEnumerable <Getall>> GETEMP(string Status);
        public Task<Getall> salary();
        public Task<int> GETDN(string DepartmentName);
        public Task<List<Getall>> GETID(int id);
        public  Task<int> GETDELID(string Status);
        public Task<Delete> DEL1(int id);
        public Task<Delete> DEL2(int id);
        public Task<int> InsertEmp(Insert prod);
        public Task<int> GETST(string Status);
        public  Task<Getall> UpdateAct(int id);



    }
}

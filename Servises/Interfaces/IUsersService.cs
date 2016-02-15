using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Domain.Entities.User;

namespace Servises.Interfaces
{
    public interface IUsersService
    {
        Task Activation(string email);
        Task UpdateUserEmail(int id, string newlogin);
        Task ActivateAccount(string newlogin);
        List<Reminding> GetRemindings(int getUserId);
        void RemindingFill(int id);
        List<FarmerUser> GetAllUsers(int getUserId);
        FarmerUser GetUsersById(int id);
        Task AddNewUsersById(int id, FormCollection collection);
    }
}

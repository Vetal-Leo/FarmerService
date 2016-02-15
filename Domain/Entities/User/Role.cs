using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Identity;

namespace Domain.Entities.User
{
    [Table("Roles")]
    public  class Role : ApplicationRole 
    {
    }
}

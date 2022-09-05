using Module_21_MVC_Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_21_MVC.Dal.Interfaces
{
    public interface IWorkerRepository:IBaseRepository<Worker>
    {
        Task<Worker> GetByName(string name);
    }
}

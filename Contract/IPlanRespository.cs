using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IPlanRespository
    {
        Task<IEnumerable<Plan>> GetAllPlanAsync();

        Task<Plan> GetPlanAsync(Guid id );

        Task CreatePlanAsync(Plan plan);

        void DeletePlan(Plan plan);

        void UpdatePlan(Plan plan);
    }
}

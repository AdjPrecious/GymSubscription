using Contract;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PlanRepository : RepositoryBase<Plan>, IPlanRespository
    {
        public PlanRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreatePlanAsync(Plan plan) => await CreateAsync(plan);
        

        public void DeletePlan(Plan plan) => Delete(plan);
       
        public async Task<IEnumerable<Plan>> GetAllPlanAsync() => await FindAll().OrderBy(p => p.DurationInDays).ToListAsync();
        

        public async Task<Plan> GetPlanAsync(Guid id) => await FindByCondition(p => p.PlanID.Equals(id)).SingleOrDefaultAsync();

        public void UpdatePlan(Plan plan) => Update(plan);

        
       
    }
}

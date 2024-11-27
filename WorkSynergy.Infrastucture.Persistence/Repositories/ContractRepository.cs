using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Domain.Models;
using WorkSynergy.Infrastucture.Persistence.Contexts;

namespace WorkSynergy.Infrastucture.Persistence.Repositories
{
    public class ContractRepository : GenericRepository<Contract>, IContractRepository
    {
        public ContractRepository(ApplicationContext context) : base(context)
        {
        }
    }
}

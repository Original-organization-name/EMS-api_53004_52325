using EMS.Data.Dictionaries;
using EMS.Shared.Repositories;
using EMS.Shared.RepositoryManagers;
using EMS.Shared.Services;

namespace EMS.Services.Dictionaries;

public class OccupationDictService : IOccupationDictService
{
    private readonly IOccupationDictRepository _repository;

    public OccupationDictService(IRepositoryManager repositoryManager) => 
        _repository = repositoryManager.OccupationDictRepository;
    
    public async Task<IReadOnlyList<OccupationCodeItem>> GetAll()
    {
        return _repository.GetAll().ToList();
    }
}
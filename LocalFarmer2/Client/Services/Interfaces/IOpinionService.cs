using LocalFarmer2.Shared.DTOs;

namespace LocalFarmer2.Client.Services
{
    public interface IOpinionService
    {
        public Task<List<Opinion>> GetAll();
        public Task<Opinion> GetOpinion(int idOpinion);
        public Task<List<Opinion>> GetOpinionFarmhousesForUser(string userName);
        public Task<int[]> GetOpinionFarmhousesForUserOnlyIds(string userName);
        public Task AddOpinion(AddOpinionDto dto);
        public Task EditOpinion(EditOpinionDto dto, int idFarmhouse);
        public Task DeleteOpinion(int idOpinion);
    }
}

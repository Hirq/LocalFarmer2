namespace LocalFarmer2.Client.Services
{
    public interface IOpinionService
    {
        public Task<List<Opinion>> GetAll();
        public Task<Opinion> GetOpinion(int idOpinion);
        public Task<List<Opinion>> GetOpinionFarmhousesForUser(string userName);
        public Task<int[]> GetOpinionFarmhousesForUserOnlyIds(string userName);
        public Task AddOpinion(AddOpinionDto dto);
        public Task EditOpinion(EditOpinionDto dto, int idOpinion);
        public Task DeleteOpinion(int idOpinion);
        public Task<List<Opinion>> AllOpinionsForFarmhouse(int idFarmhouse);
        public Task<List<Opinion>> GetRandomOpinionsForFarmhouse(int idFarmhouse, int count);
        public Task<double?> AverageForFarmhouse(int idFarmhouse);
    }
}

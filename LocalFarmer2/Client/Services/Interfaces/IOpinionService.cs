namespace LocalFarmer2.Client.Services
{
    public interface IOpinionService
    {
        public Task<List<Opinion>> GetAll();
        public Task<Opinion> GetOpinion(int idOpinion);
        public Task AddOpinion(AddOpinionDto dto, int idFarmhouse);
        public Task EditOpinion(EditOpinionDto dto, int idFarmhouse);
        public Task DeleteOpinion(int idOpinion);
    }
}

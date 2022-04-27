using Libraries;

namespace Application.Repositories
{
    public interface ISearchRespository
    {
        Task<Candidate> GetById(string id);
        Task<Candidate> GetByEmail(string email);
        Task<Candidate> GetByCpf(long cpf);
        Task<List<Candidate>> GetByName(string name);
        Task<List<Candidate>> GetAllBySkill(string skill);
        Task<List<Candidate>> GetAllByCertification(string certification);
    }
}

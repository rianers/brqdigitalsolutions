using Models;

namespace Application.Repositories
{
    public interface ISkillRespository
    {
        Task Insert(string skill, string candidateId);
        Task Delete(string id);
        Task<Skill> Update(string id, string skill);
        Task<List<Skill>> GetAllById(string id);
    }
}

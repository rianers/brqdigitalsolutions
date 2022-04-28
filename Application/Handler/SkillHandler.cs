using Application.Repositories;
using Models;

namespace Application.Handler
{
    public class SkillHandler
    {
        private readonly ISkillRespository _skillRespository;
        public SkillHandler(ISkillRespository skillRespository)
        {
            _skillRespository = skillRespository;
        }
        public async Task Insert(string skill, string candidateId)
        {
            await _skillRespository.Insert(skill, candidateId);
        }

        public async Task Delete(string id)
        {
            await _skillRespository.Delete(id);
        }

        public async Task Update(string id, string skill)
        {
            await _skillRespository.Update(id, skill);
        }

        public async Task<List<Skill>> GetAll(string id)
        {
            return await _skillRespository.GetAllById(id);
        }
    }
}

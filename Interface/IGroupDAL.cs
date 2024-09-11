using ShearwellExercise.Models;

namespace ShearwellExercise.Interface
{
    public interface IGroupDAL
    {
        Task<List<Group>> GetAll();
        Task<Group?> Get(Guid id);
        Task<bool> CreateGroups();
    }
}

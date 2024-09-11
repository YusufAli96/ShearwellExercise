using ShearwellExercise.Models;

namespace ShearwellExercise.Interface
{
    public interface IAnimalDAL
    {
        Task<Guid> Create(Animal animal);
    }
}

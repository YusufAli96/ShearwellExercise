using ShearwellExercise.Models;

namespace ShearwellExercise.Interface
{
    public interface IDatabaseDAL
    {
        List<Group> GetGroups();
        Group? GetGroup(Guid id);
        void RemoveLink(AnimalForGroup animalForGroup);
        bool CreateGroups();
        bool CreateAnimals();


    }
}

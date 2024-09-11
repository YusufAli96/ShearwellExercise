using ShearwellExercise.Data;
using ShearwellExercise.Interface;
using ShearwellExercise.Models;

namespace ShearwellExercise.DAL
{
    public class AnimalForGroupDAL : IAnimalForGroupDAL
    {
        private readonly ApplicationDbContext _context;

        public AnimalForGroupDAL(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(List<AnimalForGroup> animalForGroups)
        {
            bool success = false;

            try
            {
                await _context.AnimalForGroups.AddRangeAsync(animalForGroups);
                await _context.SaveChangesAsync();

                success = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return success;
        }

        public async Task<bool> Delete(AnimalForGroup animalForGroup)
        {
            bool success = false;

            try
            {
                _context.Remove(animalForGroup);
                await _context.SaveChangesAsync();

                success = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return success;
        }
    }
}

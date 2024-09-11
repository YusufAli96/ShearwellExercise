using Microsoft.EntityFrameworkCore;
using ShearwellExercise.Data;
using ShearwellExercise.Interface;
using ShearwellExercise.Models;

namespace ShearwellExercise.DAL
{
    public class AnimalDAL : IAnimalDAL
    {
        private readonly ApplicationDbContext _context;

        public AnimalDAL(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(Animal animal)
        {
            try
            {
                await _context.Animals.AddAsync(animal);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }


            return animal.Id;
        }
    }
}

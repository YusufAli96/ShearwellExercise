using Microsoft.EntityFrameworkCore;
using ShearwellExercise.Data;
using ShearwellExercise.Interface;
using ShearwellExercise.Models;

namespace ShearwellExercise.DAL
{
    public class GroupDAL : IGroupDAL
    {
        private readonly ApplicationDbContext _context;

        public GroupDAL(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Group>> GetAll() { 
        
            List<Group> groups = new();

            try
            {
                groups = await _context.Groups.Include(g => g.AnimalForGroups).ToListAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return groups;
        }

        public async Task<Group?> Get(Guid id)
        {
            Group? group = new();

            try
            {
                group = await _context.Groups.Include(g => g.AnimalForGroups).ThenInclude(a => a.Animal).FirstOrDefaultAsync(g => g.Id == id);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return group;
        }

        public async Task<bool> CreateGroups()
        {
            bool success = false;

            try
            {
                if (_context.Groups.Count() == 0)
                {
                    DateTime now = DateTime.Now;    
                    List<Group> groups = new() { 
                        new() { Id = Guid.Parse("06706731-8328-4928-8068-08DCCFFF10C1"), Name = "House", DateTimeCreated = now },
                        new() { Id = Guid.Parse("EB4F34D2-3201-44B1-8069-08DCCFFF10C1"), Name = "Garden", DateTimeCreated = now },
                        new() { Id = Guid.Parse("4F1F2BAA-A0D6-4AFF-806A-08DCCFFF10C1"), Name = "Shelter", DateTimeCreated = now },
                    };

                    await _context.Groups.AddRangeAsync(groups);
                    await _context.SaveChangesAsync();
                    success = true;
                }

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

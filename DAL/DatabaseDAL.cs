using Microsoft.EntityFrameworkCore;
using ShearwellExercise.Data;
using ShearwellExercise.Interface;
using ShearwellExercise.Models;

namespace ShearwellExercise.DAL
{
    public class DatabaseDAL : IDatabaseDAL
    {
        static ApplicationDbContext _context;

        public DatabaseDAL(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Group> GetGroups() { 
        
            List<Group> groups = new();

            groups = _context.Groups.ToList();

            return groups;
        }

        public Group? GetGroup(Guid id)
        {
            Group? group = new();

            group = _context.Groups.Include(g => g.AnimalForGroups).ThenInclude(a => a.Animal).FirstOrDefault(g => g.Id == id);

            return group;
        }

        public void RemoveLink(AnimalForGroup animalForGroup)
        {
            _context.Remove(animalForGroup);
            _context.SaveChanges();
        }

        public bool CreateGroups()
        {
            if (_context.Groups.Count() == 0)
            {
                DateTime now = DateTime.Now;    
                List<Group> groups = new() { 
                    new() { Id = Guid.Parse("06706731-8328-4928-8068-08DCCFFF10C1"), Name = "House", DateTimeCreated = now },
                    new() { Id = Guid.Parse("EB4F34D2-3201-44B1-8069-08DCCFFF10C1"), Name = "Garden", DateTimeCreated = now },
                    new() { Id = Guid.Parse("4F1F2BAA-A0D6-4AFF-806A-08DCCFFF10C1"), Name = "Shelter", DateTimeCreated = now },
                };

                _context.Groups.AddRange(groups);
                _context.SaveChanges();
            }

            return true;
        }
        public bool CreateAnimals()
        {
                DateTime now = DateTime.Now;    
            if (_context.Animals.Count() == 0)
            {
                List<Animal> groups = new() { 
                    new() { Id = Guid.Parse("2d21aaf9-30cc-4607-90c3-4a180831070a"), Tag = "1", DateOfBirth = now },
                    new() { Id = Guid.Parse("5d59f5c1-9539-4479-8bf4-f491d784d29b"), Tag = "2", DateOfBirth = now },
                    new() { Id = Guid.Parse("e1791645-a8ef-42f3-ba69-d9bc0f29b0f9"), Tag = "3", DateOfBirth = now },
                };

                _context.Animals.AddRange(groups);
                _context.SaveChanges();

            }

            _context.RemoveRange(_context.AnimalForGroups.ToList());
            _context.SaveChanges();

                List<AnimalForGroup> animalForGroups = new() {
                    new() { AnimalId = Guid.Parse("2d21aaf9-30cc-4607-90c3-4a180831070a"), GroupId = Guid.Parse("06706731-8328-4928-8068-08DCCFFF10C1"), CreatedDateTime = now },
                    new() { AnimalId = Guid.Parse("5d59f5c1-9539-4479-8bf4-f491d784d29b"), GroupId = Guid.Parse("06706731-8328-4928-8068-08DCCFFF10C1"), CreatedDateTime = now },
                    new() { AnimalId = Guid.Parse("e1791645-a8ef-42f3-ba69-d9bc0f29b0f9"), GroupId = Guid.Parse("06706731-8328-4928-8068-08DCCFFF10C1"), CreatedDateTime = now },
                };

                _context.AnimalForGroups.AddRange(animalForGroups);
                _context.SaveChanges();

            return true;
        }
    }
}

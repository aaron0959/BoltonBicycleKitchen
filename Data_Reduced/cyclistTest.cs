using BBK_A2_SWE5201_2201525.Data.BBKDB;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;

namespace BBK_A2_SWE5201_2201525.Data

{

    public class cyclistTest

    {

        private readonly BBKDBContext _context;

        public cyclistTest(BBKDBContext context)

        {

            _context = context;

        }

        public async Task<List<Cyclist>>

            GetCyclistAsync(string strCurrentUser)

        {

            // Get Cyclists  

            return await _context.Cyclist
                .Include(c => c.Course)
               

                 // Only get entries for the current logged in user

                 

                 // Use AsNoTracking to disable EF change tracking

                 // Use ToListAsync to avoid blocking a thread

                 .AsNoTracking().ToListAsync();

        }

        public Task<Cyclist>

            CreateCyclistAsync(Cyclist objCyclist)

        {

            _context.Cyclist.Add(objCyclist);

            _context.SaveChanges();

            return Task.FromResult(objCyclist);

        }

        public Task<bool>

    UpdateCyclistAsync(Cyclist objCyclist)

        {

            var ExistingCyclist =

                _context.Cyclist

                .Where(x => x.CyclistId == objCyclist.CyclistId)

                .FirstOrDefault();

            if (ExistingCyclist != null)

            {

                ExistingCyclist.FirstName =

                    objCyclist.FirstName;

                ExistingCyclist.LastName =

                    objCyclist.LastName;

                ExistingCyclist.PhoneNumber =

                    objCyclist.PhoneNumber;

                ExistingCyclist.Email =

                    objCyclist.Email;
                
                ExistingCyclist.Address =

                    objCyclist.Address;
                
                ExistingCyclist.CourseId =
                    objCyclist.CourseId;

                _context.SaveChanges();

            }

            else

            {

                return Task.FromResult(false);

            }

            return Task.FromResult(true);

        }
        public Task<bool>

    DeleteCyclistAsync(Cyclist objCyclist)

        {

            var ExistingCyclist =

                _context.Cyclist

                .Where(x => x.CyclistId == objCyclist.CyclistId)

                .FirstOrDefault();

            if (ExistingCyclist != null)

            {

                _context.Cyclist.Remove(ExistingCyclist);

                _context.SaveChanges();

            }

            else

            {

                return Task.FromResult(false);

            }

            return Task.FromResult(true);


        }

    }

}










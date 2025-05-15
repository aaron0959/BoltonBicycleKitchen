using BBK_A2_SWE5201_2201525.Data.BBKDB;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;

namespace BBK_A2_SWE5201_2201525.Data

{

    public class partTest

    {

        private readonly BBKDBContext _context;

        public partTest(BBKDBContext context)

        {

            _context = context;

        }

        public async Task<List<Part>>

            GetPartAsync(string strCurrentUser)

        {

            // Get parts 

            return await _context.Part

                 // Only get entries for the current logged in user



                 // Use AsNoTracking to disable EF change tracking

                 // Use ToListAsync to avoid blocking a thread

                 .AsNoTracking().ToListAsync();

        }

        public Task<Part>

            CreatePartAsync(Part objPart)

        {

            _context.Part.Add(objPart);

            _context.SaveChanges();

            return Task.FromResult(objPart);

        }

        public Task<bool>

    UpdatePartAsync(Part objPart)

        {

            var ExistingPart =

                _context.Part

                .Where(x => x.PartId == objPart.PartId)

                .FirstOrDefault();

            if (ExistingPart != null)

            {

                ExistingPart.PartName =

                    objPart.PartName;

                ExistingPart.PartCost =

                    objPart.PartCost;

                _context.SaveChanges();

            }

            else

            {

                return Task.FromResult(false);

            }

            return Task.FromResult(true);

        }
        public Task<bool>

    DeletePartAsync(Part objPart)

        {

            var ExistingPart =

                _context.Part

                .Where(x => x.PartId == objPart.PartId)

                .FirstOrDefault();

            if (ExistingPart != null)

            {

                _context.Part.Remove(ExistingPart);

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

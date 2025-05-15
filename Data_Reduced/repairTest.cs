using BBK_A2_SWE5201_2201525.Data.BBKDB;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;

namespace BBK_A2_SWE5201_2201525.Data

{

    public class repairTest

    {

        private readonly BBKDBContext _context;

        public repairTest(BBKDBContext context)

        {

            _context = context;

        }

        public async Task<List<Repair>>

            GetRepairAsync(string strCurrentUser)

        {

            // Get repairs

            return await _context.Repair
                .Include(v => v.Volunteer)
                .Include(b => b.Bike)
                .ThenInclude(c => c.Cyclist)
                .Include(p => p.Part)

                 // Only get entries for the current logged in user



                 // Use AsNoTracking to disable EF change tracking

                 // Use ToListAsync to avoid blocking a thread

                 .AsNoTracking().ToListAsync();

        }

        public Task<Repair>

            CreateRepairAsync(Repair objRepair)

        {

            _context.Repair.Add(objRepair);

            _context.SaveChanges();

            return Task.FromResult(objRepair);

        }

        public Task<bool>

    UpdateRepairAsync(Repair objRepair)

        {

            var ExistingRepair =

                _context.Repair

                .Where(x => x.RepairId == objRepair.RepairId)

                .FirstOrDefault();

            if (ExistingRepair != null)

            {

                ExistingRepair.RepairType =

                    objRepair.RepairType;
                ExistingRepair.VolunteerId =
                    objRepair.VolunteerId;
                ExistingRepair.BikeId = objRepair.BikeId;
                ExistingRepair.PartId = objRepair.PartId;

                _context.SaveChanges();

            }

            else

            {

                return Task.FromResult(false);

            }

            return Task.FromResult(true);

        }
        public Task<bool>

    DeleteRepairAsync(Repair objRepair)

        {

            var ExistingRepair =

                _context.Repair

                .Where(x => x.RepairId == objRepair.RepairId)

                .FirstOrDefault();

            if (ExistingRepair != null)

            {

                _context.Repair.Remove(ExistingRepair);

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

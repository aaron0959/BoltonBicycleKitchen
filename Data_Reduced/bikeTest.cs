using BBK_A2_SWE5201_2201525.Data.BBKDB;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;

namespace BBK_A2_SWE5201_2201525.Data

{

    public class bikeTest

    {

        private readonly BBKDBContext _context;

        public bikeTest(BBKDBContext context)

        {

            _context = context;

        }

        public async Task<List<Bike>>

            GetBikeAsync(string strCurrentUser)

        {

            // Get bikes  

            return await _context.Bike
                .Include(b => b.Cyclist)

                 // Only get entries for the current logged in user



                 // Use AsNoTracking to disable EF change tracking

                 // Use ToListAsync to avoid blocking a thread

                 .AsNoTracking().ToListAsync();

        }

        public Task<Bike>

            CreateBikeAsync(Bike objBike)

        {

            _context.Bike.Add(objBike);

            _context.SaveChanges();

            return Task.FromResult(objBike);

        }

        public Task<bool>

    UpdateBikeAsync(Bike objBike)

        {

            var ExistingBike =

                _context.Bike

                .Where(x => x.BikeId == objBike.BikeId)

                .FirstOrDefault();

            if (ExistingBike != null)

            {

                ExistingBike.BikeModel =

                    objBike.BikeModel;
                ExistingBike.CyclistId =
                    objBike.CyclistId;

                _context.SaveChanges();

            }

            else

            {

                return Task.FromResult(false);

            }

            return Task.FromResult(true);

        }
        public Task<bool>

    DeleteBikeAsync(Bike objBike)

        {

            var ExistingBike =

                _context.Bike

                .Where(x => x.BikeId == objBike.BikeId)

                .FirstOrDefault();

            if (ExistingBike != null)

            {

                _context.Bike.Remove(ExistingBike);

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

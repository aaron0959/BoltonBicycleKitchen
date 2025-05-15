using BBK_A2_SWE5201_2201525.Data.BBKDB;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;

namespace BBK_A2_SWE5201_2201525.Data

{

    public class volunteerTest

    {

        private readonly BBKDBContext _context;

        public volunteerTest(BBKDBContext context)

        {

            _context = context;

        }

        public async Task<List<Volunteer>>

            GetVolunteerAsync(string strCurrentUser)

        {

            // Get volunteers

            return await _context.Volunteer

                 // Only get entries for the current logged in user



                 // Use AsNoTracking to disable EF change tracking

                 // Use ToListAsync to avoid blocking a thread

                 .AsNoTracking().ToListAsync();

        }

        public Task<Volunteer>

            CreateVolunteerAsync(Volunteer objVolunteer)

        {

            _context.Volunteer.Add(objVolunteer);

            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return Task.FromResult(objVolunteer);

        }

        public Task<bool>

    UpdateVolunteerAsync(Volunteer objVolunteer)

        {

            var ExistingVolunteer =

                _context.Volunteer

                .Where(x => x.VolunteerId == objVolunteer.VolunteerId)

                .FirstOrDefault();

            if (ExistingVolunteer != null)

            {

                ExistingVolunteer.VolunteerForename =

                    objVolunteer.VolunteerForename;

                ExistingVolunteer.VolunteerSurname =

                    objVolunteer.VolunteerSurname;

                ExistingVolunteer.VolunteerPhoneNumber =

                    objVolunteer.VolunteerPhoneNumber;

                ExistingVolunteer.VolunteerEmail =

                    objVolunteer.VolunteerEmail;

                ExistingVolunteer.VolunteerAddress =

                    objVolunteer.VolunteerAddress;

                _context.SaveChanges();
                _context.ChangeTracker.Clear();

            }

            else

            {

                return Task.FromResult(false);

            }

            return Task.FromResult(true);

        }
        public Task<bool>

    DeleteVolunteerAsync(Volunteer objVolunteer)

        {

            var ExistingVolunteer =

                _context.Volunteer

                .Where(x => x.VolunteerId == objVolunteer.VolunteerId)

                .FirstOrDefault();

            if (ExistingVolunteer != null)

            {

                _context.Volunteer.Remove(ExistingVolunteer);

                _context.SaveChanges();
                _context.ChangeTracker.Clear();

            }

            else

            {

                return Task.FromResult(false);

            }

            return Task.FromResult(true);


        }

    }

}

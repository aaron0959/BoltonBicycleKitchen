using BBK_A2_SWE5201_2201525.Data.BBKDB;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;

namespace BBK_A2_SWE5201_2201525.Data

{

    public class courseTest

    {

        private readonly BBKDBContext _context;

        public courseTest(BBKDBContext context)

        {

            _context = context;

        }

        public async Task<List<Course>>

            GetCourseAsync(string strCurrentUser)

        {

            // Get courses  

            return await _context.Course
                .Include(v => v.Volunteer)

                 // Only get entries for the current logged in user



                 // Use AsNoTracking to disable EF change tracking

                 // Use ToListAsync to avoid blocking a thread

                 .AsNoTracking().ToListAsync();

        }

        public Task<Course>

            CreateCourseAsync(Course objCourse
            )

        {

            _context.Course.Add(objCourse);

            _context.SaveChanges();

            return Task.FromResult(objCourse);

        }

        public Task<bool>

    UpdateCourseAsync(Course objCourse)

        {

            var ExistingCourse =

                _context.Course

                .Where(x => x.CourseId == objCourse.CourseId)

                .FirstOrDefault();

            if (ExistingCourse != null)

            {

                ExistingCourse.CourseName =

                    objCourse.CourseName;
                ExistingCourse.VolunteerId =
                    objCourse.VolunteerId;


                _context.SaveChanges();

            }

            else

            {

                return Task.FromResult(false);

            }

            return Task.FromResult(true);

        }
        public Task<bool>

    DeleteCourseAsync(Course objCourse)

        {

            var ExistingCourse =

                _context.Course

                .Where(x => x.CourseId == objCourse.CourseId)

                .FirstOrDefault();

            if (ExistingCourse != null)

            {

                _context.Course.Remove(ExistingCourse);

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


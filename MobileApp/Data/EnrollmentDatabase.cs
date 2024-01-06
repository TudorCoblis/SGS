using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MobileApp.Models;

namespace MobileApp.Data
{
    public class EnrollmentDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public EnrollmentDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Enrollment>().Wait();
            _database.CreateTableAsync<Student>().Wait();
            _database.CreateTableAsync<Course>().Wait();
            _database.CreateTableAsync<CourseEnrollment>().Wait();
        }
        public Task<List<Enrollment>> GetEnrollmentAsync()
        {
            return _database.Table<Enrollment>().ToListAsync();
        }
        public Task<Enrollment> GetEnrollmentAsync(int id)
        {
            return _database.Table<Enrollment>()
            .Where(i => i.EnrollmentID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveEnrollmentAsync(Enrollment slist)
        {
            if (slist.EnrollmentID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteEnrollmentAsync(Enrollment slist)
        {
            return _database.DeleteAsync(slist);
        }
        public Task<int> SaveCourseAsync(Course course)
        {
            if (course.CourseID != 0)
            {
                return _database.UpdateAsync(course);
            }
            else
            {
                return _database.InsertAsync(course);
            }
        }
        public Task<int> DeleteCourseAsync(Course course)
        {
            return _database.DeleteAsync(course);
        }
        public Task<List<Course>> GetCoursesAsync()
        {
            return _database.Table<Course>().ToListAsync();
        }
        public Task<int> SaveCourseEnrollmentAsync(CourseEnrollment listc)
        {
            if (listc.CourseID != 0)
            {
                return _database.UpdateAsync(listc);
            }
            else
            {
                return _database.InsertAsync(listc);
            }
        }
        public Task<List<Course>> GetCourseEnrollmentsAsync(int enrollmentid)
        {
            return _database.QueryAsync<Course>(
            "select C.CourseID, C.Description from Course C"
            + " inner join CourseEnrollment CE"
            + " on C.CourseID = CE.CourseID where CE.EnrollmentID = ?",
            enrollmentid);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MobileApp.Models;

namespace MobileApp.Data
{
    public class StudentDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public StudentDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Student>().Wait();
        }
        public Task<List<Student>> GetStudentAsync()
        {
            return _database.Table<Student>().ToListAsync();
        }
        public Task<Student> GetStudentAsync(int id)
        {
            return _database.Table<Student>()
            .Where(i => i.StudentID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveStudentAsync(Student slist)
        {
            if (slist.StudentID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteStudentAsync(Student slist)
        {
            return _database.DeleteAsync(slist);
        }
    }
}

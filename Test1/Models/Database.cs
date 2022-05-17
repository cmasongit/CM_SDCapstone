using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Models
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Term>().Wait();
            _database.CreateTableAsync<Courses>().Wait();
            _database.CreateTableAsync<Assessment>().Wait();
          
        }

        public Task<List<Term>> GetTermAsync()
        {
            return _database.Table<Term>().ToListAsync();
        }

       





        public Task<List<Courses>> GetTermcoursesAsync(string name)
        {
            return _database.Table<Courses>().Where(i => i.termname == name).ToListAsync();
        }



        public Task<List<Courses>> GetcoursesgroupAsync(string name)
        {
            return _database.Table<Courses>().Where(i => i.coursetitle1 == name).ToListAsync();
        }





        public Task<List<Assessment>> GetAssessmentgroupAsync(string name)
        {
            return _database.Table<Assessment>().Where(i => i.coursename == name).ToListAsync();
        }

        public Task<int> GetAssessmentCountAsync(string name)
        {
           return _database.Table<Assessment>().Where(i => i.coursename == name).CountAsync();
        }

        public Task<int> GetAssessmenttypeAsync(string name)
        {
            return _database.Table<Assessment>().Where(i => i.ttype == name).CountAsync();
        }

        public Task<List<Assessment>> GetAssessmenttype2Async(string name)
        {
            return _database.Table<Assessment>().Where(i => i.ttype == name).ToListAsync();
        }


        public Task<List<Assessment>> GetAssessmentsNotDoneAsync(string name)
        {
            
            return _database.QueryAsync<Assessment>("SELECT * FROM [Assessment] WHERE [coursename] = [name]");
        }


        

        public Task<int> SaveTermAsync(Term Term)
        {
            return _database.InsertAsync(Term);
        }

        public Task<int> RemoveTermAsync(Term Term)
        {
            return _database.DeleteAsync(Term);
        }

        public Task<int> UpdateCourseAsync(Courses Term)
        {
            return _database.UpdateAsync(Term);
        }

        public Task<int> UpdateAssessmentAsync(Assessment Term)
        {
           return _database.UpdateAsync(Term);
    
        }

        public Task<int> UpdateTermAsync(Term Term)
        {
            return _database.UpdateAsync(Term);

        }

        public Task<List<Courses>> GetCourseAsync()
        {
            return _database.Table<Courses>().ToListAsync();
        }

        public Task<int> SaveCourseAsync(Courses Term)
        {
            return _database.InsertAsync(Term);
        }

        public Task<int> RemoveCourseAsync(Courses Term)
        {
           
            return _database.DeleteAsync(Term);
        }

        public Task<List<Assessment>> GetAssessmentAsync()
        {
            return _database.Table<Assessment>().ToListAsync();
        }

        public Task<int> SaveAssessmentAsync(Assessment Term)
        {
            return _database.InsertAsync(Term);
        }

        public Task<int> RemoveAssessmentAsync(Assessment Term)
        {
            return _database.DeleteAsync(Term);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorWithMongo.Shared.Models;
using MongoDB.Driver;

namespace BlazorWithMongo.Server.DataAccess
{
    public class EmployeeDataAccessLayer
    {
        EmployeeDbContext db = new EmployeeDbContext();


        /// <summary>
        /// GetAll Employee Details
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAllEmployees()
        {
            try
            {
                var cursorTask = db.Employees.FindAsync(_ => true);

                cursorTask.Wait();

                var listTask = cursorTask.Result.ToListAsync();

                listTask.Wait();

                return listTask.Result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Add new employee
        /// </summary>
        /// <param name="employee"></param>
        public void AddEmployee(Employee employee)
        {
            try
            {
                db.Employees.InsertOne(employee);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get a particular employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee GetEmployeeData(string id)
        {
            try
            {
                var cursorTask = db.Employees.FindAsync(x => x.Id == id);
                cursorTask.Wait();

                return  cursorTask.Result.FirstOrDefault();

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Update particular employee
        /// </summary>
        /// <param name="employee"></param>
        public void updateEmployee(Employee emp)
        {
            try
            {
                db.Employees.ReplaceOne(x => x.Id == emp.Id, emp);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Delete aicular employee
        /// </summary>
        /// <param name="id"></param>
        public void DeleteEmployee(string id)
        {
            try
            {
                db.Employees.DeleteOne(e => e.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get all Cities
        /// </summary>
        /// <returns></returns>
        public List<City> GetAllCities()
        {
            try
            {
                var cursorTask = db.Cities.FindAsync(_ => true);
                cursorTask.Wait();

                var listTask = cursorTask.Result.ToListAsync();
                listTask.Wait();

                return listTask.Result;

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

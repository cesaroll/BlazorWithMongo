using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace BlazorWithMongo.Shared.Models
{
    public class EmployeeDbContext
    {
        private readonly IMongoDatabase _mongoDatabase;

        public EmployeeDbContext()
        {
            string connString = "mongodb://cesarl:STart123@clusterces-s5jn4.mongodb.net"; //Should be injected instead
            var client = new MongoClient(connString);
            _mongoDatabase = client.GetDatabase("EmployeeDB");
        }


        /// <summary>
        /// Retrieves EMployee Record Collecion
        /// </summary>
        public IMongoCollection<Employee> Employees
        {
            get
            {
                return _mongoDatabase.GetCollection<Employee>("Employees");
            }
        }

        /// <summary>
        /// Retrieves Cities record collections
        /// </summary>
        public IMongoCollection<City> Cities
        {
            get
            {
                return _mongoDatabase.GetCollection<City>("Cities");
            }
        }
    }


    
}

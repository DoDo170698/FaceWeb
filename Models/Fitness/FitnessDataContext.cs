using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo1.Models.Fitness
{
    public class FitnessDataContext<T> : DatabaseContext<T> where T : class, new()
    {
        public FitnessDataContext(string connectString = "FitnessConnectionString") : base(connectString)
        {
        }
    }
}
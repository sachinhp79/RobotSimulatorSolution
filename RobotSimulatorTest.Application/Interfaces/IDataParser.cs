using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulatorTest.Application.Interfaces
{
    public interface IDataParser<T> where T : class
    {
        Task<T[]> ParseDataAsync(string data);
    }
}
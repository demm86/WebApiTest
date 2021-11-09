using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IFileServices
    {
        string ReadFile(string url, string fileName);

        bool WriteFile(string url, string fileName, string content);
    }
}

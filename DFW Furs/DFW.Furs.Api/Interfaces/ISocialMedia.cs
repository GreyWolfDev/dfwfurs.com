using DFW.Furs.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DFW.Furs.Api.Interfaces
{
    public interface ISocialMedia<T> where T : IPost
    {
        Task<IEnumerable<T>> GetItems(string identifier, int count);
    }
}

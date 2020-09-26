using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services
{
    public interface ITripService
    {
        void Create(string name, string cover);

        IEnumerable<object> GetAll();

        object GetDetails(string id);
    }
}

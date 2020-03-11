using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteSquadra.Models;

namespace TesteSquadra.Services
{
    public interface ISistemaService
    {
        IEnumerable<Sistemas> GetAllItems();
        Sistemas Add(Sistemas novoItem);
        Sistemas Edit(Sistemas sistema);
        Sistemas GetById(int id);
        void Remove(int id);
    }
}

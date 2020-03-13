using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteSquadra.Models;

namespace TesteSquadra.Services
{
    public class SistemaService : ISistemaService
    {
        private readonly TesteSquadraContext _context;


        public SistemaService(TesteSquadraContext context)
        {
            _context = context;

        }
        public Sistemas Add(Sistemas sistema)
        {

            _context.Sistemas.Add(sistema);
            _context.SaveChanges();

            return sistema;
        }
        public Sistemas Edit(Sistemas sistema)
        {
            _context.Entry(sistema).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return sistema;
        }
        public IEnumerable<Sistemas> GetAllItems(CriterioDeBusca criterioDeBusca)
        {

            return _context.Sistemas.Where(a => a.Sigla.Contains(criterioDeBusca.Sigla) || a.Descricao.Contains(criterioDeBusca.Descricao) || a.Email.Contains(criterioDeBusca.Email));
        }
        public Sistemas GetById(int id)
        {

            var sistemas = _context.Sistemas.Find(id);

            if (sistemas == null)
            {
                //return NotFound();
            }

            return sistemas;
        }
        public void Remove(int id)
        {
            var sistemas = _context.Sistemas.Find(id);

            _context.Sistemas.Remove(sistemas);
            _context.SaveChanges();


        }


    }
}

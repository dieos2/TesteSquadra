using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteSquadra.Models;
using TesteSquadra.Services;

namespace TesteSquadraTest
{
    class SistemaServiceFake : ISistemaService 
    {
        private readonly List<Sistemas> _sistema;
        public SistemaServiceFake()
        {
            _sistema = new List<Sistemas>()
            {
                new Sistemas() { Id = 1, Descricao = "Sistema de gerenciamento de noticias",
                                   Sigla ="SGN", Email = "contato@sgn.net.br", URL = "https://sgn.net.br" },
                //new Sistemas() { Id = 2, Nome = "IPad 7",
                //                   Fabricante ="Apple", Preco = 644.00M },
                //new Sistemas() { Id = 3, Nome = "Notebook Lenovo 13",
                //                   Fabricante ="Lenovo", Preco = 987.00M },
                //new Sistemas() { Id = 4, Nome = "Monitor LG 23",
                //                   Fabricante ="LG", Preco = 879.00M },
                //new Sistemas() { Id = 5, Nome = "HD SSD Asus 1T",
                //                   Fabricante ="Assus", Preco = 612.00M }
            };
        }
        public IEnumerable<Sistemas> GetAllItems()
        {
            return _sistema;
        }
        public Sistemas Add(Sistemas sistema)
        {
            sistema.Id = GeraId();
            _sistema.Add(sistema);
            return sistema;
        }
        public Sistemas Edit(Sistemas sistema)
        {
            sistema.Id = GeraId();
            _sistema.Add(sistema);
            return sistema;
        }
        public Sistemas GetById(int id)
        {
            return _sistema.Where(a => a.Id == id)
                .FirstOrDefault();
        }
        public void Remove(int id)
        {
            var item = _sistema.First(a => a.Id == id);
            _sistema.Remove(item);
        }
        static int GeraId()
        {
            Random random = new Random();
            return random.Next(1, 100);
        }
    }
}


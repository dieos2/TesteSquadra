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
                new Sistemas() {
                    Id = 1,
                    Descricao = "Sistema de gerenciamento de noticias",
                    Sigla ="SGN",
                    Email = "contato@sgn.net.br",
                    URL = "https://sgn.net.br",
                    DataEdicao = DateTime.Now,
                    Justificativa = "Edição", Status = "Ativo",
                    UsuarioResponsavel = "Diego Serra" },
                new Sistemas()
            {
                Id = 2,
                Descricao = "Sistema de gerenciamento de noticias",
                Sigla = "SGN",
                Email = "contato@sgn.net.br",
                URL = "https://sgn.net.br",
                DataEdicao = DateTime.Now,
                Justificativa = "Edição",
                Status = "Ativo",
                UsuarioResponsavel = "Diego Serra"
            },
                new Sistemas()
                {
                    Id = 3,
                    Descricao = "Gerenciamento de Noticias",
                    Sigla = "SGN2",
                    Email = "",
                    URL = null,
                    Status = "Ativo",
                    UsuarioResponsavel = "Diego Serra",
                    DataEdicao = DateTime.Now,
                    Justificativa = "Inclusão"
                },
                new Sistemas()
                {
                    Id = 4,
                    Descricao = "Segue ios",
                    Sigla = "IOS",
                    Email = "",
                    URL = "",
                    Status = "Cancelado",
                    UsuarioResponsavel = "Diego Serra",
                    DataEdicao = DateTime.Now,
                    Justificativa = "cancelar"
                },
                new Sistemas()
                {
                    Id = 5,
                    Descricao = "sistema da google",
                    Sigla = "Android",
                    Email = "",
                    URL = "https=//google.com",
                    Status = "Ativo",
                    UsuarioResponsavel = "Diego Serra",
                    DataEdicao = DateTime.Now,
                    Justificativa = "Inclusão"
                },
                new Sistemas()
                {
                    Id = 6,
                    Descricao = "sistema Operacional",
                    Sigla = "SOP",
                    Email = "",
                    URL = "",
                    Status = "Ativo",
                    UsuarioResponsavel = "Diego Serra",
                    DataEdicao = DateTime.Now,
                    Justificativa = "Inclusão"
                },
                new Sistemas()
                {
                    Id = 7,
                    Descricao = "Sistema com Email",
                    Sigla = "SCE",
                    Email = "",
                    URL = null,
                    Status = "Ativo",
                    UsuarioResponsavel = "Diego Serra",
                    DataEdicao = DateTime.Now,
                    Justificativa = "Inclusão"
                },
                new Sistemas()
                {
                    Id = 8,
                    Descricao = "ultimo da noite",
                    Sigla = "UDN",
                    Email = "ult@noite.vom",
                    URL = "",
                    Status = "Ativo",
                    UsuarioResponsavel = "Diego Serra",
                    DataEdicao = DateTime.Now,
                    Justificativa = "Inclusão"
                },
                new Sistemas()
                {
                    Id = 9,
                    Descricao = "Administrativo do web service",
                    Sigla = "WSADMIN",
                    Email = "dieos@gmail.com",
                    URL = "https=//google.com",
                    Status = "Ativo",
                    UsuarioResponsavel = "Diego Serra",
                    DataEdicao = DateTime.Now,
                    Justificativa = "email errado"
                },
                new Sistemas()
                {
                    Id = 10,
                    Descricao = "Ultimo mesmo",
                    Sigla = "UMM",
                    Email = "ultimoo@gmail.com",
                    URL = "",
                    Status = "Ativo",
                    UsuarioResponsavel = "Diego Serra",
                    DataEdicao = DateTime.Now,
                    Justificativa = "Inclusão"
                }
        };

        }
        public IEnumerable<Sistemas> GetAllItems(CriterioDeBusca criterioDeBusca)
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


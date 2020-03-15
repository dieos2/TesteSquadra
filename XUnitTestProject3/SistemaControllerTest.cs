

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteSquadra.Controllers;
using TesteSquadra.Models;
using TesteSquadra.Services;
using Xunit;

namespace TesteSquadraTest
{
    public class SistemaControllerTest
    {
        SistemasController _controller;
        ISistemaService _service;
        public SistemaControllerTest()
        {
            _service = new SistemaServiceFake();
            _controller = new SistemasController(_service);
        }
        //get objetos e espera okResult
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            string sigla = "";
            string descricao = "";
            string email = "";
            // Act
            var okResult = _controller.GetSistemas(sigla, descricao, email);
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        //get todos os itens e compara o total de itens
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            string sigla = "";
            string descricao = "";
            string email = "";
            // Act
            var okResult = _controller.GetSistemas(sigla, descricao, email).Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<Sistemas>>(okResult.Value);
            Assert.Equal(10, items.Count);
        }
        //teste para o metodo get
        //get um objeto por um id inexistente  e espera NotFound
        [Fact]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetSistemas(99);
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }
        //get objeto com o id existente
        [Fact]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            var testeId = 1;
            // Act
            var okResult = _controller.GetSistemas(testeId);
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }
        //pega um objeto com id existente e compara se o id é igual ao que foi solicitado
        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            var testeId = 1;
            // Act
            var okResult = _controller.GetSistemas(testeId) as OkObjectResult;
            // Assert
            Assert.IsType<Sistemas>(okResult.Value);
            Assert.Equal(testeId, (okResult.Value as Sistemas).Id);
        }
        //teste para os metodo Add
        //Adicona um objeto invalido e espera um badrequest
        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var nameMissingItem = new Sistemas()
            {   
                Sigla = "SGN",
                Email = "contato@sgn.net.br",
                URL = "https://sgn.net.br",
                DataEdicao = DateTime.Now,
                Justificativa = "Edição",
                Status = "Ativo",
                UsuarioResponsavel = "Diego Serra"
            };
            _controller.ModelState.AddModelError("Descricao", "Required");
            // Act
            var badResponse = _controller.PostSistemas(nameMissingItem);
            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }
       //Adicona um objeto valido
        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            Sistemas testeItem = new Sistemas()
            {
                Descricao = "Sistema de gerenciamento de noticias",
                Sigla = "SGN",
                Email = "contato@sgn.net.br",
                URL = "https://sgn.net.br",
                DataEdicao = DateTime.Now,
                Justificativa = "Edição",
                Status = "Ativo",
                UsuarioResponsavel = "Diego Serra"
            };
            // Act
            var createdResponse = _controller.PostSistemas(testeItem);
            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }
        //adiciona um objeto valido cerifica se é do tipo Sistema e se a sigla é SGN
        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var testItem = new Sistemas()
            {
                Descricao = "Sistema de gerenciamento de noticias",
                Sigla = "SGN",
                Email = "contato@sgn.net.br",
                URL = "https://sgn.net.br",
                DataEdicao = DateTime.Now,
                Justificativa = "Edição",
                Status = "Ativo",
                UsuarioResponsavel = "Diego Serra"
            };
            // Act
            var createdResponse = _controller.PostSistemas(testItem) as CreatedAtActionResult;
            var item = createdResponse.Value as Sistemas;
            // Assert
            Assert.IsType<Sistemas>(item);
            Assert.Equal("SGN", item.Sigla);
        }
        //teste do remove
        //tenta remover um item não existente.
        [Fact]
        public void Remove_NotExistingIdPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var IdInexistente = 99;
            // Act
            var badResponse = _controller.DeleteSistemas(IdInexistente);
            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }
        //remove um item existente
        [Fact]
        public void Remove_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            var Id_Existente = 1;
            // Act
            var okResponse = _controller.DeleteSistemas(Id_Existente);
            // Assert
            Assert.IsType<OkResult>(okResponse);
        }
        //remove um item existente e espera que a contagem seja 9
        [Fact]
        public void Remove_ExistingIdPassed_RemovesOneItem()
        {
            // Arrange
            var Id_Existente = 1;
            // Act
            var okResponse = _controller.DeleteSistemas(Id_Existente);
            CriterioDeBusca criterioDeBusca = new CriterioDeBusca();
            // Assert
            Assert.Equal(9, _service.GetAllItems(criterioDeBusca).Count());
        }
    }
}

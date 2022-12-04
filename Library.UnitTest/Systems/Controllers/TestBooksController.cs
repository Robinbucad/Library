using Library.API.Controllers;
using Library.API.Service;
using Library.UnitTest.Fixtures;
using FluentAssertions;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Library.API.Model;
using Library.API.Repository;
using Library.API.DTO;

namespace Library.UnitTest.Systems.Controllers
{
    public class TestBooksController
    {
        [Fact]
        public async Task GetAllBooks_OnSuccess_Return200()
        {
            // Arrange
            var mockService = new Mock<IBookService>();


            mockService
                .Setup(r => r.GetAllBooks())
                .ReturnsAsync(BooksFixture.GetListBooksDTO());

            var sut = new BooksController(mockService.Object);

            // Act
            var result =(OkObjectResult) await sut.GetBooks();

            // Assert
            result.StatusCode.Should().Be(200);
           
        }

        [Fact]
        public async Task PostBook_OnSuccess_Return201()
        {
            // Arrange
            var mockService = new Mock<IBookService> ();
            
            var sut = new BooksController(mockService.Object);
            // Act
            var book = BooksFixture.PostBook();
           ;
            var result =(CreatedResult) await sut.PostBook(book);

            // Assert
            result.StatusCode.Should().Be(201);
        }


        [Fact]
        public async Task GetBookByIsbn_OnSuccess_Resturn200()
        {

            // Arrange

            var mockSerivce = new Mock<IBookService>();

            mockSerivce
                .Setup(s => s.GetBookByIsbn(It.IsAny<string>()))
                .ReturnsAsync(BooksFixture.GetSingleBookDTO());

            var sut = new BooksController(mockSerivce.Object);


            // Act
            var result =(OkObjectResult) await sut.GetBookByIsbn(It.IsAny<string>());

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetBookByIsbn_OnError_Returns404() 
        {

            // Arrange

            var mockSerivce = new Mock<IBookService>();

            var sut = new BooksController(mockSerivce.Object);

            // Act
            var result = (NotFoundResult)await sut.GetBookByIsbn(It.IsAny<string>());

            // Assert
            result.StatusCode.Should().Be(404);

        }
        
        [Fact]
        public async Task PutBook_OnSuccess_Returns200()
        {
            // Arrange
            BookDTO book = BooksFixture.UpdateBookDTO();
            var mockService = new Mock<IBookService>();

            mockService
                .Setup(s => s.GetBookByIsbn(book.ISBN))
                .ReturnsAsync(book);


            var sut = new BooksController(mockService.Object);
            // Act
            var result = (OkObjectResult) await sut.PutBook(book);

            // Assert
            result.StatusCode.Should().Be(200);
        
        }
        
        
        [Fact]
        public async Task PutBook_IfBookNoExists_Returns404()
        {
            // Arrange
            BookDTO book = BooksFixture.GetSingleBookDTO();
            var mocKservice = new Mock<IBookService>();
            mocKservice
                .Setup(s => s.GetBookByIsbn(book.ISBN));

            var sut = new BooksController(mocKservice.Object);
            // Act
            var result = (NotFoundResult)await sut.PutBook(book);

            // Assert
            result.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task DeleteBook_OnSuccess_ReturnsOk()
        {
            // Arrange
     
            BookDTO book = BooksFixture.UpdateBookDTO();

            var mockService = new Mock<IBookService>();
            mockService
                .Setup(s => s.GetBookByIsbn(It.IsAny<string>()))
                .ReturnsAsync(book);

            var sut = new BooksController(mockService.Object);
            // Act
            var result = (OkObjectResult)await sut.DeleteBook(It.IsAny<string>());

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task DeleteBook_OnError_Returns404()
        {
            // Arrange
           
            var mocKservice = new Mock<IBookService>();
            mocKservice
                .Setup(s => s.GetBookByIsbn(It.IsAny<string>()));

            var sut = new BooksController(mocKservice.Object);
            // Act
            var result = (NotFoundResult)await sut.DeleteBook(It.IsAny<string>());

            // Assert
            result.StatusCode.Should().Be(404);
        }

        
    }
}
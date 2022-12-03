using Library.API.Controllers;
using Library.API.Model;
using Library.API.Repository;
using Library.API.Service;
using Library.UnitTest.Fixtures;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Moq;

namespace Library.UnitTest.Systems.Controllers
{
    public class TestBooksServices
    {
        [Fact]
        public async Task GetAllBooks_OnSuccess_ReturnAllBooks()
        {
            // Arrange
            var mockService = new Mock<IMongoRepository>();
            mockService
                .Setup(r => r.GetAllBooks())
                .ReturnsAsync(BooksFixture.GetListBooks());

            var sut = new BooksService(mockService.Object);

            // Act
            var result =await sut.GetAllBooks();

            // Assert

            Assert.Equal(3,result.Count);
            
        }

        [Fact]
        public void Post_OnSucess_ReturnsNotNull()
        {
            // Arrange
            var mockService = new Mock<IMongoRepository>();

            var sut = new BooksService(mockService.Object);
            // Act
            var book = BooksFixture.GetSingleBook();
            var result = sut.SaveBook(book);
            // Assert
            
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetBookByIsbn_OnSuccess_ReturnsBook()
        {
            // Arrange
            string id = "638b4cb27a08b1cb927eb3ab";
   
            var mockService = new Mock<IMongoRepository>();
                mockService
                    .Setup(s => s.GetBookByIsbn(id))
                    .ReturnsAsync(BooksFixture.GetSingleBook());

            var sut = new BooksService(mockService.Object);
            // Act
            var result = await sut.GetBookByIsbn(id);


            // Assert
            Assert.Equal(id, id);
            Assert.Equal("Libro test", result.Title);
        }

        [Fact]
        public async Task UpdateBook_OnSuccess_ReturnsUpdatedBook()
        {
            // Arrange
            Book book = BooksFixture.UpdateBook();


            var mockService = new Mock<IMongoRepository>();
            mockService
                .Setup(s => s.UpdateBook(book))
                .ReturnsAsync(book);

            var sut = new BooksService(mockService.Object);

            // Act
            var result = await sut.UpdateBook(book);

            // Result
            Assert.Equal("Libro update", result.Title);
            Assert.Equal("Gran libro", result.Description);
        }

       
    }
}
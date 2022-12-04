using Library.API.Controllers;
using Library.API.DTO;
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
            var mockRepo = new Mock<IMongoRepository>();
            mockRepo
                .Setup(s => s.GetAllBooks())
                .ReturnsAsync(BooksFixture.GetListBooks());

            var sut = new BooksService(mockRepo.Object);

            // Act
            List<BookDTO> books =await sut.GetAllBooks();
            // Assert
        
            Assert.Equal(3,books.Count);
        }

        [Fact]
        public async Task Post_OnSucess_ReturnsNotNull()
        {
            // Arrange
            var mockRepo = new Mock<IMongoRepository>();

            var sut = new BooksService(mockRepo.Object);
            // Act
            var book = BooksFixture.PostBook();
            var result =await sut.SaveBook(book);
            // Assert
            
            Assert.Equal("Libro test post", result.Title);
            Assert.Equal("Gran libro test post", result.Description);
            Assert.Equal("12356", result.ISBN);
        }

        [Fact]
        public async Task GetBookByIsbn_OnSuccess_ReturnsBook()
        {
            // Arrange
            string id = "bookid";
   
            var mockRepo = new Mock<IMongoRepository>();
                mockRepo
                    .Setup(s => s.GetBookByIsbn(id))
                    .ReturnsAsync(BooksFixture.GetSingleBook());

            var sut = new BooksService(mockRepo.Object);
            // Act
            var result = await sut.GetBookByIsbn(id);


            // Assert

            Assert.Equal("Libro test", result.Title);
            Assert.Equal("Gran libro test", result.Description);
            Assert.Equal("12356", result.ISBN);
        }

        [Fact]
        public async Task UpdateBook_OnSuccess_ReturnsUpdatedBook()
        {
            // Arrange
            BookDTO bookDTO = BooksFixture.UpdateBookDTO();
            Book book = BooksFixture.UpdateBook();

            var mockService = new Mock<IMongoRepository>();
            mockService
                .Setup(s => s.UpdateBook(book))
                .ReturnsAsync(book);

            var sut = new BooksService(mockService.Object);

            // Act
            var result = await sut.UpdateBook(bookDTO);

            // Result
            Assert.Equal("Libro update", result.Title);
            Assert.Equal("Gran libro", result.Description);
            Assert.Equal("1234", result.ISBN);
        }

       
    }
}
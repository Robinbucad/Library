using Library.API.Model;
using Library.API.Service;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Library.API.Repository
{
    public class MongoDBRepository : IMongoRepository
    {
        private readonly IMongoCollection<Book> _booksCollection;
        public MongoDBRepository(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase db = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _booksCollection = db.GetCollection<Book>(mongoDBSettings.Value.CollectionName);
        }
        public async Task<List<Book>> GetAllBooks()
        {
            return await _booksCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Book> GetBookByIsbn(string ISBN)
        {
            return  await _booksCollection.Find<Book>(b => b.ISBN == ISBN).FirstOrDefaultAsync();
        }

        public async Task SaveBook(Book book)
        {
             await _booksCollection.InsertOneAsync(book);
        }

        public async Task<Book> UpdateBook(Book book)
        {
            var filter = Builders<Book>.Filter.Eq("ISBN", book.ISBN);

            var update = Builders<Book>.Update.Set("Title", book.Title);
            update.Set("Description", book.Description);

            return  await _booksCollection.FindOneAndUpdateAsync(filter, update);
        }

        public async Task<Book> DeleteBook(string ISBN)
        {
            return await _booksCollection.FindOneAndDeleteAsync<Book>(b => b.ISBN.Equals(ISBN));
        }

    }
}

using DataBaseRepository;
using DataBaseRepository.Interfaces;
using DataBaseRepository.Models;
using Moq;
using System.Collections.Generic;

namespace ManBookAPITests.DbMoq
{
    public class DbDataMoq
    {

        private List<Author> _authorsList = new List<Author>
        {
            new Author { Id = 1, FirstName = "Alexey", MiddleName = "Igorevich", LastName = "1" },
            new Author { Id = 1, FirstName = "Igor", MiddleName = "Romanovich", LastName = "2" },
            new Author { Id = 1, FirstName = "Roman", MiddleName = "Alexeevich", LastName = "3" }
        };
        
        public IBasicContext GetMoqDataContext()
        {
            var dataContextMock = new Mock<IBasicContext>();

            dataContextMock.Setup(bc => bc.Authors).Returns(DbContextMoq.GetQueryableMockDbSet<Author>(_authorsList).Object);          
            dataContextMock.Setup(p => p.SaveChanges()).Returns(1);

            return dataContextMock.Object;
        }
    }
}

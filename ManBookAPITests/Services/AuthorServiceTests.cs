using Microsoft.VisualStudio.TestTools.UnitTesting;
using ManBookAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using DataBaseRepository.Models;
using ManBookAPI.Controllers;
using DataBaseRepository;
using Microsoft.EntityFrameworkCore;
using ManBookAPITests.DbMoq;
using DataBaseRepository.Interfaces;

namespace ManBookAPI.Services.Tests
{
    [TestClass()]
    public class AuthorServiceTests
    {
        
        IBasicContext testContext;
        DbDataMoq dataMoq = new DbDataMoq();

        public AuthorServiceTests()
        {
            testContext = dataMoq.GetMoqDataContext();
        }
       

        [TestMethod()]
        public void GetAllAuthorsTest()
        {
            var authorService = new AuthorService(testContext);
            var result = authorService.GetAllAuthors();
            Assert.AreEqual(result.Count(), testContext.Authors.Count());
        }      
    }
}
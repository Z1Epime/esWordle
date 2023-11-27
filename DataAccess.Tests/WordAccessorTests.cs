using DataAccess.JSON;
using DataAccess.Model;
using DataAccess.Resources;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows;

namespace DataAccess.Tests
{
    [TestFixture]
    public class WordAccessorTests
    {
        private WordAccessor wordAccessor;

        [SetUp]
        public void SetUp()
        {
            wordAccessor = DependencyContainer.ServiceProvider.GetRequiredService<WordAccessor>();
        }

        [Test]
        public async Task GetWords_ListOfValidWords()
        {
            var list = await wordAccessor.GetWords();

            var hasFaultyWord = list.Any(word => word == null || 
                string.IsNullOrWhiteSpace(word.Letters) || 
                word.Letters.Length != Word.WordLength);

            Assert.That(hasFaultyWord, Is.False);
        }
    }
}

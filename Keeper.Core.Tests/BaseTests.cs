﻿using Keeper.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Keeper.Core.Tests
{
    [TestClass]
    public class BaseTests
    {
        protected Client _client { get; private set; }

        public BaseTests()
        {
            _client = new Client();
        }

        [AssemblyCleanup]
        public static void Cleanup()
        {
            CleanupDatabase();
        }

        public string GeneratePseudoRandomName<T>()
        {
            var randomProvider = new RNGCryptoServiceProvider();
            var randomNumber = new byte[8];
            randomProvider.GetBytes(randomNumber);

            return $"Test{typeof(T).Name}{Math.Abs(BitConverter.ToInt32(randomNumber, 0))}";
        }

        private static void CleanupDatabase()
        {
            //Warning: order of these commands actually matters!
            var dbContext = new ApplicationDbContext();
            dbContext.UserSessions.RemoveRange(dbContext.UserSessions);
            dbContext.Users.RemoveRange(dbContext.Users);
            dbContext.Tasks.RemoveRange(dbContext.Tasks);
            dbContext.Projects.RemoveRange(dbContext.Projects);
            dbContext.SaveChanges();
        }
    }
}

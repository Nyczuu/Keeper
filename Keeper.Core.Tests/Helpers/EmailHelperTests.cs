using Keeper.Core.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Core.Tests.Helpers
{
    [TestClass()]
    public class EmailHelperTests
    {
        [DataTestMethod]
        [DataRow("joe@home.org")]
        [DataRow("joe@joebob.name")]
        [DataRow("joe&bob@bob.com")]
        [DataRow("~joe@bob.com")]
        [DataRow("joe$@bob.com")]
        [DataRow("joe+bob@bob.com")]
        [DataRow("o'reilly@there.com")]
        [DataRow("joe@home.com")]
        [DataRow("joe.bob@home.com")]
        [DataRow("joe@his.home.com")]
        [DataRow("a@abc.org")]
        [DataRow("a@192.168.0.1")]
        [DataRow("a@10.1.100.1")]
        public void DetectValidEmails(string email)
        {
            Assert.IsTrue(EmailHelper.IsValidEmail(email));
        }

        [DataTestMethod]
        [DataRow("joe@home")]
        [DataRow("a@b.c")]
        [DataRow("joe-bob[at]home.com")] 
        [DataRow("joe@his.home.place")]
        [DataRow("joe.@bob.com")]
        [DataRow(".joe@bob.com")]
        [DataRow("john..doe@bob.com")]
        [DataRow("john.doe@bob..com")]
        [DataRow("joe<>bob@bob.come")]
        [DataRow("joe@his.home.com.")] 
        [DataRow("a@10.1.100.1a")]
        public void DetectInvalidEmails(string email)
        {
            Assert.IsFalse(EmailHelper.IsValidEmail(email));
        }
    }
}

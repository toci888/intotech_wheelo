using Intotech.Wheelo.Social.Tests.Persistence.Seed;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Social.Tests.Persistence.Seed
{
    [TestClass]
    public class SocialSeedManager
    {
        [TestMethod]
        public void SeedAllDb()
        {
            new SeedGroups().Insert();
            new SeedGroupMembers().Insert();
            new SeedOrganizeMeeting().Insert();
        }
    }
}
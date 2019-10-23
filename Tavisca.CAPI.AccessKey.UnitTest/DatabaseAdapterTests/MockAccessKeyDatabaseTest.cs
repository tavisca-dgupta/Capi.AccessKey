using System;
using System.Linq;
using Tavisca.CAPI.AccessKey.MockProvider.DatabaseProvider;
using Tavisca.CAPI.AccessKey.Model.Interfaces;
using Xunit;

namespace Tavisca.CAPI.AccessKey.UnitTest.DatabaseAdapterTests
{
    public class MockAccessKeyDatabaseTest
    {
        [Fact]
        public void Get_all_the_clients_from_the_database()
        {
            IDatabaseAdapter database = new MockAccessKeyDatabase();
            var clients = database.GetAllClients();
        }

    }
}

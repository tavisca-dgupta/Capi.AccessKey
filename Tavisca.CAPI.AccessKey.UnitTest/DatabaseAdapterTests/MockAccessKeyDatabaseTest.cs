﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.MockProvider.DatabaseProvider;
using Tavisca.CAPI.AccessKey.MockProvider.DatabaseProvider.Utility;
using Tavisca.CAPI.AccessKey.MockProvider.Tanslator;
using Tavisca.CAPI.AccessKey.Model.Interfaces;
using Tavisca.CAPI.AccessKey.Model.Models;
using Xunit;

namespace Tavisca.CAPI.AccessKey.UnitTest.DatabaseAdapterTests
{
    public class MockAccessKeyDatabaseTest
    {
        [Fact]
        public async Task Get_all_the_clients_from_the_database()
        {
            IDatabaseAdapter database = new MockAccessKeyDatabase();
            var clients =  await JsonFileReader.ReadAllJsonObject("MockAccessKeyData.json");
            var keys = new List<AccessKeyModel>();
            for(int i=0;i<clients.Count;i++)
            {
                var key = clients[i].ToAccessKeyModel();
                keys.Add(key);
            }
            Assert.Equal(keys, await database.GetAllClients());

        }

        [Fact]
        public async Task Deactivate_a_key()
        {
            IDatabaseAdapter database = new MockAccessKeyDatabase();
            AccessKeyModel accessKey = new AccessKeyModel();
            accessKey.ClientId = "1edb9skbh8g";
            accessKey.ClientName = "Citi Bank";
            accessKey.AccessKey = "ad9ff893-bba2-44be-b961-63ceccab24a8";
            accessKey.IsKeyActive = true;
            accessKey.UpdatedBy = "anil kadam";
            var client = await database.DeactivateKey(accessKey);
            Assert.False(client.IsKeyActive);
        }
        [Fact]
        public async Task Activate_a_key()
        {
            IDatabaseAdapter database = new MockAccessKeyDatabase();
            AccessKeyModel accessKey = new AccessKeyModel();
            accessKey.ClientId = "1edb9skbh8g";
            accessKey.ClientName = "Citi Bank";
            accessKey.AccessKey = "ad9ff893-bba2-44be-b961-63ceccab24a8";
            accessKey.IsKeyActive = false;
            accessKey.UpdatedBy = "anil kadam";
            var client = await database.ActivateKey(accessKey);
            Assert.True(client.IsKeyActive);
        }

        [Fact]
        public async Task Get_a_client_by_id()
        {
            IDatabaseAdapter database = new MockAccessKeyDatabase();
            AccessKeyModel accessKey = new AccessKeyModel();
            accessKey.ClientId = "1edb9skbh8g";
            accessKey.ClientName = "Citi Bank";
            accessKey.AccessKey = "ad9ff893-bba2-44be-b961-63ceccab24a8";
            accessKey.IsKeyActive = false;
            accessKey.UpdatedBy = "anil kadam";
            var client = await database.GetClientById(accessKey.ClientId);
            Assert.Equal("ad9ff893-bba2-44be-b961-63ceccab24a8", client.AccessKey);
        }
        [Fact]
        public async Task Get_a_client_by_id_if_client_not_present()
        {
            IDatabaseAdapter database = new MockAccessKeyDatabase();
            var client = await database.GetClientById("abcdde678rbjzbc8e");
            Assert.Null(client);
        }

    }
}

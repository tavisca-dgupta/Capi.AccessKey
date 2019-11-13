using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tavisca.CAPI.AccessKey.Core.Components;
using Tavisca.CAPI.AccessKey.MockProvider.DatabaseProvider;
using Tavisca.CAPI.AccessKey.MockProvider.ParameterStore;
using Tavisca.CAPI.AccessKey.MockProvider.ParameterStore.Utility;
using Tavisca.CAPI.AccessKey.Model.Interfaces;
using Tavisca.CAPI.AccessKey.Services.Services;
using Tavisca.Common.Plugins.Aws;
using Tavisca.Common.Plugins.Configuration;
using Tavisca.Platform.Common.Configurations;
using Tavisca.Platform.Common.Containers;
using Tavisca.CAPI.AccessKey.Model.Models.Common;

namespace Tavisca.CAPI.AccessKey.Web
{
    public class Module : IModule
    {
        public IEnumerable<Registration> GetRegistrations()
        {
            var sensitiveDataProvider = new Tavisca.Common.Plugins.Aws.ParameterStoreProvider();
            var remoteConfigurationProvider = new ConsulConfigurationStore();

            new ConfigurationBuilder()
                .WithRemoteStore(remoteConfigurationProvider)
                .WithSensitiveDataProvider(sensitiveDataProvider)
                .Apply();
            yield return Registration.AsSingleton<IConfigurationStore>(() => remoteConfigurationProvider, KeyStore.InstanceName.RemoteConfigurationStore);
            yield return Registration.AsSingleton<ISensitiveDataProvider>(() => sensitiveDataProvider, KeyStore.InstanceName.SensitiveDataProvider);
            Func<IConfigurationProvider> configurationProvider = () => new ConfigurationProvider(Model.Models.Common.KeyStore.ApplicationName);
            yield return Registration.AsSingleton<IConfigurationProvider>(() => configurationProvider.Invoke());

            yield return Registration.AsPerCall<IAccessKeyService, AccessKeyService>();
            yield return Registration.AsSingleton<IDatabaseAdapter, MockAccessKeyDatabase>();
            yield return Registration.AsPerCall<ICreateKey, CreateKeyComponent>();
            yield return Registration.AsPerCall<IDeactivateKey, DeactivateKeyComponent>();
            yield return Registration.AsPerCall<IActivateKey, ActivateKeyComponent>();
            yield return Registration.AsPerCall<IAccessKeyComponent, AccessKeyComponent>();
            yield return Registration.AsSingleton<IParameterStore, ParameterStore>();
            yield return Registration.AsSingleton<IParameterStoreProvider, Tavisca.CAPI.AccessKey.MockProvider.ParameterStore.Utility.ParameterStoreProvider>();
        }
    }
}

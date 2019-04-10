﻿using Microsoft.Extensions.DependencyInjection;
using DataDictionaryManagement.Localization;
using Volo.Abp.Application;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace DataDictionaryManagement
{
    [DependsOn(
        typeof(DataDictionaryManagementDomainSharedModule),
        typeof(AbpDddApplicationModule)
        )]
    public class DataDictionaryManagementApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<VirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<DataDictionaryManagementApplicationContractsModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<DataDictionaryManagementResource>()
                    .AddVirtualJson("/MyCompanyName/DataDictionaryManagement/Localization/ApplicationContracts");
            });
        }
    }
}

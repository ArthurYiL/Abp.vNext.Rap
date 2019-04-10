﻿using Microsoft.Extensions.DependencyInjection;
using DataDictionaryManagement.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace DataDictionaryManagement
{
    [DependsOn(
        typeof(DataDictionaryManagementDomainSharedModule)
        )]
    public class DataDictionaryManagementDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<VirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<DataDictionaryManagementDomainModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Get<DataDictionaryManagementResource>().AddVirtualJson("/MyCompanyName/DataDictionaryManagement/Localization/Domain");
            });

            Configure<ExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("DataDictionaryManagement", typeof(DataDictionaryManagementResource));
            });
        }
    }
}

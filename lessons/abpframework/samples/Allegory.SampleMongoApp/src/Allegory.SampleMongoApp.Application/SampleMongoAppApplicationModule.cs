﻿using Allegory.SampleMongoApp.DI;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace Allegory.SampleMongoApp;

[DependsOn(
    typeof(SampleMongoAppDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(SampleMongoAppApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class SampleMongoAppApplicationModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        SkipAutoServiceRegistration = true;
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAssemblyOf<SampleMongoAppApplicationModule>();

        context.Services.AddTransient<IMultiManager, SomeSpecificManager>();
        context.Services.AddTransient<IMultiManager, OtherManager>();

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<SampleMongoAppApplicationModule>();
        });
    }
}

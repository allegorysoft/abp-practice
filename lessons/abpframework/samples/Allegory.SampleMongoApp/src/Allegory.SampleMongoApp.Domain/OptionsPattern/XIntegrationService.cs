﻿using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;

namespace Allegory.SampleMongoApp.OptionsPattern;

[DisableConventionalRegistration]
public class XIntegrationService : IIntegrationService
{
    protected virtual SampleOptions Options { get; }

    public XIntegrationService(IOptions<SampleOptions> options)
    {
        Options = options.Value;
    }

    public Task DoAsync()
    {
        var username = Options.Username;
        var password = Options.Password;

        return Task.CompletedTask;
    }
}
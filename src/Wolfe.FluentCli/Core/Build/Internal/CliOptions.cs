﻿using System.Collections.Generic;

namespace Wolfe.FluentCli.Core.Build.Internal
{
    internal class CliOptions
    {
        public List<CliOption> Options { get; init; } = new();
        public OptionFactory OptionMap { get; init; }
    }
}

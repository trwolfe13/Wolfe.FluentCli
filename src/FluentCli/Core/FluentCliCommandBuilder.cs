﻿using FluentCli.Models;
using System;
using System.Collections.Generic;

namespace FluentCli.Core
{
    public class FluentCliCommandBuilder : IFluentCliCommandBuilder
    {
        private readonly string _name;
        private readonly Type _handlerType;
        private readonly List<FluentCliCommand> _subCommands = new();

        protected FluentCliCommandBuilder(string name, Type handlerType)
        {
            _name = name;
            _handlerType = handlerType;
        }

        public static IFluentCliCommandBuilder Create<THandler>(string name) where THandler : ICommandHandler => new FluentCliCommandBuilder(name, typeof(THandler));

        public FluentCliCommand Build()
        {
            return new FluentCliCommand()
            {
                Name = _name,
                Handler = _handlerType,
                SubCommands = _subCommands
            };
        }

        public IFluentCliCommandBuilder AddCommand<THandler>(string name) where THandler : ICommandHandler
        {
            _subCommands.Add(new FluentCliCommand()
            {
                Name = name,
                Handler = typeof(THandler)
            });
            return this;
        }
    }

    public interface IFluentCliCommandBuilder
    {
        IFluentCliCommandBuilder AddCommand<THandler>(string name) where THandler : ICommandHandler;
        FluentCliCommand Build();
    }
}

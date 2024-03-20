﻿using Microsoft.Extensions.DependencyInjection;
using System;

namespace DidactCore.DependencyInjection
{
    public interface IDidactDependencyInjector
    {
        /// <summary>
        /// The original <see cref="IServiceCollection"/> from Didact Engine.
        /// These services are automatically included in the <see cref="FlowServiceCollection"/>.
        /// </summary>
        IServiceCollection ApplicationServiceCollection { get; set; }

        /// <summary>
        /// The <see cref="IServiceCollection"/> that contains all of the services from both Didact Engine and the Flow Library.
        /// </summary>
        IServiceCollection FlowServiceCollection { get; set; }

        /// <summary>
        /// The corresponding <see cref="IServiceProvider"/> to the <see cref="FlowServiceCollection"/>.
        /// </summary>
        IServiceProvider FlowServiceProvider { get; set; }

        /// <summary>
        /// Clears the <see cref="FlowServiceCollection"/> and resets it to the <see cref="ApplicationServiceCollection"/>.
        /// </summary>
        void ResetServiceCollection();

        /// <summary>
        /// Adds each service from the bridgeServiceCollection to the <see cref="FlowServiceCollection"/>
        /// and rebuilds the <see cref="FlowServiceProvider"/>.
        /// </summary>
        /// <param name="bridgeServiceCollection"></param>
        void AddAndRebuildServiceCollection(IServiceCollection bridgeServiceCollection);
    }
}

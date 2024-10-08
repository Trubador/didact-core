﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace DidactCore.DependencyInjection
{
    public class DidactDependencyInjector : IDidactDependencyInjector
    {
        //public IServiceCollection ApplicationServiceCollection { get; set; }

        //public IServiceCollection FlowServiceCollection { get; set; }

        //public IServiceProvider ApplicationServiceCollection { get; set; }

        //public IServiceProvider FlowServiceCollection { get; set; }

        //public IServiceProvider FlowServiceProvider { get; set; }

        public IServiceCollection ApplicationServiceCollection { get; set; }
        public IServiceCollection FlowServiceCollection { get; set; }
        public IServiceProvider FlowServiceProvider { get; set; }

        public DidactDependencyInjector(IServiceCollection applicationServiceCollection)
        {
            //FlowServiceCollection = new ServiceCollection();


            ApplicationServiceCollection = applicationServiceCollection;
            FlowServiceCollection = applicationServiceCollection;
            FlowServiceProvider = FlowServiceCollection.BuildServiceProvider();

            //ApplicationServiceCollection = applicationServiceCollection;
            //FlowServiceCollection = new ServiceCollection();

            //FlowServiceProvider = FlowServiceCollection.BuildServiceProvider();

        }

        public void ResetServiceCollection()
        {
            FlowServiceCollection.Clear();
            FlowServiceCollection = ApplicationServiceCollection;
        }

        public void AddAndRebuildServiceCollection(IServiceCollection bridgeServiceCollection)
        {
            foreach (var service in bridgeServiceCollection)
            {
                FlowServiceCollection.TryAdd(service);
            }

            FlowServiceProvider = FlowServiceCollection.BuildServiceProvider();
        }

        public T CreateInstance<T>(params object[] parameters)
        {
            return ActivatorUtilities.CreateInstance<T>(FlowServiceProvider, parameters);
        }

        public object CreateInstance(Type type, params object[] parameters)
        {
            return ActivatorUtilities.CreateInstance(FlowServiceProvider, type, parameters);
        }
        public void BuildFlowServiceProvider()
        {
            FlowServiceProvider = FlowServiceCollection.BuildServiceProvider();
        }
    }
}

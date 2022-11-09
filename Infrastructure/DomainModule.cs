using System;
using System.Reflection;
using Autofac;
using Domain.GroupPosts;
using Domain.Repositories;
using Infrastructure.Domain;
using Infrastructure.Repositories;
using Module = Autofac.Module;

namespace Infrastructure
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GroupUnitOfWork>().As<IGroupUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterType<GroupPostReadOnlyRepository>().As<IGroupPostReadOnlyRepository>().InstancePerLifetimeScope();

            builder.RegisterType<GroupPostCommandRepository>().As<IGroupPostCommandRepository>().InstancePerLifetimeScope();

        }
    }
}


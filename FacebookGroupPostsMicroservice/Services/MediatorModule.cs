using System;
using System.Reflection;
using Application.Behaviours;
using Application.GroupPosts.Commands.CreateGroupPost;
using Application.GroupPosts.Queries.GetGroupPosts;
using Autofac;
using Autofac.Core;
using MediatR;
using MediatR.Pipeline;

namespace FacebookGroupPostsMicroservice.Services
{
    public class MediatorModule : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            // request & notification handlers
            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });


            builder.RegisterAssemblyTypes(typeof(CreateGroupPostCommand).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterGeneric(typeof(ValidationBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterAssemblyTypes(typeof(GetGroupPostsQuery).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(GetGroupPostsHandler).GetTypeInfo().Assembly).AsImplementedInterfaces();

        }
    }
}


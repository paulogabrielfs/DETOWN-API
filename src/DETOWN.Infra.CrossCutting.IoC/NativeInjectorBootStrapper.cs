using DETOWN.Application.Interfaces;
using DETOWN.Application.Services;
using DETOWN.Domain.CommandHandlers;
using DETOWN.Domain.Commands;
using DETOWN.Domain.Core.Bus;
using DETOWN.Domain.Core.Events;
using DETOWN.Domain.Core.Notifications;
using DETOWN.Domain.EventHandlers;
using DETOWN.Domain.Events;
using DETOWN.Domain.Interfaces;
using DETOWN.Domain.Services;
using DETOWN.Infra.CrossCutting.Bus;
using DETOWN.Infra.CrossCutting.Identity.Authorization;
using DETOWN.Infra.CrossCutting.Identity.Models;
using DETOWN.Infra.CrossCutting.Identity.Services;
using DETOWN.Infra.Data.EventSourcing;
using DETOWN.Infra.Data.Repository;
using DETOWN.Infra.Data.Repository.EventSourcing;
using DETOWN.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
namespace DETOWN.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddHttpContextAccessor();
            // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<INewsAppService, NewsAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<NewsRegisteredEvent>, NewsEventHandler>();
            

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewCustomerCommand, bool>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCustomerCommand, bool>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCustomerCommand, bool>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<RegisterNewsCommand, bool>, NewsCommandHandler>();

            // Domain - 3rd parties
            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<IMailService, MailService>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();

            // Infra - Identity Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
            services.AddSingleton<IJwtFactory, JwtFactory>();
        }
    }
}

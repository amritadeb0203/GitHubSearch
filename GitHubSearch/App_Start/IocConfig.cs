using GitHubSearch.Abstraction;
using GitHubSearch.Interface;
using GitHubSearch.Models;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace GitHubSearch.App_Start
{
   public static class IocConfig
    {
        public static void RegisterDependencies()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Register<IConfig, Config>();
            container.Register<IConverter, JsonConverter>();
            container.Register<IWebClient, RestWebClient>();
            container.Register<IGitHubServices<GitHubRepoModel>, GitHubService>();
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
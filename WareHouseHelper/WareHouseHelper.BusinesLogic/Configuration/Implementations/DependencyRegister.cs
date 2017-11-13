using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using WareHouseHelper.BusinesLogic.Action.Base;
using WareHouseHelper.DataAccess.Repositories.Interfaces;

namespace WareHouseHelper.BusinesLogic.Configuration.Implementations
{
    public static class RegisterDependecy
    {
        public static void Register(IServiceCollection services)
        {
            var dbDependencyBuilder = new DependencyBuilder<IRepository>();
            dbDependencyBuilder.Register(services);

            var blDependencyBuilder = new DependencyBuilder<IAction>();
            blDependencyBuilder.Register(services);
        }
    }
}
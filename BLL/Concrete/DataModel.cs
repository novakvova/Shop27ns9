using Autofac;
using DAL.Abstact;
using DAL.Concrete;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class DataModel : Module
    {
        private string _connStr;
        public DataModel(string connString)
        {
            _connStr = connString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new EFContext(this._connStr))
                .As<IEFContext>().InstancePerRequest();
            builder.RegisterType<CategoryRepository>()
                .As<ICategoryRepository>().InstancePerRequest();
            base.Load(builder);
        }
    }
}

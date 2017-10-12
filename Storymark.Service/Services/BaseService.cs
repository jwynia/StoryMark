using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace Storymark.Service.Services
{
    internal class BaseService
    {
        protected ISessionFactory _sessionFactory;

        public BaseService(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodeBikeAPI.Services
{
    public class ControllerServices<TDataContext> where TDataContext : class
    {
        
        
        
        public ILoggerFactory LoggerFactory { get; }

       
        public IHostingEnvironment Environment { get; }

        readonly Lazy<TDataContext> _dataContext;

       
        public TDataContext DataContext => _dataContext.Value;


        /// Inicializa uma nova instância
        public ControllerServices(
            ILoggerFactory loggerFactory,
            IHostingEnvironment environment,
            Lazy<TDataContext> dataContext
            )
        {

            this.LoggerFactory = loggerFactory;
            this.Environment = environment ?? throw new ArgumentNullException(nameof(environment));
            this._dataContext = dataContext;
        }
    }
}

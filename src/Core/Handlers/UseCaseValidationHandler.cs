﻿using EdFiValidation.ApiProxy.Core.Commands;
using EdFiValidation.ApiProxy.Core.Models;
using EdFiValidation.ApiProxy.Core.Utility;
using EdFiValidation.ApiProxy.Utilities;
using MongoDB.Driver;

namespace EdFiValidation.ApiProxy.Core.Handlers
{
    public class UseCaseValidationHandler : ICommandHandler<CreateUseCaseValidation>
    {
        private readonly MongoDatabase _db;

        public UseCaseValidationHandler(IConfig config)
        {
            var url = new MongoUrl(config.ProxyDbConnectionString);
            _db = new MongoClient(url)
                .GetServer()
                .GetDatabase(url.DatabaseName);

            
        }

        public void Handle(CreateUseCaseValidation command)
        {
            var useCaseValidation = new UseCaseValidation
            {

            };

            var collection = _db.GetCollection<UseCaseValidation>();
            collection.Save(useCaseValidation);
        }
    }
}

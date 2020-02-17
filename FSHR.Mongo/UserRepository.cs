using System;

namespace FSHR.Mongo
{
    public class UserRepository : RepositoryBase<Models.User, int>, FSHR.Services.Repositories.IUserRepository
    {
        public UserRepository(IMongoDatabaseSettings settings)
        : base(settings)
        {
        }

        protected override string CollectionName => Settings.UsersCollectionName;
    }
}

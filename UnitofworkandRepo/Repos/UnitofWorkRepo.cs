using UnitofworkandRepo.Interface;
using UnitofworkandRepo.Models;
using UnitofworkandRepo.Controllers;

namespace UnitofworkandRepo.Repos
{
    public class UnitofWorkRepo : IUnitofWork
    {
        public iMytblRepository mytblRepository { get; private set; }
        public iToDoItemRepository todoitemRepository { get; private set; }
        //declare private var that are used for dapper like _db
        // then this._db = _db; inside the func and add IDbConnection _db as arg
        private readonly TestContext testContext;

        public UnitofWorkRepo(TestContext testContext)
        {
            this.testContext = testContext;
            mytblRepository = new MytblRepos(testContext);
            todoitemRepository = new TodoItemRepos(testContext);
        }

        public async Task CompleteAsync()
        {
            await this.testContext.SaveChangesAsync();
        }
    }
}

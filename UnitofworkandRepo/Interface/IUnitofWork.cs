namespace UnitofworkandRepo.Interface
{
    public interface IUnitofWork
    {
        iMytblRepository mytblRepository { get; }
        iToDoItemRepository todoitemRepository { get; }
        Task CompleteAsync();
    }
}

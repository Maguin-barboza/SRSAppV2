namespace SRSAppV2.Infra.UnityOfWork;

public interface IUnitOfWork
{
    Task SaveChanges();
}

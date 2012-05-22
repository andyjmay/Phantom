using System.Linq;

namespace Phantom {
  public interface IModelRepository {
    IQueryable<T> GetAll<T>() where T : ModelBase;
    T GetById<T>(int modelId) where T : ModelBase;
    T Add<T>(T modelToAdd) where T : ModelBase;
    T Update<T>(T modelToUpdate) where T : ModelBase;
    void Delete<T>(T modelToDelete) where T : ModelBase;
    void SaveChanges();
  }
}

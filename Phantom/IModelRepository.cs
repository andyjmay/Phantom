using System.Linq;

namespace Phantom {
  public interface IModelRepository<T> where T : ModelBase {
    IQueryable<T> GetAll();
    T GetById(int modelId);
    T Add(T modelToAdd);
    T Update(T modelToUpdate);
    void Delete(T modelToDelete);
    void SaveChanges();
  }
}

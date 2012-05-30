using System.Data;
using System.Linq;

namespace Phantom {
  public class ModelRepository<T> : IModelRepository<T> where T : ModelBase {
    private readonly ModelContext db;

    public ModelRepository(ModelContext dataContext) {
      db = dataContext;
    }

    public IQueryable<T> GetAll() {
      return db.Set<T>().OfType<T>();
    }

    public T GetById(int modelID) {
      return db.Set<T>().OfType<T>().Single(m => m.ID == modelID);
    }

    public T Add(T modelToAdd) {
      db.Set<T>().Add(modelToAdd);
      return modelToAdd;
    }

    public T Update(T modelToUpdate) {
      db.Entry(modelToUpdate).State = EntityState.Modified;
      return modelToUpdate;
    }

    public void Delete(T modelToUpdate) {
      db.Entry(modelToUpdate).State = EntityState.Deleted;
    }

    public void SaveChanges() {
      db.SaveChanges();
    }
  }
}

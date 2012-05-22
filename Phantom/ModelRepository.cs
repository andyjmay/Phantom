using System.Data;
using System.Linq;

namespace Phantom {
  public class ModelRepository : IModelRepository {
    private readonly ModelContext db;

    public ModelRepository(ModelContext dataContext) {
      db = dataContext;
    }

    public IQueryable<T> GetAll<T>() where T : ModelBase {
      return db.Set<T>().OfType<T>();
    }

    public T GetById<T>(int modelID) where T : ModelBase {
      return db.Set<T>().OfType<T>().Single(m => m.ID == modelID);
    }

    public T Add<T>(T modelToAdd) where T : ModelBase {
      db.Set<T>().Add(modelToAdd);
      return modelToAdd;
    }

    public T Update<T>(T modelToUpdate) where T : ModelBase {
      db.Entry(modelToUpdate).State = EntityState.Modified;
      return modelToUpdate;
    }

    public void Delete<T>(T modelToUpdate) where T : ModelBase {
      db.Entry(modelToUpdate).State = EntityState.Deleted;
    }

    public void SaveChanges() {
      db.SaveChanges();
    }
  }
}

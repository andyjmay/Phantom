using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data.Entity;
using System.IO;
using System.Reflection;

namespace Phantom {
  public partial class ModelContext : DbContext {
    [ImportMany]
    public IEnumerable<ModelBase> ModelClasses { get; set; }

    public ModelContext(string pluginFolder = "") {
      var catalog = new AggregateCatalog();
      if (string.IsNullOrEmpty(pluginFolder)) {
        catalog.Catalogs.Add(new DirectoryCatalog(
          Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
        ));
      } else {
        catalog.Catalogs.Add(new DirectoryCatalog(
          Path.GetDirectoryName(pluginFolder)
        ));
      }
      var container = new CompositionContainer(catalog);
      container.ComposeParts(this);
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder) {
      MethodInfo entityMethod = typeof(DbModelBuilder).GetMethod("Entity");

      foreach (ModelBase derivedModel in ModelClasses) {
        var genericMethod = entityMethod.MakeGenericMethod(derivedModel.GetType());
        dynamic entityConfig = genericMethod.Invoke(modelBuilder, null);
        entityConfig.ToTable(derivedModel.GetType().Name);
      }

      base.OnModelCreating(modelBuilder);
    }
  }
}

using System.ComponentModel.DataAnnotations;

namespace Phantom {
  public abstract class ModelBase {
    [Required]
    public int ID { get; set; }
  }
}

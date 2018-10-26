using System.ComponentModel.DataAnnotations;

namespace RadixAPI.Model.Entity
{
    public abstract class DbEntity<T>
    {
        [Key]
        public T Id {get; set;}
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace Keeper.Data
{
    public abstract class BaseEntity
    {
        [Key]
        public int Identifier { get; private set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
    }
}

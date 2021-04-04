using System;
using System.ComponentModel.DataAnnotations;

namespace ShopBridge.Core.Entity.Common
{

    /// <summary>
    /// Make the Base class abstract and generic so that the Base class do not have any existence
    /// It only inherited
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Base<T>
    {
        [Required(ErrorMessage ="Id is required.")]
        public T Id { get; set; }
        public bool IsActive { get; set; }
        public int IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}

namespace QwiloMVCStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cart")]
    public partial class Cart
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string CartNo { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(10)]
        public string ProductNumber { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(30)]
        public string ProductName { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "numeric")]
        public decimal Price { get; set; }

        public int? Quantity { get; set; }

        public virtual Customer Customer { get; set; }
    }
}

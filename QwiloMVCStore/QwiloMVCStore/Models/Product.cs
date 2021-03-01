namespace QwiloMVCStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(10)]
        public string ProductNumber { get; set; }

        [Required]
        [StringLength(30)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(300)]
        public string ProductDescription { get; set; }

        [Column(TypeName = "numeric")]
        public decimal UnitPrice { get; set; }

        public int MainCategoryID { get; set; }

        public int SubCategoryID { get; set; }

        public int? Featured { get; set; }

        public int? Rating { get; set; }
    }
}

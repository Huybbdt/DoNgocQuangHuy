namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public decimal? UnitCost { get; set; }

        public int? Quantity { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public int? Status { get; set; }

        public long? ProductType { get; set; }

        public virtual Category Category { get; set; }
    }
}

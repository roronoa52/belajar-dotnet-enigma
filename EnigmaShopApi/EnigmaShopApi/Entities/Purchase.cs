﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEntityFramework.Entities
{
    [Table(name: "t_purchase")]
    public class Purchase
    {
        [Key, Column(name: "id")]
        public Guid Id { get; set; }

        [Column(name: "trans_date")]
        public DateTime TransDate{ get; set; }

        [Column(name: "customer_id")]
        public Guid CustomerId{ get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
    }
}

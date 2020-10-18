using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerceTessa.Domain.Entities
{
    public class Movement : EntityBase
    {
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 999999.99)]
        public decimal Amount { get; set; }
        [DataType(DataType.DateTime)] public DateTime Date { get; set; }

        public string Description { get; set; }

        public long VoucherId { get; set; }

        //NAVIGATION PROPERTIES
        public virtual Voucher Voucher { get; set; }
    }
}

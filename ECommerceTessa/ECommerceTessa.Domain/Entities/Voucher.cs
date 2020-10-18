using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ECommerceTessa.Domain.Entities.Enums;

namespace ECommerceTessa.Domain.Entities
{
    public class Voucher : EntityBase
    {
        public int Number { get; set; }

        [DataType(DataType.DateTime)] public DateTime Date { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 999999.99)]
        public decimal SubTotal { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 999999.99)]
        public decimal Discount { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 999999.99)]
        public decimal Total { get; set; }

        public WayToPay WayToPay { get; set; }

        public long UserId { get; set; }

        public long ClientId { get; set; }

        //NAVIGATION PROPERTIES
        public virtual Client Client { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Movement> Movements { get; set; }
    }
}

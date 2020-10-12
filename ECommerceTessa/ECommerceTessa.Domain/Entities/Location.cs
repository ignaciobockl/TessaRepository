using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceTessa.Domain.Entities
{
    public class Location : EntityBase
    {
        protected string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                _description = string.Join(' ', value.Split(' ')
                    .Select(x => x[0].ToString().ToUpper() + x.Substring(1).ToLower())
                    .ToArray());
            }
        }

        public long ProvinceId { get; set; }


        //NAVIGATION PROPERTIES
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual Province Province { get; set; }
    }
}

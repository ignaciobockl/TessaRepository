using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ECommerceTessa.Domain.Entities
{
    public class Province : EntityBase
    {
        protected string _description;

        public string Description
        {
            get { return _description;}
            set
            {
                _description = string.Join(' ', value.Split(' ')
                    .Select(x => x[0].ToString().ToUpper() + x.Substring(1).ToLower())
                    .ToArray());
            }
        }

        //NAVIGATION PROPERTIES

        public virtual ICollection<Location> Locations { get; set; }
    }
}

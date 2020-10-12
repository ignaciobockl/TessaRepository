using System;
using System.Collections.Generic;
using System.Text;
using ECommerceTessa.Service.Interface.Base;

namespace ECommerceTessa.Service.Interface.User.DTOs
{
    public class UserDto : DtoBase
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsBlocked { get; set; }

        public bool Admin { get; set; }

        public long PersonId { get; set; }
    }
}

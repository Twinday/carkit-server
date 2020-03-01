using Carkit.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Services.DtoModels.Auth
{
    public class UserDto : BaseIdModel
    {
        public string Phone { get; set; }

        public string Name { get; set; }

        public int? RoleId { get; set; }

        public string Password { get; set; }
    }
}

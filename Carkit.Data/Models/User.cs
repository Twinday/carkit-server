using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Carkit.Data.Models
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public partial class User : BaseModel
    {
        /// <summary>
        /// Имя.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Телефон.
        /// </summary>
        [Required]
        public string Phone { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Идентификатор роли.
        /// </summary>
        [Required]
        public int RoleId { get; set; }

        /// <summary>
        /// Роль.
        /// </summary>
        public virtual Role Role { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carkit.Web
{
    /// <summary>
    /// Класс хранилище ключей на соответствующие текстовые строки сообщений из ресурсов.
    /// </summary>
    public class Messages
    {
        /// <summary>
        /// Объект с таким наименованием уже существует.
        /// </summary>
        public const string ObjectWithNameExists = "ObjectWithNameExists";
    }

    /// <summary>
    /// Фейковый класс для реализации доступа текстовым сообщений строкам из локализованных ресурсов.
    /// </summary>
    public class MessagesResource
    {
    }
}

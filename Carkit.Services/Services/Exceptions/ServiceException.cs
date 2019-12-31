using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Services.Services.Exceptions
{
    /// <summary>
    /// Исключение уровня Сервиса.
    /// 
    /// Данное исключение перехватывается и возвращается на фронт в виде сообщения
    /// с кодом возврата BadRequest.
    /// 
    /// Предназначено для генерации диагностических сообщений об ошибках уровня сервиса.
    /// </summary>
    public class ServiceException : Exception
    {
        public ServiceException() : base() { }
        public ServiceException(string message) : base(message) { }
        public ServiceException(string message, Exception innerException) : base(message, innerException) { }
        public ServiceException(Exception innerException) : base(innerException.Message, innerException) { }
    }
}

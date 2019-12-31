using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Carkit.Services.Helpers.Order
{
    public class OrderHelper<TEntity>
    {
        private readonly IMapper _mapper;

        public OrderHelper(IMapper mapper)
        {
            this._mapper = mapper;
        }
        /// <summary>
        /// Преобразует информацию о сортировке <see cref="OrderInfo"/> в дерево выражений.
        /// </summary>
        /// <typeparam name="TDtoEntity">Тип Dto-модели</typeparam>
        /// <param name="orderInfo"></param>
        /// <returns>Выражение для сортировки.</returns>
        public Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> GetOrderExpression<TDtoEntity>(IEnumerable<OrderInfo> orderInfo)
        {
            if (orderInfo == null || orderInfo.Count() == 0)
            {
                return null;
            }

            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> query = (IQueryable<TEntity> entities) =>
            {
                // хак для того, чтобы далее итеративно использовать IOrderedQueryable, а не IQueryable+IOrderedQueryable.
                IOrderedQueryable<TEntity> orderBy = entities.OrderBy(v => 0);
                orderBy = ApplyMultipleSort<TDtoEntity>(orderBy, orderInfo);
                return orderBy;
            };

            return query;
        }

        /// <summary>
        /// Применение сортировки.
        /// </summary>
        /// <typeparam name="TDtoEntity">Тип Dto-модели</typeparam>
        /// <param name="orderQuery">Коллекция для сортировки.</param>
        /// <param name="orderInfo">Информация о сортировке.</param>
        /// <returns>Коллекция с примененной сортировкой.</returns>
        protected IOrderedQueryable<TEntity> ApplyMultipleSort<TDtoEntity>(IOrderedQueryable<TEntity> orderQuery, IEnumerable<OrderInfo> orderInfo)
        {
            var map = _mapper.ConfigurationProvider.FindTypeMapFor<TEntity, TDtoEntity>()
                ?? _mapper.ConfigurationProvider.FindTypeMapFor<TDtoEntity, TEntity>();

            foreach (OrderInfo item in orderInfo)
            {
                PropertyMap propertyMap = map.PropertyMaps.FirstOrDefault(
                       pm => pm.DestinationName.Equals(item.FieldName, StringComparison.OrdinalIgnoreCase));

                // Если в маппинге указано выражение, то используем его, иначе конструируем на основе имени свойства.
                if (propertyMap == null)
                    continue;

                LambdaExpression orderExpression = propertyMap.CustomMapExpression ?? GetPropertyExpression(item.FieldName);

                // Проверяем тип, чтобы правильно покастить LambdaExpression в выражение.
                if (orderExpression.ReturnType == typeof(string))
                    orderQuery = ApplyMultipleSort<string>(orderQuery, item, orderExpression);
                else if (orderExpression.ReturnType == typeof(int))
                    orderQuery = ApplyMultipleSort<int>(orderQuery, item, orderExpression);
                else if (orderExpression.ReturnType == typeof(long))
                    orderQuery = ApplyMultipleSort<long>(orderQuery, item, orderExpression);
                else if (orderExpression.ReturnType == typeof(DateTime))
                    orderQuery = ApplyMultipleSort<DateTime>(orderQuery, item, orderExpression);
                else if (orderExpression.ReturnType == typeof(bool))
                    orderQuery = ApplyMultipleSort<bool>(orderQuery, item, orderExpression);
                else if (orderExpression.ReturnType.BaseType == typeof(Enum))
                    continue;
                else if (orderExpression.ReturnType == typeof(decimal))
                    orderQuery = ApplyMultipleSort<decimal>(orderQuery, item, orderExpression);
                else orderQuery = ApplyMultipleSort<object>(orderQuery, item, orderExpression);
            }

            return orderQuery;
        }

        /// <summary>
        /// Конструирует выражение на основе имени свойства.
        /// </summary>
        /// <param name="fieldName">Имя свойства.</param>
        /// <returns>Выражение для доступа к свойству.</returns>
        protected LambdaExpression GetPropertyExpression(string fieldName)
        {
            var parameter = Expression.Parameter(typeof(TEntity));

            // На всякий случай проверяем, что у нас единичное свойство, а не свойство дочернего объекта.
            if (!fieldName.Contains("."))
            {
                return Expression.Lambda(Expression.PropertyOrField(parameter, fieldName), parameter);
            }

            // Для доступа к свойствам дочернего объекта конструируем выражение итеративно.
            Expression current = parameter;
            foreach (var part in fieldName.Split('.'))
            {
                var selector = Expression.PropertyOrField(current, part);
                current = selector;
            }

            return Expression.Lambda(current, parameter);
        }

        /// <summary>
        /// Применяет сортировку к колекции.
        /// </summary>
        /// <typeparam name="TProperty">Тип результата выражения, которое используется в сортировке.</typeparam>
        /// <param name="orderQuery">Исходная коллекция.</param>
        /// <param name="item">Информация о сортировке</param>
        /// <param name="orderExpression">Выражение для применения сортировки.</param>
        /// <returns>Коллекция с примененной сортировкой.</returns>
        protected IOrderedQueryable<TEntity> ApplyMultipleSort<TProperty>(IOrderedQueryable<TEntity> orderQuery, OrderInfo item, LambdaExpression orderExpression)
        {
            var funcExpression = (Expression<Func<TEntity, TProperty>>)orderExpression;

            if (item.SortOrder == SortOrder.Asc)
                orderQuery = orderQuery.ThenBy(funcExpression);
            else
                orderQuery = orderQuery.ThenByDescending(funcExpression);
            return orderQuery;
        }
    }
}

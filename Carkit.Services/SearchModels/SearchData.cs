using Carkit.Services.Helpers.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Services.SearchModels
{
	/// <summary>
	/// Параметры запроса списка сущностей.
	/// </summary>
	public class SearchData
	{
		/// <summary>
		/// Текст для поиска
		/// </summary>
		public string SearchText { get; set; }

		/// <summary>
		/// Номер страницы.
		/// </summary>
		public int PageNumber { get; set; }

		/// <summary>
		/// Размер страницы.
		/// </summary>
		public int PageSize { get; set; }

		/// <summary>
		/// Если true, то в результате необходимо вернуть общее число записей.
		/// </summary>
		public bool GetTotalCount { get; set; }

		/// <summary>
		/// Сортировка.
		/// </summary>
		public List<OrderInfo> Order { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Services.Helpers.Order
{
	/// <summary>
	/// Направление сортировки.
	/// </summary>
	public enum SortOrder
	{
		Asc,
		Desc
	}

	/// <summary>
	/// Модель для хранения информации о сортировке.
	/// </summary>
	public class OrderInfo
	{
		/// <summary>
		/// Поле сортировки.
		/// </summary>
		public string FieldName { get; set; }

		/// <summary>
		/// Направление сортировки.
		/// </summary>
		public SortOrder SortOrder { get; set; }
	}
}

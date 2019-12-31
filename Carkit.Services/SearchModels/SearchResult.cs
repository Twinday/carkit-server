using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Services.SearchModels
{
	public class SearchResult<TEntity>
	{
		public int TotalCount { get; set; }
		public List<TEntity> Items { get; set; }
	}
}

using GenericRepository.Enums;
using System;
using System.Linq.Expressions;

namespace GenericRepository.Options
{
    public class DataModelOptions<TEntity>
    {
        public Expression<Func<TEntity, bool>> EntitySearchClause { get; set; } = null;

        public string SortingFieldName { get; set; } = null;

        public SortingOrder SortingOrder { get; set; }
    }
}

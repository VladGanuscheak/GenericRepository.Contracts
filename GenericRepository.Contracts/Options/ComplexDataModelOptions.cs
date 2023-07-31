using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace GenericRepository.Options
{
    public class ComplexDataModelOptions<TEntity, TDestination> : DataModelOptions<TEntity>
    {
        [Required]
        public Expression<Func<TEntity, TDestination>> Projection { get; set; }

        public Expression<Func<TDestination, bool>> ProjectionSearchClause { get; set; } = null;
    }
}

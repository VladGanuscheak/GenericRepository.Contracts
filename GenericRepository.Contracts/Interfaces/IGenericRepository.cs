using GenericRepository.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace GenericRepository.Interfaces
{
    public interface IGenericRepository<TEntity>
    {
        /// <summary>
        ///     Lists all the entities which match all the applied filters.
        /// </summary>
        /// <exception cref="NullReferenceException">Throws System.NullReferenceException, if the options are not provided.</exception>
        /// <param name="options">Required. Search and Sorting options.</param>
        /// <returns>Entities which correspond to selected criterias.</returns>
        IEnumerable<TEntity> List([Required] DataModelOptions<TEntity> options);

        /// <summary>
        ///     Lists all the models which match all the applied filters.
        /// </summary>
        /// <exception cref="NullReferenceException">Throws System.NullReferenceException, if the options are not provided.</exception>
        /// <typeparam name="TDestination">The type of the final projection.</typeparam>
        /// <param name="options">Required. Search, sorting and projection options.</param>
        /// <returns>Models which correspond to selected criterias.</returns>
        IEnumerable<TDestination> List<TDestination>([Required] ComplexDataModelOptions<TEntity, TDestination> options);

        /// <summary>
        ///     Gets the entity which corresponds to selected conditions.
        /// </summary>
        /// <exception cref="NullReferenceException">Throws System.NullReferenceException, if the options are not provided.</exception>
        /// <param name="options">Required. Search and Sorting options.</param>
        /// <returns>The entity which corresponds to selected conditions.</returns>
        TEntity Get([Required] DataModelOptions<TEntity> options);

        /// <summary>
        ///     Gets the model which corresponds to selected conditions.
        /// </summary>
        /// <exception cref="NullReferenceException">Throws System.NullReferenceException, if the options are not provided.</exception>
        /// <typeparam name="TDestination">The type of the final projection.</typeparam>
        /// <param name="options">Required. Search, sorting and projection options.</param>
        /// <returns></returns>
        TDestination Get<TDestination>([Required] ComplexDataModelOptions<TEntity, TDestination> options);

        /// <summary>
        ///     Creates the entity.
        /// </summary>
        /// <exception cref="NullReferenceException">Throws System.NullReferenceException, if the entity has not been provided.</exception>
        /// <param name="entity">The entity.</param>
        void Create([Required] TEntity entity);

        /// <summary>
        ///     Updates the entity.
        /// </summary>
        /// <exception cref="NullReferenceException">Throws System.NullReferenceException, if the entity or filter has not been provided.</exception>
        /// <param name="entity">The entity.</param>
        /// <param name="searchClause">The filter option.</param>
        void Update([Required] Expression<Func<TEntity, bool>> searchClause, 
            [Required] TEntity entity);

        /// <summary>
        ///     Deletes the entity (hard delete).
        /// </summary>
        /// <exception cref="NullReferenceException">Throws System.NullReferenceException, if the filter has not been provided.</exception>
        /// <param name="searchClause">The filter option.</param>
        void Delete([Required] Expression<Func<TEntity, bool>> searchClause);
    }
}

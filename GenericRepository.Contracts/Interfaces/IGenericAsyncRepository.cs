using GenericRepository.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace GenericRepository.Interfaces
{
    public interface IGenericAsyncRepository<TEntity>
    {
        /// <summary>
        ///     Lists all the entities which match all the applied filters.
        /// </summary>
        /// <exception cref="NullReferenceException">Throws System.NullReferenceException, if the options are not provided.</exception>
        /// <param name="options">Required. Search and Sorting options.</param>
        /// <param name="cancellationToken">Optional. TPL Cancellation.</param>
        /// <returns>Entities which correspond to selected criterias.</returns>
        Task<IEnumerable<TEntity>> ListAsync([Required] DataModelOptions<TEntity> options, 
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Lists all the models which match all the applied filters.
        /// </summary>
        /// <typeparam name="TDestination">The type of the final projection.</typeparam>
        /// <exception cref="NullReferenceException">Throws System.NullReferenceException, if the options are not provided.</exception>
        /// <param name="options">Required. Search, sorting and projection options.</param>
        /// <param name="cancellationToken">Optional. TPL Cancellation.</param>
        /// <returns>Models which correspond to selected criterias.</returns>
        Task<IEnumerable<TDestination>> ListAsync<TDestination>([Required] ComplexDataModelOptions<TEntity, TDestination> options,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Gets the entity which corresponds to selected conditions.
        /// </summary>
        /// <exception cref="NullReferenceException">Throws System.NullReferenceException, if the options are not provided.</exception>
        /// <param name="options">Required. Search and Sorting options.</param>
        /// <param name="cancellationToken">Optional. TPL Cancellation.</param>
        /// <returns>The entity which corresponds to selected conditions.</returns>
        Task<TEntity> GetAsync([Required] DataModelOptions<TEntity> options,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Gets the model which corresponds to selected conditions.
        /// </summary>
        /// <typeparam name="TDestination">The type of the final projection.</typeparam>
        /// <exception cref="NullReferenceException">Throws System.NullReferenceException, if the options are not provided.</exception>
        /// <param name="options">Required. Search, sorting and projection options.</param>
        /// <param name="cancellationToken">Optional. TPL Cancellation.</param>
        /// <returns></returns>
        Task<TDestination> GetAsync<TDestination>([Required] ComplexDataModelOptions<TEntity, TDestination> options,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Creates the entity.
        /// </summary>
        /// <exception cref="NullReferenceException">Throws System.NullReferenceException, if the entity has not been provided.</exception>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">Optional. TPL Cancellation.</param>
        Task CreateAsync([Required] TEntity entity, 
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Updates the entity.
        /// </summary>
        /// <exception cref="NullReferenceException">Throws System.NullReferenceException, if the entity or filter has not been provided.</exception>
        /// <param name="searchClause">The filter option.</param>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">Optional. TPL Cancellation.</param>
        Task UpdateAsync([Required] Expression<Func<TEntity, bool>> searchClause, 
            [Required] TEntity entity, 
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Deletes the entity (hard delete).
        /// </summary>
        /// <exception cref="NullReferenceException">Throws System.NullReferenceException, if the filter has not been provided.</exception>
        /// <param name="searchClause">The filter option.</param>
        /// <param name="cancellationToken">Optional. TPL Cancellation.</param>
        Task DeleteAsync([Required] Expression<Func<TEntity, bool>> searchClause,
            CancellationToken cancellationToken = default);
    }
}

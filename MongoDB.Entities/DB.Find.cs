﻿using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;

namespace MongoDB.Entities
{
    public static partial class DB
    {
        internal static Task<IAsyncCursor<TProjection>> FindAsync<T, TProjection>(FilterDefinition<T> filter, FindOptions<T, TProjection> options, IClientSessionHandle session = null, CancellationToken cancellation = default) where T : IEntity
        {
            return session == null ?
                        Collection<T>().FindAsync(filter, options, cancellation) :
                        Collection<T>().FindAsync(session, filter, options, cancellation);
        }

        /// <summary>
        /// Represents a MongoDB Find command
        /// <para>TIP: Specify your criteria using .Match() .Sort() .Skip() .Take() .Project() .Option() methods and finally call .Execute()</para>
        /// </summary>
        /// <typeparam name="T">Any class that implements IEntity</typeparam>
        public static Find<T> Find<T>() where T : IEntity
        {
            return new Find<T>();
        }

        /// <summary>
        /// Represents a MongoDB Find command
        /// <para>TIP: Specify your criteria using .Match() .Sort() .Skip() .Take() .Project() .Option() methods and finally call .Execute()</para>
        /// </summary>
        /// <typeparam name="T">Any class that implements IEntity</typeparam>
        /// <typeparam name="TProjection">The type that is returned by projection</typeparam>
        public static Find<T, TProjection> Find<T, TProjection>() where T : IEntity
        {
            return new Find<T, TProjection>();
        }
    }
}

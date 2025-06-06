namespace RuculaX.Database.Query
{
    /// <summary>
    /// Options of Pagination
    /// </summary>
    public enum OptionPagination
    {
        /// <summary>
        /// First Page
        /// </summary>
        First,
        /// <summary>
        /// Previous Page
        /// </summary>
        Previous,
         /// <summary>
        /// Next Page
        /// </summary>
        Next, 
        /// <summary>
        /// Last Page
        /// </summary>
        Last,
        /// <summary>
        /// Contains text
        /// </summary>
        Contain 
    }
    
    /// <summary>
    /// Provides methods for implements logic for optios of Page
    /// </summary>    
    public abstract class PaginationAsync<T>
    {
        /// <summary>
        /// Creates the query that represents the first page based on the IQueryConfigurationInput
        /// </summary>
        /// <param name="config">IQueryConfigurationInput</param>
        /// <returns>QueryConfigurationOutput</returns>
        protected abstract Task<QueryConfigurationOutput<T>> FirstAsync(IQueryConfigurationInput config);
        /// <summary>
        /// Creates the query that represents the last page based on the IQueryConfigurationInput
        /// </summary>
        /// <param name="config">IQueryConfigurationInput</param>
        /// <returns>QueryConfigurationOutput<T></returns>
        protected abstract Task<QueryConfigurationOutput<T>> LastAsync(IQueryConfigurationInput config);
        /// <summary>
        /// Creates the query that represents the next page based on the IQueryConfigurationInput.
        /// </summary>
        /// <param name="config">IQueryConfigurationInput</param>
        /// <returns>QueryConfigurationOutput<T></returns>
        protected abstract Task<QueryConfigurationOutput<T>> NextAsync(IQueryConfigurationInput config);
        /// <summary>
        /// Creates the query that represents the previous page based on the IQueryConfigurationInput.
        /// </summary>
        /// <param name="config">IQueryConfigurationInput</param>
        /// <returns>QueryConfigurationOutput<T></returns>
        protected abstract Task<QueryConfigurationOutput<T>> PreviousAsync(IQueryConfigurationInput config);

        /// <summary>
        /// Creates the query that represents the contain page based on the IQueryConfigurationInput.
        /// </summary>
        /// <param name="config">IQueryConfigurationInput</param>
        /// <returns>QueryConfigurationOutput<T></returns>

        protected abstract Task<QueryConfigurationOutput<T>> ContainAsync(IQueryConfigurationInput config);

        /// <summary>
        /// Calls the pagination query. option indicates which method will be used
        /// </summary>
        /// <param name="option">byte</param>
        /// <param name="config">IQueryConfigurationInput</param>
        /// <returns>QueryConfigurationOutput</returns>
        public async Task<QueryConfigurationOutput> QueryAsync(byte option, IQueryConfigurationInput config)
        {
            if (option == (byte)OptionPagination.First) return await FirstAsync(config);
            if (option == (byte)OptionPagination.Next) return await NextAsync(config);
            if (option == (byte)OptionPagination.Previous) return await PreviousAsync(config);
            if (option == (byte)OptionPagination.Last) return await LastAsync(config);
            if (option == (byte)OptionPagination.Contain) return await ContainAsync(config);

            throw new PaginationException(PaginationException.OptionPagination);
        }

    }
}
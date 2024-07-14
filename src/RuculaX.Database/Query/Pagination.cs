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
        Last  
    }
    /// <summary>
    /// Provides methods for implements logic for optios of Page
    /// </summary>    
    public abstract class PaginationAsync
    {
        protected abstract Task<IQueryConfigurationOutput> FirstAsync(IQueryConfigurationInput config);
        protected abstract Task<IQueryConfigurationOutput> LastAsync(IQueryConfigurationInput config);
        protected abstract Task<IQueryConfigurationOutput> NextAsync(IQueryConfigurationInput config);
        protected abstract Task<IQueryConfigurationOutput> PreviousAsync(IQueryConfigurationInput config);

        public async Task<IQueryConfigurationOutput> QueryAsync(byte option, IQueryConfigurationInput config)
        {
            if(option == (byte)OptionPagination.First) return await FirstAsync(config);
            if(option == (byte)OptionPagination.Next) return  await NextAsync(config);
            if(option == (byte)OptionPagination.Previous) return await PreviousAsync(config);
            if(option == (byte)OptionPagination.Last) return await LastAsync(config);

            throw new PaginationException(PaginationException.OptionPagination);
        }

    }
}
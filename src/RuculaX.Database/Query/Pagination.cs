namespace RuculaX.Database.Query
{
    public enum OptionPagination
    {
        First,
        Previous,
        Next, 
        Last  
    }
    
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
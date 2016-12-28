namespace BusHostel.Repository.DataAccess
{
    public interface IListSetting
    {
        /// <summary>
        /// Get/Set Index for the Soring Column
        /// </summary>
        int SortColumnIndex { get; set; }

        /// <summary>
        /// Get/Set the SortDirection for the Current Column
        /// </summary>
        int SortDirection { get; set; }

        /// <summary>
        /// Get/Set Current page number
        /// </summary>
        int CurrentPageNumber { get; set; }

        /// <summary>
        /// Get/Set Records to be displayed per page
        /// </summary>
        ushort RecordsPerPage { get; set; }

        /// <summary>
        /// Get/Set Total Number of Records Count
        /// </summary>
        int NumberOfRecords { get; set; }
       
        int NumberOfPages { get; }       
    }

    namespace Generic
    {
        public interface IListSetting<T> : IListSetting
        {
            T Entity { get; set; }
        }
    }
}

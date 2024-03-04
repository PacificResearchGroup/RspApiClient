namespace PRG.Clients.RSP.Requests
{
    internal class GetUsersRequest
    {
        public int SearchCount { get; set; } = 0;
        public string Filter { get; set; }
        public string FilterType { get; set; } = "Shop";
        public List<string> FilterValues { get; set; } = [];
        public string StatusFilter { get; set; } = "totalUsers";
        public int Page { get; set; } = 1;
        public int RowsPerPage { get; set; } = 8;
        public string SortDir { get; set; } = "DESC";
        public string SortBy { get; set; } = "lastUpdated";

        public GetUsersRequest(int page, int limit, string filter)
        {
            Filter = filter;
            Page = page;
            RowsPerPage = limit;
        }
    }


}

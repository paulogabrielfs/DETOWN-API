namespace DETOWN.Application.EventSourcedNormalizers
{
    public class NewsHistoryData
    {
        public string Action { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public string When { get; set; }
        public string Who { get; set; }
    }
}
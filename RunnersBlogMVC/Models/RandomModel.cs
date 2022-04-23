namespace RunnersBlogMVC.Models
{
    public class RandomModel
    {
        public FactData[]? Property1 { get; set; }
    }

    public class FactData
    {
        public Status? status { get; set; }
        public string? _id { get; set; }
        public string? user { get; set; }
        public string? text { get; set; }
        public int? dumbass { get; set; }
        public string? source { get; set; }
        public DateTime? updatedAt { get; set; }
        public string? type { get; set; }
        public DateTime? createdAt { get; set; }
        public bool? deleted { get; set; }
        public bool? used { get; set; }
    }

    public class Status
    {
        public bool? verified { get; set; }
        public int? sentCount { get; set; }
    }

}

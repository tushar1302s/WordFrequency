namespace WordFrequency.services;

public class WordFrequencyRequest
{
    public string Text { get; set; } = string.Empty;
    public int TopN { get; set; }
}

public class WordFrequency
{
    public string Word { get; set; } = string.Empty;
    public int Count { get; set; }
}

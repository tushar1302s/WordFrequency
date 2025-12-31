namespace WordFrequency.services;

public class WordFrequencyResponse
{
    public List<WordFrequency> WordFrequencies { get; set; } = new();
    public int TotalWords { get; set; }
}

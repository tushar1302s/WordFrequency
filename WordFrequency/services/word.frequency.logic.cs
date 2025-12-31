using System.Text.RegularExpressions;

namespace WordFrequency.services;

public class WordFrequencyLogic
{
    public (List<WordFrequency> Frequencies, int TotalWords) Calculate(
        string text,
        int topN
    )
    {
        var words = Regex.Matches(
                text?.ToLower() ?? "",
                @"[a-z0-9]+"
            )
            .Select(m => m.Value)
            .ToList();

        var totalWords = words.Count;

        var frequencies = words
            .GroupBy(w => w)
            .Select(g => new WordFrequency
            {
                Word = g.Key,
                Count = g.Count()
            })
            .OrderByDescending(w => w.Count)
            .ThenBy(w => w.Word)
            .Take(topN)
            .ToList();

        return (frequencies, totalWords);
    }
}

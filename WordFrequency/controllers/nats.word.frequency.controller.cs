using CLOOPS.NATS.Attributes;
using CLOOPS.NATS.Meta;
using NATS.Client.Core;
using WordFrequency.services;

namespace WordFrequency.controllers;

public class WordFrequencyController
{
    private readonly WordFrequencyLogic _logic;

    public WordFrequencyController(WordFrequencyLogic logic)
    {
        _logic = logic;
    }

    // 👇 THIS IS THE SUBJECT NATS WILL LISTEN TO
    [NatsConsumer(_subject: "word.frequency")]
    public Task<NatsAck> GetWordFrequency(
        NatsMsg<WordFrequencyRequest> msg,
        CancellationToken ct = default
    )
    {
        var request = msg.Data;

        if (request == null || request.TopN <= 0)
        {
            return Task.FromResult(
                new NatsAck(
                    _isAck: true,
                    _reply: new { error = "Invalid request" }
                )
            );
        }

        var result = _logic.Calculate(request.Text, request.TopN);

        var response = new WordFrequencyResponse
        {
            WordFrequencies = result.Frequencies,
            TotalWords = result.TotalWords
        };

        return Task.FromResult(
            new NatsAck(
                _isAck: true,
                _reply: response
            )
        );
    }

}
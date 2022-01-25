namespace MRT.Application.Models;
using System;
using System.Xml.Serialization;

public record class Scenario
{
    public int? ScenarioID { get; init; }
    public string? ScenarioName { get; init; }
    public string? Surname { get; init; }
    public string? Forename { get; init; }
    public Guid? UserID { get; init; }
    public DateTime? SampleDate { get; init; }
    public DateTime? CreationDate { get; init; }
    public int? NumMonths { get; init; }
    public int? MarketID { get; init; }
    public int? NetworkLayerID { get; init; }
}

using PimpMyRideContratcs.Exceptions;
using PimpMyRideContratcs.Extensions;
using PimpMyRideContratcs.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PimpMyRideContratcs.DataModels;

public class WorkDataModel
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int Duration { get; private set; }
    public string ComplexityLevel { get; private set; }

    public WorkDataModel(int id, string title, int duration, string complexityLevel)
    {
        Id = id;
        Title = title;
        Duration = duration;
        ComplexityLevel = complexityLevel;
        Description = string.Empty;
    }

    public void Validate()
    {
        if (Id <= 0)
            throw new ValidationException("Invalid work ID");

        if (string.IsNullOrWhiteSpace(Title) || Title.Length > 50)
            throw new ValidationException("Work title must be between 1-50 characters");

        if (Duration <= 0)
            throw new ValidationException("Duration must be positive");

        if (string.IsNullOrWhiteSpace(ComplexityLevel) || ComplexityLevel.Length > 20)
            throw new ValidationException("Complexity level must be between 1-20 characters");
    }
}

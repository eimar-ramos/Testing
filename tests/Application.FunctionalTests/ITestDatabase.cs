using System.Data.Common;

namespace TrucksInspections_ASP.NETCore_Angular_CleanArchitecture.Application.FunctionalTests;

public interface ITestDatabase
{
    Task InitialiseAsync();

    DbConnection GetConnection();

    Task ResetAsync();

    Task DisposeAsync();
}

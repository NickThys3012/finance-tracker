using System.Reflection;

namespace FinanceTracker.DataAccess;

/// <summary>
///     Provides an assembly marker and helper for the FinanceTracker.DataAccess project.
/// </summary>
/// <remarks>
///     This type can be used for:
///     - Locating the <see cref="Assembly" /> that contains data access components.
///     - Assembly scanning or registration in dependency injection configuration.
/// </remarks>
internal static class Class1
{
    /// <summary>
    ///     Gets the <see cref="Assembly" /> that contains the data access types.
    /// </summary>
    internal static Assembly Assembly => typeof(Class1).Assembly;
}
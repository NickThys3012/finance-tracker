using FinanceTracker.Contracts.Interfaces.Repositories.CsvProfileSub;
using FinanceTracker.DataAccess.Repositories.Base;
using FinanceTracker.Domain.CsvProfileSub;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.DataAccess.Repositories.CsvProfileSub;

public class ColumnMappingDefinitionRepository : Repository<ColumnMappingDefinition>, IColumnMappingDefinitionRepository
{
    public ColumnMappingDefinitionRepository(DbContext context) : base(context)
    {
    }
}
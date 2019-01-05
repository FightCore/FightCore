using System.Linq;

using FightCore.Api.Helpers;

using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FightCore.Api.OperationFilters
{
    /// <inheritdoc />
    public class ApiVersionOperationFilter : IOperationFilter
    {
        /// <inheritdoc />
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var actionApiVersionModel = context.ApiDescription.ActionDescriptor?.GetApiVersion();
            if (actionApiVersionModel == null)
            {
                return;
            }

            if (actionApiVersionModel.DeclaredApiVersions.Any())
            {
                operation.Produces = operation.Produces
                    .SelectMany(p => actionApiVersionModel.DeclaredApiVersions
                        .Select(version => $"{p};v={version.ToString()}")).ToList();
            }
            else
            {
                operation.Produces = operation.Produces
                    .SelectMany(p => actionApiVersionModel.ImplementedApiVersions.OrderByDescending(v => v)
                        .Select(version => $"{p};v={version.ToString()}")).ToList();
            }
        }
    }
}

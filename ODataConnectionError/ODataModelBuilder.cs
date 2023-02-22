using Microsoft.OData.ModelBuilder;
using Microsoft.OData.Edm;
using ODataConnectionError.Models.Domain;

namespace ODataConnectionError;

public class ODataModelBuilder
{
    public static IEdmModel GetEdmModel()
    {
        var builder = new ODataConventionModelBuilder();

        builder.EntitySet<Timeline>("Timelines");

        return builder.GetEdmModel();
    }
}
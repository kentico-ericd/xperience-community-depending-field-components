using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace XperienceCommunity.DependingFieldComponents.FormComponents.NumberInputDependsOnFieldComponent;

public class NumberInputDependsOnFieldAttribute : FormComponentAttribute, IDependsOnPropertyProperties
{
    public string? DependsOn { get; set; }


    public string? ExpectedValue { get; set; }
}

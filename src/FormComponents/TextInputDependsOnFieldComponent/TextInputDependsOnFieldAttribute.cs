using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace XperienceCommunity.DependingFieldComponents.FormComponents.TextInputDependsOnFieldComponent;

public class TextInputDependsOnFieldAttribute : FormComponentAttribute, IDependsOnPropertyProperties
{
    public string? DependsOn { get; set; }


    public string? ExpectedValue { get; set; }
}

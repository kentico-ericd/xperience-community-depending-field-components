using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace XperienceCommunity.DependingFieldComponents.FormComponents.CheckboxInputDependsOnFieldComponent;

public class CheckboxInputDependsOnFieldAttribute : FormComponentAttribute, IDependsOnPropertyProperties
{
    public string? DependsOn { get; set; }


    public string? ExpectedValue { get; set; }
}

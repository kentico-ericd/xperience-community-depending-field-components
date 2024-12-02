using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace XperienceCommunity.DependingFieldComponents.FormComponents.RadioGroupInputDependsOnFieldComponent;

public class RadioGroupInputDependsOnFieldAttribute : FormComponentAttribute, IDependsOnPropertyProperties
{
    public string? DependsOn { get; set; }


    public string? ExpectedValue { get; set; }
}

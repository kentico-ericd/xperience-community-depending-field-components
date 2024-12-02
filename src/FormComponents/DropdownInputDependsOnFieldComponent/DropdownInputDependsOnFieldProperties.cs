using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace XperienceCommunity.DependingFieldComponents.FormComponents.DropdownInputDependsOnFieldComponent;

/// <summary>
/// Properties for the <see cref="DropdownInputDependsOnFieldComponent"/> component.
/// </summary>
public class DropdownInputDependsOnFieldProperties : DependsOnPropertyProperties
{
    public IEnumerable<DropDownOptionItem>? OptionsItems { get; set; }


    [TextAreaComponent(Label = "{$base.forms.dropdown.options.label$}", ExplanationText = "{$base.forms.dropdown.options.explanation$}")]
    public string? Options { get; set; }


    [TextInputComponent(Label = "{$base.forms.dropdown.placeholder.label$}", Tooltip = "{$base.forms.dropdown.placeholder.tooltip$}")]
    public string? Placeholder { get; set; }
}

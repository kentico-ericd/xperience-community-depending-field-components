using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Base.Forms;

namespace XperienceCommunity.DependingFieldComponents.FormComponents.RadioGroupInputDependsOnFieldComponent;

/// <summary>
/// Properties for the <see cref="RadioGroupInputDependsOnFieldComponent"/> component.
/// </summary>
public class RadioGroupInputDependsOnFieldProperties : DependsOnPropertyProperties
{
    [TextAreaComponent(Label = "{$base.forms.radiogroup.options.label$}", ExplanationText = "{$base.forms.radiogroup.options.explanation$}")]
    public string? Options { get; set; }


    [CheckBoxComponent(Label = "{$base.forms.radiogroup.inline.label$}", Tooltip = "{$base.forms.radiogroup.inline.tooltip$}")]
    public bool Inline { get; set; }


    public string? AriaLabel { get; set; }
}

using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Base.Forms;

namespace XperienceCommunity.DependingFieldComponents.FormComponents.NumberInputDependsOnFieldComponent;

/// <summary>
/// Properties for the <see cref="NumberInputDependsOnFieldComponent"/> component.
/// </summary>
public class NumberInputDependsOnFieldProperties : DependsOnPropertyProperties
{
    [TextInputComponent(Label = "{$base.forms.numberinput.watermark.label$}", Tooltip = "{$base.forms.numberinput.watermark.tooltip$}")]
    public string? WatermarkText { get; set; }
}

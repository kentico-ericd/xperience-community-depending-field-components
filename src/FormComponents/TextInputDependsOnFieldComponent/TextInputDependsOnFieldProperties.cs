using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace XperienceCommunity.DependingFieldComponents.FormComponents.TextInputDependsOnFieldComponent;

/// <summary>
/// Properties for the <see cref="TextInputDependsOnFieldComponent"/> component.
/// </summary>
public class TextInputDependsOnFieldProperties : DependsOnPropertyProperties
{
    [TextInputComponent(Label = "{$base.forms.textinput.watermark.label$}", Tooltip = "{$base.forms.textinput.watermark.tooltip$}")]
    public string? WatermarkText { get; set; }
}

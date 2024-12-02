using CMS.Core;

using Kentico.Xperience.Admin.Base.Forms;

using XperienceCommunity.DependingFieldComponents;
using XperienceCommunity.DependingFieldComponents.FormComponents.TextInputDependsOnFieldComponent;
using XperienceCommunity.DependingFieldComponents.VisibilityConditions;

[assembly: RegisterFormComponent(
    DependingFieldComponentsConstants.TEXTINPUT_IDENTIFIER,
    typeof(TextInputDependsOnFieldComponent),
    DependingFieldComponentsConstants.TEXTINPUT_FIELDDESCRIPTION)]

namespace XperienceCommunity.DependingFieldComponents.FormComponents.TextInputDependsOnFieldComponent;

/// <summary>
/// A form component which can be configured to appear based on the value of another field.
/// </summary>
[ComponentAttribute(typeof(TextInputDependsOnFieldAttribute))]
public class TextInputDependsOnFieldComponent(ILocalizationService localizationService) :
    FormComponent<TextInputDependsOnFieldProperties, TextInputClientProperties, string>
{
    public override string ClientComponentName => "@kentico/xperience-admin-base/TextInput";


    protected override void ConfigureComponent()
    {
        DependingFieldVisibilityCondition.Configure(this);

        base.ConfigureComponent();
    }


    protected override Task ConfigureClientProperties(TextInputClientProperties clientProperties)
    {
        clientProperties.WatermarkText = localizationService.LocalizeString(Properties.WatermarkText);

        return base.ConfigureClientProperties(clientProperties);
    }
}

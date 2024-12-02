using CMS.Core;

using Kentico.Xperience.Admin.Base.Forms;

using XperienceCommunity.DependingFieldComponents;
using XperienceCommunity.DependingFieldComponents.FormComponents.NumberInputDependsOnFieldComponent;
using XperienceCommunity.DependingFieldComponents.VisibilityConditions;

[assembly: RegisterFormComponent(DependingFieldComponentsConstants.NUMBERINPUT_IDENTIFIER,
    typeof(NumberInputDependsOnFieldComponent),
    DependingFieldComponentsConstants.NUMBERINPUT_FIELDDESCRIPTION)]
namespace XperienceCommunity.DependingFieldComponents.FormComponents.NumberInputDependsOnFieldComponent;

/// <summary>
/// A form component which can be configured to appear based on the value of another field.
/// </summary>
[ComponentAttribute(typeof(NumberInputDependsOnFieldAttribute))]
public class NumberInputDependsOnFieldComponent(ILocalizationService localizationService) :
    FormComponent<NumberInputDependsOnFieldProperties, NumberInputClientProperties, int?>
{
    public override string ClientComponentName => "@kentico/xperience-admin-base/NumberInput";


    protected override void ConfigureComponent()
    {
        var maxRule = new MaximumIntegerValueValidationRule(localizationService)
        {
            Properties = { MaxValue = int.MaxValue },
        };
        var minRule = new MinimumIntegerValueValidationRule(localizationService)
        {
            Properties = { MinValue = int.MinValue },
        };

        AddValidationRule(maxRule);
        AddValidationRule(minRule);
        DependingFieldVisibilityCondition.Configure(this);

        base.ConfigureComponent();
    }


    protected override Task ConfigureClientProperties(NumberInputClientProperties clientProperties)
    {
        clientProperties.WatermarkText = localizationService.LocalizeString(Properties.WatermarkText);

        return base.ConfigureClientProperties(clientProperties);
    }
}

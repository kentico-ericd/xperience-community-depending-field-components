using CMS.Core;

using Kentico.Xperience.Admin.Base.Forms;

using XperienceCommunity.DependingFieldComponents;
using XperienceCommunity.DependingFieldComponents.FormComponents.RadioGroupInputDependsOnFieldComponent;
using XperienceCommunity.DependingFieldComponents.VisibilityConditions;

[assembly: RegisterFormComponent(DependingFieldComponentsConstants.RADIOGROUP_IDENTIFIER,
    typeof(RadioGroupInputDependsOnFieldComponent),
    DependingFieldComponentsConstants.RADIOGROUP_FIELDDESCRIPTION)]
namespace XperienceCommunity.DependingFieldComponents.FormComponents.RadioGroupInputDependsOnFieldComponent;

/// <summary>
/// A form component which can be configured to appear based on the value of another field.
/// </summary>
[ComponentAttribute(typeof(RadioGroupInputDependsOnFieldAttribute))]
public class RadioGroupInputDependsOnFieldComponent(ILocalizationService localizationService) :
    FormComponent<RadioGroupInputDependsOnFieldProperties, RadioGroupClientProperties, string>
{
    public override string ClientComponentName => "@kentico/xperience-admin-base/RadioGroup";


    protected override void ConfigureComponent()
    {
        DependingFieldVisibilityCondition.Configure(this);

        base.ConfigureComponent();
    }


    protected override Task ConfigureClientProperties(RadioGroupClientProperties clientProperties)
    {
        clientProperties.Options = GetOptions();
        clientProperties.Value = GetClientValue();
        clientProperties.Inline = Properties.Inline;
        clientProperties.AriaLabel = localizationService.LocalizeString(Properties.AriaLabel);

        return base.ConfigureClientProperties(clientProperties);
    }


    public override string GetValue()
    {
        string value = base.GetValue();

        return GetOptions()?.FirstOrDefault(o => o.Value == value)?.Value ?? string.Empty;
    }


    private IEnumerable<RadioButton> GetOptions() => KeyValueOptionsParser.ParseDataSource(
            Properties.Options ?? string.Empty,
            (value, text) => new RadioButton { Value = value, Label = localizationService.LocalizeString(text) }
        );


    private string GetClientValue()
    {
        string value = GetValue();
        if (string.IsNullOrEmpty(value))
        {
            var options = GetOptions();
            if (!options.Any())
            {
                return string.Empty;
            }

            return options.First().Value;
        }

        return value;
    }
}

using CMS.Helpers;

using Kentico.Xperience.Admin.Base.Forms;

using XperienceCommunity.DependingFieldComponents.FormComponents;

namespace XperienceCommunity.DependingFieldComponents.VisibilityConditions;

/// <summary>
/// A visibility condition that toggles the visibility of a field depending on the value of another field.
/// </summary>
/// <param name="dependsOn">The name of the field that determines whether the component is visible.</param>
/// <param name="expectedValue">The value of the field specified by <paramref name="dependsOn"/> which will reveal the depending
/// field.</param>
public class DependingFieldVisibilityCondition(string dependsOn, string expectedValue) : VisibilityConditionWithDependency
{
    public override IEnumerable<string> DependsOnFields => new string[] { dependsOn };

    public override bool Evaluate(IFormFieldValueProvider formFieldValueProvider)
    {
        if (formFieldValueProvider.TryGet<object>(dependsOn, out object? fieldValue))
        {
            if (fieldValue is null)
            {
                return false;
            }

            string stringRepresentation = ValidationHelper.GetString(fieldValue, string.Empty);
            if (!string.IsNullOrEmpty(stringRepresentation))
            {
                return stringRepresentation.Equals(expectedValue);
            }
        }

        return true;
    }


    /// <summary>
    /// Applies a visibility condition if the required conditions are met.
    /// </summary>
    /// <param name="component">The form component to apply the visibility condition to.</param>
    public static void Configure<TProps, TClientProps, TValue>(FormComponent<TProps, TClientProps, TValue> component)
        where TProps : DependsOnPropertyProperties, new()
        where TClientProps : FormComponentClientProperties<TValue>, new()
    {
        if (!string.IsNullOrEmpty(component.Properties.DependsOn) && component.Properties.ExpectedValue is not null)
        {
            component.AddVisibilityCondition(new DependingFieldVisibilityCondition(component.Properties.DependsOn,
                component.Properties.ExpectedValue));
        }
    }
}

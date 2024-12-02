namespace XperienceCommunity.DependingFieldComponents;

internal static class KeyValueOptionsParser
{
    /// <summary>
    /// Describes a function to create an item.
    /// </summary>
    /// <param name="value">The value of the item.</param>
    /// <param name="text">The display text of the item.</param>
    internal delegate T ItemActivator<out T>(string value, string text);


    /// <summary>
    /// Parses given <paramref name="dataSource"/> by <see cref="Environment.NewLine"/> and semicolon character.
    /// </summary>
    internal static IEnumerable<T> ParseDataSource<T>(string dataSource, ItemActivator<T> activator)
    {
        string source = dataSource ?? string.Empty;
        source = source.Trim();

        string[] lines = source.Split(new[] { Environment.NewLine, "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string line in lines)
        {
            string[] items = line.Trim().Split(';');
            if (items.Length == 0)
            {
                continue;
            }

            if (items.Length == 1)
            {
                yield return activator(items[0], items[0]);
                continue;
            }

            string value = items[0];
            string text = items[1];

            yield return activator(value, text);
        }
    }
}

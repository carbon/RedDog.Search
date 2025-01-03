﻿namespace RedDog.Search.Model;

public static class IndexFieldExtensions
{
    public static IndexField IsSearchable(this IndexField field, bool value = true)
    {
        field.Searchable = value;
        return field;
    }

    public static IndexField IsFilterable(this IndexField field, bool value = true)
    {
        field.Filterable = value;
        return field;
    }

    public static IndexField IsSortable(this IndexField field, bool value = true)
    {
        field.Sortable = value;
        return field;
    }

    public static IndexField IsFacetable(this IndexField field, bool value = true)
    {
        field.Facetable = value;
        return field;
    }

    public static IndexField IsKey(this IndexField field, bool value = true)
    {
        field.Key = value;
        return field;
    }

    public static IndexField IsRetrievable(this IndexField field, bool value = true)
    {
        field.Retrievable = value;
        return field;
    }

    [ObsoleteAttribute("Consider using the suggesters property introduced in version 2014-10-20-Preview instead of this option for suggestions. In a future version the suggestions property will be deprecated in favor of using a separate suggesters specification.")]
    public static IndexField SupportSuggestions(this IndexField field, bool value = true)
    {
        field.Suggestions = value;
        return field;
    }

    public static IndexField Analyzer(this IndexField field, string value)
    {
        field.Analyzer = value;
        return field;
    }
}
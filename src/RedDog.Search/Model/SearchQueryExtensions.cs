using System.Linq;

namespace RedDog.Search.Model;

public static class SearchQueryExtensions
{
    public static SearchQuery Mode(this SearchQuery query, SearchMode mode)
    {
        query.Mode = mode;
        return query;
    }

    public static SearchQuery SearchField(this SearchQuery query, string searchField)
    {
        if (string.IsNullOrEmpty(query.SearchFields))
            query.SearchFields = searchField;
        else
            query.SearchFields += "," + searchField;
        return query;
    }

    public static SearchQuery OrderBy(this SearchQuery query, string orderByField)
    {
        if (string.IsNullOrEmpty(query.OrderBy))
            query.OrderBy = orderByField;
        else
            query.OrderBy += "," + orderByField;
        return query;
    }

    public static SearchQuery Select(this SearchQuery query, string selectField)
    {
        if (string.IsNullOrEmpty(query.Select))
            query.Select = selectField;
        else
            query.Select += "," + selectField;
        return query;
    }

    public static SearchQuery Facet(this SearchQuery query, string facetField, string? facetParameters = null)
    {
        var fieldValue = new string[] { $"{facetField},{facetParameters}".TrimEnd(',') };
        
        if (query.Facets == null || query.Facets.Any() == false)
            query.Facets = fieldValue;
        else
            query.Facets = query.Facets.Concat(fieldValue);

        return query;
    }

    public static SearchQuery Highlight(this SearchQuery query, string highlightField)
    {
        if (String.IsNullOrEmpty(query.Highlight))
            query.Highlight = highlightField;
        else
            query.Highlight += "," + highlightField;
        return query;
    }

    public static SearchQuery HighlightPreTag(this SearchQuery query, string HighlightPreTag)
    {
        query.HighlightPreTag = HighlightPreTag;
        return query;
    }

    public static SearchQuery HighlightPostTag(this SearchQuery query, string highlightPostTag)
    {
        query.HighlightPostTag = highlightPostTag;
        return query;
    }

    public static SearchQuery ScoringProfile(this SearchQuery query, string scoringProfile)
    {
        query.ScoringProfile = scoringProfile;
        return query;
    }

    public static SearchQuery ScoringParameter(this SearchQuery query, string scoringParameter)
    {
        query.ScoringParameters = [.. query.ScoringParameters, scoringParameter];
        return query;
    }
}
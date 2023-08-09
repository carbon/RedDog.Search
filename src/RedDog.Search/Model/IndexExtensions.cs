namespace RedDog.Search.Model;

public static class IndexExtensions
{
    public static SearchIndex WithField(this SearchIndex index, string name, string type, Action<IndexField>? options = null)
    {
        var field = new IndexField(name, type);
        options?.Invoke(field);
        index.Fields.Add(field);
        return index;
    }

    public static SearchIndex WithStringField(this SearchIndex index, string name, Action<IndexField>? options = null)
    {
        return WithField(index, name, FieldType.String, options);
    }

    public static SearchIndex WithStringCollectionField(this SearchIndex index, string name, Action<IndexField>? options = null)
    {
        return WithField(index, name, FieldType.StringCollection, options);
    }

    public static SearchIndex WithIntegerField(this SearchIndex index, string name, Action<IndexField>? options = null)
    {
        return WithField(index, name, FieldType.Int32, options);
    }

    public static SearchIndex WithGeographyPointField(this SearchIndex index, string name, Action<IndexField>? options = null)
    {
        return WithField(index, name, FieldType.GeographyPoint, options);
    }

    public static SearchIndex WithDoubleField(this SearchIndex index, string name, Action<IndexField>? options = null)
    {
        return WithField(index, name, FieldType.Double, options);
    }

    public static SearchIndex WithDateTimeField(this SearchIndex index, string name, Action<IndexField>? options = null)
    {
        return WithField(index, name, FieldType.DateTimeOffset, options);
    }

    public static SearchIndex WithBooleanField(this SearchIndex index, string name, Action<IndexField>? options = null)
    {
        return WithField(index, name, FieldType.Boolean, options);
    }
}
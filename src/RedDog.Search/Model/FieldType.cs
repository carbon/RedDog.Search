﻿namespace RedDog.Search.Model;

public static class FieldType
{
    public const string String = "Edm.String";
    public const string StringCollection = "Collection(Edm.String)";
    public const string Int32 = "Edm.Int32";
    public const string Int64 = "Edm.Int64";
    public const string Double = "Edm.Double";
    public const string Boolean = "Edm.Boolean";
    public const string DateTimeOffset = "Edm.DateTimeOffset";
    public const string GeographyPoint = "Edm.GeographyPoint";
}
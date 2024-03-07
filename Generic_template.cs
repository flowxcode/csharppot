public List<T> GetChildObjects<T>()
{
    List<T> objs = new List<T>();
    foreach (var rababaObject in this.rababaObjectList)
    {
        if (rababaObject.GetType() == typeof(T))
        {
            objs.Add((T)Convert.ChangeType(rababaObject, typeof(T)));
        }
    }
    return objs;
}

private T RetrieveKeysetObjectForLevel<T>(
    int keysetIndex,
    RababaLevel level,
    RProfile1 profile1)
{
    if (level == RababaLevel.A)
    {
        List<T> keys = profile1.A.GetChildObjects<T>();
        return keys[keysetIndex];
    }
    else
    {
        List<T> keys = profile1.B.SingleOrDefault().GetChildObjects<T>();
        return keys[keysetIndex];
    }
}

var rababaObject_x = RetrieveKeysetObjectForLevel<SpecialObject>(
            keysetIndex, RababaLevel, profile);

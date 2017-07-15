using System.Linq;

public static class AttributeListExtensions
{
    public static EntityAttribute GetAttribute(this AttributeList list, AttributeTypes type)
    {
        return list.Where(x => x.Type == type).SingleOrDefault();
    }
}
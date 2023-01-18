using System.IO;
using System.Xml.Serialization;

public static class SaveHelper
{
    public static string serialize<T>(this T toSer)
    {
        XmlSerializer xml = new XmlSerializer(typeof(T));
        StringWriter writer = new StringWriter();
        xml.Serialize(writer, toSer);
        return writer.ToString();
    }

    public static T deserialize<T>(this string toDeSer)
    {
        XmlSerializer xml = new XmlSerializer(typeof(T));
        StringReader reader = new StringReader(toDeSer);
        return (T)xml.Deserialize(reader);
    }

}

using System.IO;
using System.Xml.Serialization;

namespace Ex
{
    public static class XmlSerialize
    {
        public static void WriteFile<T>(T t, string path)
        {
            using var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            using var sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
            var xs = new XmlSerializer(t.GetType());
            xs.Serialize(sw, t);
        }

        public static T ReadFile<T>(string path)
        {
            using var fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            var xs = new XmlSerializer(typeof(T));
            return (T) xs.Deserialize(fs);
        }
    }
}
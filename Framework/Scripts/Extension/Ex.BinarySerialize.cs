using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Ex
{
    public static class BinarySerialize
    {
        public static void WriteFile<T>(T t, string path)
        {
            using var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            var bf = new BinaryFormatter();
            bf.Serialize(fs, t);
        }

        public static T ReadFile<T>(string path)
        {
            using var fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            var bf = new BinaryFormatter();
            return (T) bf.Deserialize(fs);
        }
    }
}
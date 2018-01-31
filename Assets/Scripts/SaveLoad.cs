using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad<T>
{

    public static string dirname = Application.persistentDataPath;
    public static List<T> LoadData = new List<T>();

    public static void Save(List<T> data)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream f = File.Create(dirname + "/save.gd");
        binaryFormatter.Serialize(f, data);
        f.Close();
    }

    public static void Load()
    {
        LoadData.Clear();
        if (File.Exists(dirname + "/save.gd"))
        {
            FileStream f = File.Open(dirname + "/save.gd", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            LoadData = (List<T>)bf.Deserialize(f);
        }
    }
}

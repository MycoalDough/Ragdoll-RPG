using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System;

public static class SaveSystem
{
    public static void SavePlayer(CurrencyManager player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.totem";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer(CurrencyManager player)
    {
        string path = Application.persistentDataPath + "/player.totem";
        FileStream stream = new FileStream(path, FileMode.Open);

        if (File.Exists(path) && stream.Length > 0)
        {
            BinaryFormatter formatter = new BinaryFormatter();


            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            BinaryFormatter formatter = new BinaryFormatter();
            PlayerData data = new PlayerData(player);
            formatter.Serialize(stream, data);
            stream.Close();
            return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad 
{
    public static List<Game> savedGames = new List<Game>();

    public static void Save()
    {
        savedGames[StartGame.game.slot]=StartGame.game;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.srpgs");
        bf.Serialize(file, savedGames);
        file.Close();
    }
    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.srpgs"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.srpgs", FileMode.Open);
            savedGames = (List<Game>)bf.Deserialize(file);
            file.Close();
        }

    }
}

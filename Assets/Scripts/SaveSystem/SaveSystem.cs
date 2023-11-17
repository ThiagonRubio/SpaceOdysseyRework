using UnityEngine;
using System.IO;

public static class SaveSystem
{
     public static void SaveToJson(GameData data)
     {
          Debug.Log("Intento guardar nuevo json");
          string json = JsonUtility.ToJson(data);
          File.WriteAllText(Application.dataPath + "/GameDataFile.json", json);
     }

     public static GameData LoadFromJson()
     {
          Debug.Log("Intento cargar un json");
          if (File.Exists(Application.dataPath + "/GameDataFile.json"))
          {
               string json = File.ReadAllText(Application.dataPath + "/GameDataFile.json");
               GameData data = JsonUtility.FromJson<GameData>(json);

               return data;
          }
          else
          {
               return null;
          }
     }
     
     // public static void SaveMoney(MoneyController actualAmount)
     // {
     //     BinaryFormatter formatter = new BinaryFormatter();
     //     string path = Application.persistentDataPath + "/money.txt";
     //
     //     FileStream stream = new FileStream(path, FileMode.Create);
     //
     //     MoneyController savedAmount = actualAmount;
     //
     //     formatter.Serialize(stream, savedAmount);
     //     stream.Close();
     // }
     //
     // public static MoneyController LoadMoney() 
     // {
     //     string path = Application.persistentDataPath + "/money.txt";
     //     if (File.Exists(path))
     //     {
     //         BinaryFormatter formatter = new BinaryFormatter();
     //         FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
     //
     //         MoneyController loadedAmount = formatter.Deserialize(stream) as MoneyController;
     //         stream.Close();
     //         return loadedAmount;
     //     }
     //     else
     //     {
     //         Debug.LogError("Save file not found in " + path);
     //         return null;
     //     }
     // }
     //
     // public static void SavePlayerStats(PlayerSavedStats upgradedStats)
     // {
     //     BinaryFormatter formatter = new BinaryFormatter();
     //     string path = Application.persistentDataPath + "/stats.txt";
     //
     //     FileStream stream = new FileStream(path, FileMode.Create);
     //
     //     PlayerSavedStats savedStats = upgradedStats;
     //
     //     Debug.Log("Guardo player stats");
     //     
     //     formatter.Serialize(stream, savedStats);
     //     stream.Close();
     // }
     //
     // public static PlayerSavedStats LoadPlayerStats() 
     // {
     //     string path = Application.persistentDataPath + "/stats.txt";
     //     if (File.Exists(path))
     //     {
     //         BinaryFormatter formatter = new BinaryFormatter();
     //         FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
     //
     //         PlayerSavedStats stats = formatter.Deserialize(stream) as PlayerSavedStats;
     //         stream.Close();
     //         return stats;
     //     }
     //     else
     //     {
     //         Debug.LogError("Save file not found in " + path);
     //         return null;
     //     }
     // }
     //
     // // private IEnumerator CloseStream()
     // // {
     // //     yield return new WaitForSeconds(1);
     // //     
     // // }
}
using UnityEngine;
using System.IO;

public static class SaveSystem
{
     public static void SaveToJson(PlayerSavedStats data)
     {
          string json = JsonUtility.ToJson(data);
          File.WriteAllText(Application.dataPath + "/PlayerDataFile.json", json);
     }

     public static void LoadFromJson(PlayerSavedStats overwrittenFile)
     {
          if (GetIfSaveFileExists())
          {
               string json = File.ReadAllText(Application.dataPath + "/PlayerDataFile.json");
               JsonUtility.FromJsonOverwrite(json, overwrittenFile);
          }
     }

    public static bool GetIfSaveFileExists()
    {
        return File.Exists(Application.dataPath + "/PlayerDataFile.json");
    }
}
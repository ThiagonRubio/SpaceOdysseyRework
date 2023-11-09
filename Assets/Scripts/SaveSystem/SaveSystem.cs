using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    //ESTO LO DEBERÍAN LLAMAR LOS BOTONES DEL MENÚ DE UPGRADE CUANDO SE COMPRE UNA MEJORA, O QUIZÁS SEA MEJOR QUE LO TENGA EL BOTÓN DE VOLVER AL MENÚ, PARA AHORRAR
    // public static void SaveUpgrades  (UpgradeController upgradeController) //Acá habría que pasarle el script o asset que tenga la info de las mejoras compradas
    // {
    //     BinaryFormatter formatter = new BinaryFormatter();
    //     string path = Application.persistentDataPath + "/stats.txt";
    //
    //     FileStream stream = new FileStream(path, FileMode.Create);
    //
    //     PlayerStats stats = new PlayerStats(upgradeController); //Acá habría que poner una clase que sólo guarde la info de las stats (upgradeables) del player 
    //
    //     formatter.Serialize(stream, stats);
    //     stream.Close();
    // }
    //
    //ESTO LO DEBERÍA LLAMAR EL PLAYER CUANDO ARRANQUE LA PARTIDA
    //
    // public static PlayerStats LoadUpgrades() //Acá habría que hacer que devuelva la misma clase que guarda la info de las stats
    // {
    //     string path = Application.persistentDataPath + "/stats.txt";
    //     if (File.Exists(path))
    //     {
    //         BinaryFormatter formatter = new BinaryFormatter();
    //         FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
    //
    //         PlayerStats stats = formatter.Deserialize(stream) as PlayerStats;
    //         stream.Close();
    //         return stats;
    //     }
    //     else
    //     {
    //         Debug.LogError("Save file not found in " + path);
    //         return null;
    //     }
    // }
}
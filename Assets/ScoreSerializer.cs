using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class ScoreSerializer
{
    public static void SaveHighScore(PlayerScore score)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/score.scr";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, score);
        stream.Close();
    }

    public static PlayerScore LoadHighScore()
    {
        string path = Application.persistentDataPath + "/score.scr";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerScore score = (PlayerScore)formatter.Deserialize(stream);
            stream.Close();

            return score;
        }
        else
        {
            Debug.Log("No save file");
            return new PlayerScore();
        }
    }
}

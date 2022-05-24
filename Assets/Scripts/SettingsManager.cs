using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;

    public string Name;
    public Highscore CurrentHighscore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveHighscore(Highscore highscore)
    {
        this.CurrentHighscore = highscore;

        string json = JsonUtility.ToJson(highscore);
        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }

    public Highscore LoadHighscore()
    {
        string path = Application.persistentDataPath + "/highscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            this.CurrentHighscore = JsonUtility.FromJson<Highscore>(json);
        }
        else
        {
            this.CurrentHighscore = new Highscore
            {
                Name = "",
                Score = 0
            };
        }

        return this.CurrentHighscore;
    }
}

[Serializable]
public class Highscore
{
    public string Name;
    public int Score;
}

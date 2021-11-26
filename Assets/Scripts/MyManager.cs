using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MyManager : MonoBehaviour
{
    public static MyManager instance { get; private set; }
    public string bestName;
    public int bestScore;

    public string currName;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        GetData();
    }
    public void SaveNameAndScore(string name, int score)
    {
        NameScore data = new NameScore();
        data.name = name;
        data.score = score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    [System.Serializable]
    class NameScore
    {
        public string name;
        public int score;
    }
    void GetData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            NameScore data = JsonUtility.FromJson<NameScore>(json);
            bestName = data.name;
            bestScore = data.score;
        }
    }
    public  void ResetRecords()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            File.Delete(path);
            bestName = " ";
            bestScore = 0;
            print(bestName);
        }
    }
}


using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string Name;
    public string NameBestScore;
    public int BestScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Name = string.Empty;
            BestScore = 0;
        } else
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        Data data = new Data();
        LoadData();
    }

    [System.Serializable]
    class Data
    {
        public string Name;
        public string NameBestScore;
        public int BestScore;
    }

    public void SaveData()
    {
        Data data = new Data();
        data.Name = Name;
        data.NameBestScore = NameBestScore;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Data data = JsonUtility.FromJson<Data>(json);

            Name = data.Name;
            NameBestScore = data.NameBestScore;
            BestScore = data.BestScore;
        }
        else
        {
            Name = string.Empty;
            NameBestScore = string.Empty;
            BestScore = 0;
        }
    }
}

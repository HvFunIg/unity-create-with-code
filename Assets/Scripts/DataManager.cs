using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour{
    public static DataManager Instance;
    public string userName;
    public int highScorePoints = 0;
    private void Awake(){
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); 
        LoadHighScore();
    }

  [System.Serializable]
    class SaveScore{
        public string user;
        public int points;
    }

    public void CheckHighScore(int m_Points){
        Debug.Log(m_Points + " vs " + highScorePoints);
        if (m_Points > highScorePoints){
            SaveScore score = new SaveScore();
            score.user = userName;
            score.points = m_Points;
            string json = JsonUtility.ToJson(score);
            File.WriteAllText(Application.persistentDataPath + "/savescore.json",json);
            Debug.Log(File.ReadAllText(Application.persistentDataPath+"/savescore.json"));
        }
    }

    public string LoadHighScore(){
        string path = Application.persistentDataPath+"/savescore.json";
        if (File.Exists(path)){
            string json = File.ReadAllText(path);
            SaveScore score = JsonUtility.FromJson<SaveScore>(json);

            highScorePoints = score.points;
            return "BestScore: " + score.user + " with " + score.points + "points";
        }
        else return "BestScore: 0";
    }
}

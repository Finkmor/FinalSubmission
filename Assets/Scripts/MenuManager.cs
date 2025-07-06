using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public int diffLevel = 0;
    public static int levelsCleared2;
    [SerializeField] private Button StartButton;
    [SerializeField] private Button QuitButton;
    [SerializeField] private Button ReturnButton;
    [SerializeField] private Button Level1;
    [SerializeField] private Button Level2;
    [SerializeField] private Button Level3;
    [SerializeField] private Button Level4;
    [SerializeField] private Button reload;
    private void Start()
    {
        Debug.Log(levelsCleared2);
    }
    public void StartButtonPress()
    {
        SelectLevel();
    } 
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void ExitButton()
    {
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.ExitPlaymode();
        }
        Application.Quit();
        SaveDataMethod();
    }

    public void SelectLevel()
    {
        LoadDataMethod();
        if (levelsCleared2 == 0)
        {
            Level1.gameObject.SetActive(true);
        }
        if (levelsCleared2 == 1)
        {
            Level1.gameObject.SetActive(true);
            Level2.gameObject.SetActive(true);
        }
        if (levelsCleared2 == 2)
        {
            Level1.gameObject.SetActive(true);
            Level2.gameObject.SetActive(true);
            Level3.gameObject.SetActive(true);
        }
        if (levelsCleared2 == 2)
        {
            Level1.gameObject.SetActive(true);
            Level2.gameObject.SetActive(true);
            Level3.gameObject.SetActive(true);
            Level4.gameObject.SetActive(true);
        }
        ReturnButton.gameObject.SetActive(true);
        reload.gameObject.SetActive(true);
        StartButton.gameObject.SetActive(false);
        QuitButton.gameObject.SetActive(false);

    }
    public void MenuSelect()
    {
        StartButton.gameObject.SetActive(true);
        QuitButton.gameObject.SetActive(true);

        Level1.gameObject.SetActive(false);
        Level2.gameObject.SetActive(false);
        Level3.gameObject.SetActive(false);
        Level4.gameObject.SetActive(false);
        ReturnButton.gameObject.SetActive(false);

        reload.gameObject.SetActive(false);
    }
    public void Reload()
    {
        levelsCleared2 = 0;
    }
    public void Level1Select()
    {
        SceneManager.LoadScene(1);
        diffLevel = 1;
    }
    public void Level2Select()
    {
        SceneManager.LoadScene(1);
        diffLevel = 2;
    }
    public void Level3Select()
    {
        SceneManager.LoadScene(1);
        diffLevel = 3;
    }
    public void Level4Select()
    {
        SceneManager.LoadScene(1);
        diffLevel = 4;
        Debug.Log(levelsCleared2);
    }
    public class SaveData
    {
        public int level;
    }
    public void SaveDataMethod()
    {
        SaveData data = new SaveData();
        data.level = levelsCleared2;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadDataMethod()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            levelsCleared2 = data.level;
        }
    }
}

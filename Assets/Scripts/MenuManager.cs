using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public string PlayerName;
    public InputField InputName;

    // Start is called before the first frame update
    void Start()
    {
        DataManager.Instance.LoadData();
        InputName.text = DataManager.Instance.Name;
        PlayerName = DataManager.Instance.Name;
        Debug.Log("Welcome back " + PlayerName);
        if(DataManager.Instance != null )
        {
            InputName.textComponent.text = DataManager.Instance.Name;
            //InputName.text = DataManager.Instance.Name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NameInput(string name)
    {
        PlayerName = name;
        DataManager.Instance.Name = name;
        DataManager.Instance.SaveData();
        Debug.Log("Hello " +  name);
        Debug.Log("Hello " +  PlayerName);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("main");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode(); // stop play mode if in Unity Editor
#else
        Application.Quit(); // quit the game if not in the Unity Editor
#endif
    }
}

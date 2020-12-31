using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Debug.Log("退出成功！");
        Application.Quit();
    }

    public void LoadStorage()
    {
        int sceneIndex = PlayerPrefs.GetInt("MaxSceneIndex");
        Debug.Log(sceneIndex);
        SceneManager.LoadScene(sceneIndex);
    }


}

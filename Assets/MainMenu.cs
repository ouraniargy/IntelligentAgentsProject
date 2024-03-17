using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance; //singleton
    public Slider progressBar;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartApp()
    {
        //TODO
        
        Debug.Log("Start");

       StartCoroutine(LoadYourAsyncScene());
    }

    IEnumerator LoadYourAsyncScene()
    {
        yield return new WaitForSeconds(5);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenu");
        asyncLoad.allowSceneActivation = false; 
        while (!asyncLoad.isDone)
        {
            progressBar.value = asyncLoad.progress;
            yield return null;
            if (Input.GetKeyDown(KeyCode.E))
            {
                //allow scene to be activated
                asyncLoad.allowSceneActivation = true;
            }
        }
    }

    public void QuitApp()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}

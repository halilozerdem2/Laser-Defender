using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float sceneLoadDelay = 1f;
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadMainMenuScee()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadGameOverScene()
    {
        StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));
    }
    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}

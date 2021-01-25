using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public void MainScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void StartScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void CollectionScene()
    {
        SceneManager.LoadScene("Collections");
    }

    public void RandomScene()
    {
        SceneManager.LoadScene("Random");
    }

    public void EventScene()
    {
        SceneManager.LoadScene("Event");
    }
}

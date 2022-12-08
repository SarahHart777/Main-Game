using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void MainScene()
    {
        SceneManager.LoadScene("Main_Area");
    }

    public void MazeScene()
    {
        SceneManager.LoadScene("Maze");
    }

    public void EndScene()
    {
        SceneManager.LoadScene("End_Scene");
    }
}

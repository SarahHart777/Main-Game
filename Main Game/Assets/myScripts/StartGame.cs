using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public int numFound;
    public GameObject halfPopUp;
    public GameObject gameOverPopUp;
    
    private float distance = 2.0f;
    private float timeWaited = 2.5f;

    void Start()
    {
        
    }

    void Update()
    {
      
    }

    public void GameOver()
    {
        if (numFound == 1)
        {
            Debug.Log("numFound = 1");
            halfPopUp.gameObject.SetActive(true);
            halfPopUp.transform.position = Camera.main.transform.position + Camera.main.transform.up + Camera.main.transform.forward * distance;
            halfPopUp.transform.rotation = new Quaternion(0.0f, Camera.main.transform.rotation.y, 0.0f, Camera.main.transform.rotation.w);
            Time.timeScale = 0.0f;
        }
       else if (numFound == 2)
        {
            Time.timeScale = 0.0f;
            Debug.Log("numFound = 2");
            gameOverPopUp.gameObject.SetActive(true);
            gameOverPopUp.transform.position = Camera.main.transform.position + Camera.main.transform.up + Camera.main.transform.forward * distance;
            gameOverPopUp.transform.rotation = new Quaternion(0.0f, Camera.main.transform.rotation.y, 0.0f, Camera.main.transform.rotation.w);
            Debug.Log("Game Over");

        }
    }

    
}

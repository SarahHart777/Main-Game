using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMonsterEnter : MonoBehaviour
{
    private Vector3 gameOverPosition = new Vector3(31.3f, -11.73501f, 0.02f);
    private Vector3 youWinPosition = new Vector3(31.3f, -11.73501f, -3f);
    private AudioSource audioSource;
    public AudioClip DINGDINGDINGDINGDINGDINGDINGdingdingdingdingdingdingding;
    private bool hasBluePellet;
   
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        hasBluePellet = false;
    }

    public void playDINGDINGSound() {
        audioSource.PlayOneShot(DINGDINGDINGDINGDINGDINGDINGdingdingdingdingdingdingding);
        hasBluePellet = true;
    }

    // Update is called once per frame
   
    void OnTriggerEnter(Collider collision) 
    {
        Debug.Log("hiii!asdfdsasf");
        if (collision.CompareTag("Enemy")) 
        {
            if (hasBluePellet == true) 
            {
                YouWin();
            } else if (hasBluePellet == false) 
            {
                Debug.Log("Enemy got you");
                GameOver();
            }
            
        }
    }

    void GameOver() 
    {
        gameObject.transform.position = gameOverPosition;
    }

    void YouWin() 
    {
        gameObject.transform.position = youWinPosition;
    }
       
    

    

}

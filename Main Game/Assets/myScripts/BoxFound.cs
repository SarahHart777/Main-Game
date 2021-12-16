using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class BoxFound : MonoBehaviour
{
    public bool found;
    public StartGame sg;


    void Awake()
    {

    }

    void Update()
    {
       
    }

    public void Found()
    {
        sg.numFound++;
        Debug.Log("Found" + sg.numFound);
    }


}

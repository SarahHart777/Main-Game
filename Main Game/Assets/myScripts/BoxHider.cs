using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class BoxHider : MonoBehaviour
{
    public GameObject box1;
    public GameObject box2;
    public LayerMask layer;
    public RaycastHit hit;
    public GameObject[] furniture;
    public GameObject[] boxes;
    public GameObject furnitureSelect;
    public StartGame sg;
   //public UnityEvent test;


    public int index;


    void Start()
    {

        hidingPlaces();
        reHide();
        //boxCol = GetComponent<Collider>();
        //boxCol.isTrigger = false;

        //here's the issue, the colliders won't work, why? because they don't have rigidbodies, when i give them rigidbodies they don't merge with the furniture anymore so they just fall on the ground
        //so I try to make the objects ignore the furniture layer so they can pass but it's not working

    }

    void Update()
    {
        
     
    }

    public void hidingPlaces()
    {
        foreach (GameObject box in boxes)
        {

        index = Random.Range(0, furniture.Length);
        int prevIndex = index;
        while (prevIndex == index)
        {
            index = Random.Range(0, furniture.Length);
        }
        furnitureSelect = furniture[index];
        Debug.Log(furnitureSelect.transform.name);

            box.transform.position = furnitureSelect.transform.position;
        box.transform.localScale = furnitureSelect.transform.localScale;
      }

        
       
    }

    public void reHide()
    {
           if (box1.transform.position == box2.transform.position)
        {
            hidingPlaces();
        }
    }

    

}
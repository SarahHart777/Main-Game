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

        public Rigidbody firstBox;
    public Rigidbody secondBox;
    void Start()
    {
        firstBox = GetComponent<Rigidbody>();
        secondBox = GetComponent<Rigidbody>();

        if (gameObject.name == "Box_1" || gameObject.name == "Box_2")
        {
            Physics.IgnoreLayerCollision(0, 6);
            Debug.Log("removing layer");
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        /*if (collision.gameObject.name == "Box_2" || collision.gameObject.name == "Box_1")
        {
            Debug.Log("ARE YOU WORKING???");
            //If the GameObject's name matches the one you suggest, output this message in the console
            boxHider.hidingPlaces();
        }*/
        //I added test, see if anything can be done with it, it's called a unity event
        //original vv
        /*if (collision.gameObject.name == "Box_1" || collision.gameObject.name == "Box_2")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            bh.hidingPlaces();
            Debug.Log("ARE YOU WORKING???");
           // Debug.Log(furnitureSelect.transform.name);
        }*/

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{

    public GameObject canvasPopUp;

    private float distance = 0.8f;
    private float right = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pops()
    {
        canvasPopUp.transform.position = Camera.main.transform.position + Camera.main.transform.forward * distance;
        canvasPopUp.transform.rotation = new Quaternion(0.0f, Camera.main.transform.rotation.y, 0.0f, Camera.main.transform.rotation.w);
    }

    public void PopUpward()
    {
        canvasPopUp.transform.position = Camera.main.transform.position + Camera.main.transform.right * right;
        canvasPopUp.transform.position = Camera.main.transform.position + Camera.main.transform.forward * distance;
        canvasPopUp.transform.rotation = new Quaternion(0.0f, Camera.main.transform.rotation.y, 0.0f, Camera.main.transform.rotation.w);
    }

}

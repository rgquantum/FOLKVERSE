using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSetter : MonoBehaviour
{

    public Camera camera;




    // Start is called before the first frame update
    void Start()
    {
        camera = this.gameObject.transform.parent.GetComponent<Camera>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

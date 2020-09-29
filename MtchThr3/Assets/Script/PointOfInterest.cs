using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfInterest : Subject
{
    //Nama dari point of interest
    [SerializeField]
    private string _poiName;

    //Jika gameobject di disable akan menotify Observernya
    private void OnDisable()
    {
        Notify(_poiName);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

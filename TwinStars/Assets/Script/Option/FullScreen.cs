using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen : MonoBehaviour {

    int counter = 0;
	
    // Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if(counter == 0)
        {
            Screen.SetResolution(1280, 800, true);

            counter++;
        }
        else if(counter == 1)
        {
            Screen.SetResolution(640, 480, false);
            counter--;
        }
    }
}

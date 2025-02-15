using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{ string String = "Hello ";
    int okay = 2;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World");
        string String2 = "World";
        Debug.Log(String+String2);
        /* HEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE 
         * assaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa */
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(okay);
        okay++;
    }
}

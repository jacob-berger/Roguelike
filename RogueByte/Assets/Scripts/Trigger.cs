using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Trigger : MonoBehaviour
{

    string parentName;
    Transform parent;
    Transform grandparent;

    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.parent;
        grandparent = parent.parent;
        parentName = parent.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            switch (parentName)
            {
                case "Bear":
                    grandparent.GetComponent<Bear>().EnteredTrigger();
                    break;
                default:
                    // Debug.Log(parentName);
                    break;
            }
            
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            switch (parentName)
            {
                case "Bear":
                    grandparent.GetComponent<Bear>().ExitedTrigger();
                    break;
                default:
                    // Debug.Log(parentName);
                    break;
            }
        }
    }
}

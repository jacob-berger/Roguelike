using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuScript : MonoBehaviour
{
    protected bool debug = true;
    int difficulty = 1;
    Dictionary<KeyCode, string> keyMap;

    // Start is called before the first frame update
    void Start()
    {
        // volumeText = GameObject.Find("VolumeLevel").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleDebug() {
        debug = !debug;
        Debug.Log(debug);
    }

    public bool getDebug() {
        return debug;
    }

    
}

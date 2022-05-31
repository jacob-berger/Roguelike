using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{

    public Button _PlayButton, _OptionsButton, _ExitButton;
    public Camera _Menu;

    // Start is called before the first frame update
    void Start()
    {
        _PlayButton = GameObject.Find("Play").GetComponent<Button>();
        // _PlayButton.onClick.AddListener(Test);

        _Menu = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        Debug.Log("Play clicked");

    }

    public void Options() 
    {
        Debug.Log("Options clicked");
        

    }

    public void Exit() 
    {
        Debug.Log("Exit clicked");
        
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit();
    }
}

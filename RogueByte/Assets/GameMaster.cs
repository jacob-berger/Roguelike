using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    private static GameMaster _instance;
    public static GameMaster Instance {
        get {return _instance;}
    }

    // Gameboard gameboard;
    // Player player;

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Here");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

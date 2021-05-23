using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public new string name = "Luke";
    public uint totalPunished = 0;
    public int planetsDestroyed = 0;
    public int asteroidsDestroyed = 0;
    
    void Start()
    {
        
    }

    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if(totalPunished > 100) {
            Debug.Log("Bad End");
        }
    }
}

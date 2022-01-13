using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save_level : MonoBehaviour
{
    // Start is called before the first frame update
    
    Options_Script var;
    public int l;
    

    // Update is called once per frame
    void Awake()
    {
        var=FindObjectOfType<Options_Script>();
        // DontDestroyOnLoad(var);
    }
}

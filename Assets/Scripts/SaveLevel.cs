using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLevel : MonoBehaviour
{
    // Start is called before the first frame update
    
    OptionsScript var;
    public int l;
    

    // Update is called once per frame
    void Awake()
    {
        var=FindObjectOfType<OptionsScript>();
        // DontDestroyOnLoad(var);
    }
}

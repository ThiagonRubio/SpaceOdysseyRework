using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBGM : MonoBehaviour
{
    public GameObject bgmMenuSource;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("BGMMenu") == null)
        {
            Instantiate(bgmMenuSource);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

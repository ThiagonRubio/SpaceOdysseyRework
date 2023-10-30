using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.FindGameObjectWithTag("EnemiesParent");
        gameObject.transform.SetParent(parent.transform);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(-10f * Time.deltaTime, 0, 0);
        Destroy(gameObject, 5f);
    }

    public void finAnimation()
    {
        Destroy(gameObject, 0.2f);
    }
}

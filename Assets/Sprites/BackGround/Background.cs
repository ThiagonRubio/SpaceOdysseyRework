using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private Vector2 movementSpeed;

    private Vector2 offSet;

    private Material material;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Start()
    {
        
    }

    private void Update()
    {
        offSet = movementSpeed * Time.deltaTime;

        material.mainTextureOffset += offSet;
    }
}

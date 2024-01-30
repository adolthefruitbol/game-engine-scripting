using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Character : MonoBehaviour
{

    bool didUpdate = false;
    bool didLateUpdate = false ;
    void Awake()
    {
        Debug.Log("I AM AWAKE!");
        
        
    }
    void Start()
    {
        Debug.Log("I AM STARTING!");
    }

    void Update()
    {
        if (didUpdate == false)
        {
            Debug.Log("I AM UPDATED!");
            Debug.LogWarning("STOP OR YOU WILL BE SHOT!");
            Debug.LogError("BOOOOOO!");
            didUpdate = true;
        }
        
    }

    private void LateUpdate()
    {
        if(didLateUpdate == false)
        {
            Debug.Log("Late Update");
            didLateUpdate = true;
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void OnEnable()
    {
        Debug.Log("I am enabled");
    }

    private void OnDisable()
    {
        Debug.Log("I am disabled");

    }
}

//too many comments... Can get away with
//No comments = no points :(

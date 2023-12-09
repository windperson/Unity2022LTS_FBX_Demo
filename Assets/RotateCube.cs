using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour
{
    public float speed = 20f; // This variable is now public and can be set from the Unity Editor UI

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"{nameof(RotateCube)} : On Start()");
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log($"{nameof(RotateCube)} : On Update()");
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}

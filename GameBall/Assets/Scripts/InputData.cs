using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputData : MonoBehaviour
{

    public static Vector3 inputAccelerometer = Vector3.zero;

    static float x;
    static float y;
    static float z;
    public static float X
    {
        get { return x; }
    }
    public static float Y
    {
        get { return y; }
    }
    public static float Z
    {
        get { return z; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.acceleration != Vector3.zero)
        {
            x = Input.acceleration.x;
            y = Input.acceleration.y;
        }
        else
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");
        }

    }


}

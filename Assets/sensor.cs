using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GetAccelerometer()
    {
        Vector3 dir = Vector3.zero;
        dir.y = -Input.acceleration.y;
        dir.x = Input.acceleration.x;
        return dir;
    }

    // Get Gyroscope
    private Quaternion GetGyroscope()
    {
        Quaternion q = Input.gyro.attitude;
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}

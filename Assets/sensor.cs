using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sensor : MonoBehaviour
{
    public Text Accelerometer_text;
    public Text Gyroscope_text;
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Accelerometer_text.text = GetAccelerometer().ToString();
        Gyroscope_text.text = GetGyroscope().ToString();
        Debug.Log(GetAccelerometer() + " - " + GetGyroscope());
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

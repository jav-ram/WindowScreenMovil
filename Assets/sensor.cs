using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TCPmsg
{
    //public string tx;
    //public string ty;
    //public string tz;
    
    public string rx;
    public string ry;
    public string rz;
    public string rw;
}

public class Sensor : MonoBehaviour
{
    public Text Accelerometer_text;
    public Text Gyroscope_text;

    private TCPmsg msg;
    private TCP_Client client;
    private Vector3 prevAcc;
    // Start is called before the first frame update
    void Start()
    {
        msg = new TCPmsg();
        Input.gyro.enabled = true;
        client = this.GetComponent<TCP_Client>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 acc = GetAccelerometer();
        Quaternion rot = GetGyroscope();

        //Accelerometer_text.text = acc.ToString();
        Gyroscope_text.text = rot.ToString();

        // msg.tx = acc.x.ToString();
        // msg.ty = acc.y.ToString();
        // msg.tz = (-acc.z).ToString();

        msg.rx = rot.x.ToString();
        msg.ry = rot.y.ToString();
        msg.rz = rot.z.ToString();
        msg.rw = rot.w.ToString();

        client.SendMessage(JsonUtility.ToJson(msg));

    }

    private Vector3 GetAccelerometer()
    {
        Vector3 acc = Input.acceleration;
        Vector3 dir = prevAcc - acc;
        prevAcc = acc;
        
        Vector3 r = Vector3.Lerp(Vector3.zero, dir, dir.magnitude);
        return dir;
    }

    // Get Gyroscope
    private Quaternion GetGyroscope()
    {
        Quaternion q = Input.gyro.attitude;
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}

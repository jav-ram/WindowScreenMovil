using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TCPmsg
{
    public string tx;
    public string ty;
    public string tz;
    
    public string rx;
    public string ry;
    public string rz;

    public string reset;
}

public class Sensor : MonoBehaviour
{
    public Text Accelerometer_text;
    public Text Gyroscope_text;

    private TCPmsg msg;
    private TCP_Client client;
    private Vector3 prevPos;

    // Start is called before the first frame update
    void Start()
    {
        msg = new TCPmsg();
        Input.gyro.enabled = true;
        client = GameObject.Find("NetworkManager").GetComponent<TCP_Client>();
        Accelerometer_text = GameObject.Find("Accelerometer").GetComponent<Text>();
        Gyroscope_text = GameObject.Find("Gyroscope").GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = GetDifPosition();
        Vector3 rot = GetGyroscope();

        Accelerometer_text.text = transform.position.ToString();
        Gyroscope_text.text = rot.ToString();


        msg.tx = System.Math.Round(pos.x, 6).ToString();
        msg.ty = System.Math.Round(pos.y, 6).ToString();
        msg.tz = System.Math.Round(pos.z, 6).ToString();

        msg.rx = System.Math.Round(rot.x, 6).ToString();
        msg.ry = System.Math.Round(rot.y, 6).ToString();
        msg.rz = System.Math.Round(rot.z, 6).ToString();

        client.SendMessage(JsonUtility.ToJson(msg));

    }

    private Vector3 GetDifPosition()
    {
        // Vector3 pos = transform.position;
        // Vector3 dif = pos - prevPos;
        // prevPos = pos;
        return transform.position;
    }

    // Get Gyroscope
    private Vector3 GetGyroscope()
    {
        return transform.rotation.eulerAngles;
    }
    
}

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
    public string rw;

    public string reset;
}

public class Sensor : MonoBehaviour
{
    public Text Accelerometer_text;
    public Text Gyroscope_text;
    public int scale;

    private TCPmsg msg;
    private TCP_Client client;
    private Vector3 prevPos;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        msg = new TCPmsg();
        Input.gyro.enabled = true;
        client = this.GetComponent<TCP_Client>();
        count = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (count % 2 == 0) {
            Vector3 pos = GetDifPosition();
            Quaternion rot = GetGyroscope();



            Accelerometer_text.text = transform.position.ToString();
            Gyroscope_text.text = rot.ToString();


            msg.tx = System.Math.Round(pos.x, 6).ToString();
            msg.ty = System.Math.Round(pos.y, 6).ToString();
            msg.tz = System.Math.Round(pos.z, 6).ToString();

            msg.rx = System.Math.Round(rot.x, 6).ToString();
            msg.ry = System.Math.Round(rot.y, 6).ToString();
            msg.rz = System.Math.Round(rot.z, 6).ToString();
            msg.rw = System.Math.Round(rot.w, 6).ToString();

            client.SendMessage(JsonUtility.ToJson(msg));
            if (count > 10000) {
                count = 0;
            }
        }
        count++;
    }

    private Vector3 GetDifPosition()
    {
        Vector3 pos = transform.position;
        Vector3 dif = prevPos - pos;
        prevPos = pos;
        
        Vector3 r = Vector3.Lerp(Vector3.zero, dif, dif.magnitude);
        return transform.position;
    }

    // Get Gyroscope
    private Quaternion GetGyroscope()
    {
        return transform.rotation;
    }

    public void SetBack() {
        msg.reset = "true";
        client.SendMessage(JsonUtility.ToJson(msg));
        transform.position = Vector3.zero;
        msg.reset = "";
    }
    
}

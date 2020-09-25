using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arcore_manager : MonoBehaviour
{
    public GameObject arcamera;
    public string name;

    public void Reset() {
        StartCoroutine(SetBack());
    }

    IEnumerator SetBack() {
        Destroy(GameObject.FindWithTag("MainCamera"));
        yield return new WaitForSeconds(1);
        Instantiate(arcamera); 
    }

}

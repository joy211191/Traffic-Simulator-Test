using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadRecycle : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Road")
        {
            Vector3 Road_Position = new Vector3(0, 0, other.gameObject.transform.position.z +484f);
            Instantiate(other.gameObject, Road_Position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}

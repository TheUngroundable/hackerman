using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mazza : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Computer"){
            Debug.Log("Hit Computer!");
            collision.gameObject.GetComponent<Computer>().setRepaired(true);
        }
    }
}

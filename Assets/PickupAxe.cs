using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAxe : MonoBehaviour
{
    public GameObject axeOnPlayer;
    void Start()
    {
        axeOnPlayer.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);

                axeOnPlayer.SetActive(true);
            }
        }
    }
}

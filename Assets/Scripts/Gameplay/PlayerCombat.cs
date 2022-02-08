using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() != null) //Evolve index'e if koþulu girilecek.
                                                 //Evolve index artacak.
                                                 //Vibration?
        {                                           
            other.GetComponent<Enemy>().Death();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Enemy>() != null)
        {
            other.transform.parent.gameObject.SetActive(false);
        }
    }
}

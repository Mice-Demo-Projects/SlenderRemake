using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public void Collect()
    {
        //Particle oynayacak.
        transform.parent.gameObject.SetActive(false);
    }
}

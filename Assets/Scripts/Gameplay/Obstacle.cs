using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public void Collect()
    {
        //Particle oynayacak.
        gameObject.SetActive(false);
    }
}

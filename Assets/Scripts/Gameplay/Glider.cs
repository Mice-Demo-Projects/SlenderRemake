using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glider : MonoBehaviour
{
    public void GliderFollow()
    {
        Vector3 glidePos = transform.GetChild(0).GetChild(0).transform.position;
        glidePos.z = PlayerMovement.instance.playerPos.z;
        transform.GetChild(0).GetChild(0).transform.position = glidePos;
    }
}

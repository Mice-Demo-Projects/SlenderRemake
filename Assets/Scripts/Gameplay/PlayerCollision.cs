using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collectable>() != null)
        {
            other.GetComponent<Collectable>().Collect();
            transform.parent.GetComponent<Player>().EvolveShift(5);
        }
        if (other.GetComponent<Obstacle>() != null)
        {
            other.GetComponent<Obstacle>().Collect();
            transform.parent.GetComponent<Player>().EvolveShift(-5);
        }
        if (other.GetComponent<Glider>() != null)
        {
            transform.parent.GetComponent<PlayerMovement>().GlideOn();
        }

        if (other.CompareTag("Finish"))
        {
            LevelManager.gameState = GameState.Finish;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Glider>() != null)
        {
            transform.parent.GetComponent<PlayerMovement>().GlideOff();
        }
    }
}

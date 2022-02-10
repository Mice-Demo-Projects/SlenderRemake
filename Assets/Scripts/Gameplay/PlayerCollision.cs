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
            if (Player.instance.stateIndex > 0)
            {
                transform.parent.GetComponent<PlayerMovement>().GlideOn();
            }
            else
            {
                CompletePanel.instance.Activator(false);
                PlayerAnimation.instance.PlayAnimation("Salsa");
            }
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
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Glider>() != null)
        {
            if (Player.instance.stateIndex > 0 && PlayerMovement.instance.gliding)
            {
                other.GetComponent<Glider>().GliderFollow();
            }
        }
    }
}

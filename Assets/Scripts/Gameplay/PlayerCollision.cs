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
                Player.instance.Lose();
            }
        }
        if (other.CompareTag("Finish"))
        {
            if (Player.instance.stateIndex > 0)
            {
                LevelManager.gameState = GameState.Finish;
                PlayerMovement.instance.FinalWalk();
            }
            else
            {
                Player.instance.Lose();
            }
        }
        if (other.CompareTag("FinishCube") && PlayerMovement.instance.gliding == true)
        {
            FinalGradient.instance.Paint(other);
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

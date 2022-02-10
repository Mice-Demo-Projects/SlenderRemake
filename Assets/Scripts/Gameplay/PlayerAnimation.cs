using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public static PlayerAnimation instance;


    private void Awake()
    {
        instance = this;
    }
    public void PlayAnimation(string animation)
    {
        transform.GetChild(Player.instance.stateIndex).transform.GetComponent<Animator>().Play(animation);
    }
    public void StopAnimation()
    {
        //transform.GetChild(Player.instance.stateIndex).transform.GetComponent<Animator>().speed = 0f;
    }
}

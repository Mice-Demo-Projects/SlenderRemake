using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolve : MonoBehaviour
{
    public static Player instance;

    #region Variables
    Transform skinHolder;
    public int maxEvolveCount;
    public int evolveValue;
    public string[] evolveTexts = {"Baby", "Freaky", "Horrible", "Monster" };
    public List<GameObject> evolveSkin = new List<GameObject>();

    #endregion
    private void Start()
    {
        SetValues();
    }
    private void Awake()
    {
    }
    void SetValues()
    {
        maxEvolveCount = 4;
        skinHolder = transform.GetChild(0);
        for (int i = 0; i < maxEvolveCount; i++)
        {
            evolveSkin.Add(skinHolder.GetChild(i).gameObject);
        }
    }
    void EvolveShift(int amount)
    {
        evolveValue += amount;
        EvolveControl();
    }

    void EvolveControl()
    {
        //if (evolveValue < 5)
        //{
        //    if (state != prevState)
        //    {
        //        SkinSwap(state);
        //    }
        //}
        //else if (5 <= evolveValue && evolveValue < 10)
        //{
        //    if (state != prevState)
        //    {
        //        SkinSwap(state);
        //    }
        //}
        //else if (10 <= evolveValue && evolveValue < 15)
        //{
        //    state = EvolveStates.Horrible;
        //    if (state != prevState)
        //    {
        //        SkinSwap(state);
        //    }
        //}
        //else if (20 <= evolveValue)
        //{
        //    if (state != prevState)
        //    {
        //        SkinSwap(state);
        //    }
        //}
    }
}



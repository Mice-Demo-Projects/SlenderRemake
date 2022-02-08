using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instance;

    #region Variables
    Transform skinHolder;
    [System.NonSerialized] public int evolveIndex;
    public EvolveStates state;
    public EvolveStates prevState;
    public List<string> evolveStateTexts = new List<string>();
    #endregion
    public enum EvolveStates
    {
        Baby,
        Freaky,
        Horrible,
        Monster
    }
    private void Start()
    {
        SetValues();
    }
    void SetValues()
    {
        evolveIndex = 0;
        skinHolder = transform.GetChild(0);
    }
    public void EvolveShift(int amount)
    {
        // Evolve'umuzu etkileyen tüm faktörler bu fonksiyonu çaðýracak.
        prevState = state;
        evolveIndex += amount;
        EvolveControl();
    }
    void EvolveControl()
    {
        // Evolve olup olmadýðýmýz, olduysak ne olacaðý kontrol edilecek.
        if (evolveIndex < 20)
        {
            state = EvolveStates.Baby;
            SkinSwap(state);
        }
        else if (20 <= evolveIndex && evolveIndex < 40)
        {
            state = EvolveStates.Freaky;
            SkinSwap(state);
        }
        else if (40 <= evolveIndex && evolveIndex < 60)
        {
            state = EvolveStates.Horrible;
            SkinSwap(state);
        }
        else if (60 <= evolveIndex)
        {
            state = EvolveStates.Monster;
            SkinSwap(state);
        }
    }
    void SkinSwap(EvolveStates state)
    {
        if (state != prevState)
        {
            int stateIndex = (int)state;
            print(stateIndex);
            for (int i = 0; i < 4; i++)
            {
                skinHolder.GetChild(i).gameObject.SetActive(false);
            }
            skinHolder.GetChild(stateIndex).gameObject.SetActive(true);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EvolveShift(5);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            EvolveShift(-5);
        }
    }

}

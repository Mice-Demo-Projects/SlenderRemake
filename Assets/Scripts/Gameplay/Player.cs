using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instance;

    #region Variables
    [System.NonSerialized] public Transform skinHolder;
    [System.NonSerialized] public int evolveValue;
    [System.NonSerialized] public EvolveStates state;
    [System.NonSerialized] public int stateIndex;
    [System.NonSerialized] public EvolveStates prevState;
    #endregion
    private void Awake()
    {
        instance = this;
    }
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
        evolveValue = 0;
        stateIndex = 0;
        skinHolder = transform.GetChild(0);
    }
    public void EvolveShift(int amount)
    {
        // Evolve'umuzu etkileyen tüm faktörler bu fonksiyonu çaðýracak.
        prevState = state;
        evolveValue += amount;
        EvolveControl();
        PlayerCanvas.instance.ChangeFillAmount(amount);
        if (InputPanel.instance.holdDetection)
        {
            // Yürürken evolve olma durumunda yeni skin için animasyon tekrar oynatýlýr.
            PlayerAnimation.instance.PlayAnimation("Walk");
        }
    }
    void EvolveControl()
    {
        // Evolve olup olmadýðýmýz, olduysak ne olacaðý kontrol edilecek.
        if (evolveValue < 20)
        {
            state = EvolveStates.Baby;
            SkinSwap(state);
        }
        else if (20 <= evolveValue && evolveValue < 40)
        {
            state = EvolveStates.Freaky;
            SkinSwap(state);
        }
        else if (40 <= evolveValue && evolveValue < 60)
        {
            state = EvolveStates.Horrible;
            SkinSwap(state);
        }
        else if (60 <= evolveValue)
        {
            state = EvolveStates.Monster;
            SkinSwap(state);
        }
    }
    void SkinSwap(EvolveStates state)
    {
        if (state != prevState)
        {
            stateIndex = (int)state;
            print(stateIndex);
            for (int i = 0; i < 4; i++)
            {
                skinHolder.GetChild(i).gameObject.SetActive(false);
                PlayerCanvas.instance.title.GetChild(i).gameObject.SetActive(false);
            }
            skinHolder.GetChild(stateIndex).gameObject.SetActive(true);
            PlayerCanvas.instance.title.GetChild(stateIndex).gameObject.SetActive(true);

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

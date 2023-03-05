using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAnimationEvents : MonoBehaviour
{
    int i = 0;
    public void IncrementaUm()
    {
        i++;
        Debug.Log("Piscou Vermelho: " + i + " vezes!");
    }
}

using System;
using UnityEngine;

public class EventosManager : MonoBehaviour
{
    public static event Action Caiu;
    public static event Action DanoPlayer;

    public static void TriggerCaiu() 
    {
        Caiu?.Invoke();
    }
    public static void TriggerDanoPlayer() 
    {
        DanoPlayer?.Invoke();
    } 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FModEvents : MonoBehaviour
{
    public static FModEvents instance;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [field: Header("Button SFX")]
    [field: SerializeField] public EventReference buttonPressed { get; private set; }

    [field: Header("Ghosts SFX")]
    [field: SerializeField] public EventReference ghostsAppear { get; private set; }

    [field: Header("Music")]
    [field: SerializeField] public EventReference music { get; private set; }


}

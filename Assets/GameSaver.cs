using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaver : MonoBehaviour
{
    private static GameSaver instance;
    public Vector3 lastCheckPiontPos;

    public Player p;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            lastCheckPiontPos = p.transform.position;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}


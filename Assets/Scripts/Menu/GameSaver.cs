using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaver : MonoBehaviour
{
    private static GameSaver instance;
    public Vector3 lastCheckPiontPos;

    public static GameSaver Instance
    {
        get
        {
            if (instance != null)
                return instance;

            instance = GameObject.FindObjectOfType<GameSaver>();
            instance.lastCheckPiontPos = FindObjectOfType<Player>().transform.position;
            DontDestroyOnLoad(instance);

            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        this.enabled = false;
        if (instance == this)
            instance = null;
    }
}


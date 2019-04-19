using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSaver : MonoBehaviour
{
    public GameSaver gs;

    void Start()
    {
        gs = FindObjectOfType<GameSaver>();
        Destroy(gs.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

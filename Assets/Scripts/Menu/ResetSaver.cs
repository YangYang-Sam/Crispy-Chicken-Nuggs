using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSaver : MonoBehaviour
{
    void Start()
    {
        Destroy(GameSaver.Instance.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

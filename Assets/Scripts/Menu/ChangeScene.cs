using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Pickup p;
    public GameObject fade;
    // Start is called before the first frame update
    void Start()
    {
        p = GetComponent<Pickup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (p.isHolding)
        {
            fade.SetActive(true);
        }
    }
}

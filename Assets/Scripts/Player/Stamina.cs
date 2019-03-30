using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    public float Staminas = 100.0f;
    public float MaxStamina = 100.0f;
    //---------------------------------------------------------
    public float StaminaDecreasePerFrame = 20.0f;
    public float StaminaIncreasePerFrame = 25.0f;
    public float StaminaTimeToRegen = 3.0f;
    //---------------------------------------------------------
    public float tiredspeed = 1.0f;
    public CameraShaker cameraShaker;
    public float breathetime = 2.0f;
    public float breathefreq = 8.0f;
    public bool isRunning;

    private PlayerMove player;
    //---------------------------------------------------------
    private float StaminaRegenTimer = 0.0f;
    //---------------------------------------------------------

    private void Start()
    {
        player=GetComponent<PlayerMove>();
        //Debug.Log(player.Print());
    }
    private void Update()
    {
        isRunning = Input.GetKey(KeyCode.LeftShift);
        if (isRunning)
        {
            Staminas = Mathf.Clamp(Staminas - (StaminaDecreasePerFrame * Time.deltaTime), 0.0f, MaxStamina);
            StaminaRegenTimer = 0.0f;
        }
        else if (Staminas < MaxStamina)
        {
            if (StaminaRegenTimer >= StaminaTimeToRegen)
                Staminas = Mathf.Clamp(Staminas + (StaminaIncreasePerFrame * Time.deltaTime), 0.0f, MaxStamina);
            else
                StaminaRegenTimer += Time.deltaTime;
        }
        //control speed
        if (Staminas > 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                player.speed = player.speed * player.speedup;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                player.speed = player.speed / player.speedup;
            }
        }
        if (Staminas==0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                player.speed = tiredspeed;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                if (StaminaRegenTimer < StaminaTimeToRegen)
                {
                    player.speed = 0;
                    StartCoroutine(cameraShaker.Shake(breathetime, breathefreq));
                } 
            }
            if(StaminaRegenTimer >= StaminaTimeToRegen)
            {
                player.speed = player.startspeed;
            }
        }
    }

}

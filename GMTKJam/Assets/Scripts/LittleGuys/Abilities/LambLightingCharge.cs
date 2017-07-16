using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LambLightingCharge : MonoBehaviour {
    public int PlayerNumber;
    public Vector2 aim = new Vector2(0f, 0f);
    public float force;

    public ParticleSystem ps;

    void OnEnable()
    {
        PlayerNumber = gameObject.GetComponent<LittleGuy>().PlayerNumber;
        EventManager.StartListening("Ability1_" + PlayerNumber + "Pressed" , ActivateAB);
        EventManager.StartListening("L_XAxis_" + PlayerNumber, UpdateX);
        EventManager.StartListening("L_YAxis_" + PlayerNumber, UpdateY);
    }

    void OnDisable()
    {
        EventManager.StopListening("Ability1_" + PlayerNumber + "Pressed", ActivateAB);
        EventManager.StopListening("L_XAxis_" + PlayerNumber, UpdateX);
        EventManager.StopListening("L_YAxis_" + PlayerNumber, UpdateY);
    }

    void UpdateX(EventBody eb)
    {
        aim = new Vector2(((AxisEB)eb).value, aim.y).normalized;
    }

    void UpdateY(EventBody eb)
    {
        aim = new Vector2(aim.x, -((AxisEB)eb).value).normalized;
    }

    void ActivateAB(EventBody eb)
    {
        if(gameObject.GetComponent<LittleGuy>().ability1CooldownCurrent <= 0f)
        {
            EventManager.TriggerEvent("Ability1_" + PlayerNumber + "_Triggered", null);
            gameObject.GetComponent<Rigidbody2D>().AddForce(force * aim);
            ps.Stop();
            ps.Play();
        }
    }
}

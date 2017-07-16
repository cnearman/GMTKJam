using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdJump : MonoBehaviour {

    public int PlayerNumber;
    public GameObject av;
    public ParticleSystem ps;
    public float durration;
    public float force;

    void OnEnable()
    {
        PlayerNumber = gameObject.GetComponent<LittleGuy>().PlayerNumber;
        EventManager.StartListening("Ability1_" + PlayerNumber + "Pressed", ActivateAB);
    }

    void OnDisable()
    {
        EventManager.StopListening("Ability1_" + PlayerNumber + "Pressed", ActivateAB);
    }

    void ActivateAB(EventBody eb)
    {
        if (gameObject.GetComponent<LittleGuy>().ability1CooldownCurrent <= 0f)
        {
            EventManager.TriggerEvent("Ability1_" + PlayerNumber + "_Triggered", null);
            GameObject tempAV = (GameObject)Instantiate(av, gameObject.transform.position + new Vector3(0f, -0.18f, 0f), Quaternion.identity);
            tempAV.GetComponent<AttackVolume>().currentTeam = gameObject.GetComponent<LittleGuy>().CurrentTeam;
            tempAV.SetActive(true);
            Destroy(tempAV, durration);
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
            ps.Stop();
            ps.Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDive : MonoBehaviour {

    public int PlayerNumber;
    public GameObject av;
    public ParticleSystem ps;
    public float durration;
    public float force;

    void OnEnable()
    {
        PlayerNumber = gameObject.GetComponent<LittleGuy>().PlayerNumber;
        EventManager.StartListening("Ability2_" + PlayerNumber + "Pressed", ActivateAB);
    }

    void OnDisable()
    {
        EventManager.StopListening("Ability2_" + PlayerNumber + "Pressed", ActivateAB);
    }

    void ActivateAB(EventBody eb)
    {
        if (gameObject.GetComponent<LittleGuy>().ability2CooldownCurrent <= 0f)
        {
            EventManager.TriggerEvent("Ability2_" + PlayerNumber + "_Triggered", null);
            GameObject tempAV = (GameObject)Instantiate(av, gameObject.transform.position, Quaternion.identity, gameObject.transform);
            tempAV.GetComponent<AttackVolume>().currentTeam = gameObject.GetComponent<LittleGuy>().CurrentTeam;
            tempAV.SetActive(true);
            Destroy(tempAV, durration);
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.down * force);
            ps.Stop();
            ps.Play();
        }
    }
}

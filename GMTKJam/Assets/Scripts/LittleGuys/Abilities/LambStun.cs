using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LambStun : MonoBehaviour {

    public int PlayerNumber;
    public GameObject av;
    public ParticleSystem ps;
    public float durration;

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
            GameObject tempAV = (GameObject)Instantiate(av, gameObject.transform.position + new Vector3(0f, -0.18f, 0f), Quaternion.identity, gameObject.transform);
            tempAV.GetComponent<AttackVolume>().currentTeam = gameObject.GetComponent<LittleGuy>().CurrentTeam;
            tempAV.SetActive(true);
            Destroy(tempAV, durration);
            ps.Stop();
            ps.Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetalBlast : MonoBehaviour {

    public int PlayerNumber;
    public Vector2 aim = new Vector2(0f, 0f);
    public float force;
    public float range;

    public GameObject petal;

    void OnEnable()
    {
        PlayerNumber = gameObject.GetComponent<LittleGuy>().PlayerNumber;
        EventManager.StartListening("Ability1_" + PlayerNumber + "Pressed", ActivateAB);
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
        if (gameObject.GetComponent<LittleGuy>().ability1CooldownCurrent <= 0f)
        {
            EventManager.TriggerEvent("Ability1_" + PlayerNumber + "_Triggered", null);

            if (aim == Vector2.zero)
            {
                aim = new Vector2(0f, -1f);
            }


            GameObject petalys = (GameObject)Instantiate(petal, gameObject.transform.position, Quaternion.Euler(0f, 0f, Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg - 90f));
            //Debug.Log(Mathf.Atan2(aim.y, aim.x));
            petalys.GetComponent<Rigidbody2D>().AddForce(force * aim);
            petalys.GetComponent<PetalMove>().currentTeam = gameObject.GetComponent<LittleGuy>().CurrentTeam;
            Destroy(petalys, range);
            gameObject.GetComponent<Rigidbody2D>().AddForce(-force * aim);
        }
    }
}

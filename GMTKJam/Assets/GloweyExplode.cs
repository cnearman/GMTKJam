using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloweyExplode : MonoBehaviour {

    ParticleSystem ps;
    public GameObject attackVolume;
    public Teams team;

    private bool exploding;
    private float duration = 0.1f;
    private float currentLife;

    private void OnEnable()
    {
        ps = GetComponent<ParticleSystem>();
        EventManager.StartListening("GloweyExplode", Explode);
    }

    private void OnDisable()
    {

        EventManager.StopListening("GloweyExplode", Explode);
    }

    private void Update()
    {
        if (exploding)
        {
            currentLife += Time.deltaTime;
            if (currentLife > duration)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Explode(EventBody eb)
    {
        var em = ps.emission;
        var main = ps.main;
        main.startSpeed = 10;
        var collores = ps.colorOverLifetime;
        collores.color = new ParticleSystem.MinMaxGradient(Color.white);
        em.enabled = true;

        em.rateOverTime = 0;
 
        em.SetBursts(
            new ParticleSystem.Burst[]{
                new ParticleSystem.Burst(0.01f, 10, 20, 1, 0.01f)
            });
        em.enabled = false;

        var av = Instantiate(attackVolume, transform.position, Quaternion.identity);
        av.transform.parent = transform;
        av.GetComponent<CircularAttackVolume>().currentTeam = team;
        exploding = true;
    } 

}

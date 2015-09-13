using UnityEngine;
using System.Collections;

public class MiniBomb : Bomb
{
    // Use this for initialization
    protected override void Start()
    {
        bombNormalScale = new Vector3(0.2f, 0.2f, 0.2f);
    }

    public override void Explode()
    {
        GameObject explosionInstance = (GameObject)Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        explosionInstance.transform.localScale *= 0.5f;
        explosionInstance.transform.GetChild(0).GetComponent<ParticleSystem>().startSize *= 0.5f;
        explosionInstance.transform.GetChild(1).GetComponent<ParticleSystem>().startSize *= 0.5f;
        explosionInstance.transform.GetChild(2).GetComponent<ParticleSystem>().startSize *= 0.5f;
        explosionInstance.transform.GetChild(3).GetComponent<ParticleSystem>().startSize *= 0.5f;
        Destroy(gameObject);
        Destroy(explosionInstance, explosionParticle.transform.GetChild(0).GetComponent<ParticleSystem>().duration);
    }

    void OnCollisionEnter(UnityEngine.Collision col) {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Player")
        {
            Explode();
        }
    }
}

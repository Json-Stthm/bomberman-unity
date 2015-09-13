using UnityEngine;
using System.Collections;

public class FragmentBomb : Bomb {

    public int nb_fragments;
    public GameObject miniBomb;
    // Use this for initialization
    protected override void Start () {
        base.Start();
    }

    public override void Explode()
    {
        StartCoroutine("WaitExplode");
    }
    void Tempo() {
        GameObject inst_micro = (GameObject)Instantiate(miniBomb, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        inst_micro.GetComponent<Rigidbody>().AddForce(new Vector3(0, 200, 0));
    }

    IEnumerator WaitExplode() {

        for (int i = 0; i < nb_fragments; i++)
        {
            GameObject inst_micro = (GameObject)Instantiate(miniBomb, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            inst_micro.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-80f, 80f), Random.Range(300, 400), Random.Range(-80f, 80f)));
            yield return new WaitForSeconds(0.01f);
        }
        base.Explode();
    }
}

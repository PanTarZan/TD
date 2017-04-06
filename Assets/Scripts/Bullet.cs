using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;

    public float speed = 10f;
    public GameObject impactEffect;
    public float ExplosionRadius = 0f;

    public void seek(Transform _target)
    {
        target = _target;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distanceThisFrame)
        {
            hitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

        transform.LookAt(target);

	}

    void hitTarget()
    {
        if(ExplosionRadius > 0f)
        {
            Explode();
        }else
        {
            Damage(target);
        }

        //Debug.Log("BOOM");
        GameObject effectins = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
       
        Destroy(effectins, 2f);
        Destroy(gameObject);
        
    }

    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, ExplosionRadius);
        foreach (Collider col in colliders)
        {
            if (col.tag == "Enemy")
            {
                Damage(col.transform);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
    }
}

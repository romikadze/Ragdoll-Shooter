using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    [SerializeField]
    SphereCollider explosionCollider;
    [SerializeField]
    float eplosionForce;
    [SerializeField]
    float radius;
    [SerializeField]
    ParticleSystem explosion;
    bool isRedyToExplode = false;

    IEnumerator DestroyBarrel() {
        explosion.Play();
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //The second hit explodes the barrel
        if (isRedyToExplode)
        {
            explosionCollider.enabled = true;
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            //Rigidbodies to interact with the explosion
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                    rb.AddExplosionForce(eplosionForce, transform.position, radius, 0.5f, ForceMode.Acceleration);
                Controller controller = hit.GetComponent<Controller>();
                if (controller != null)
                    target.GetComponent<Controller>().Dead();
            };
            explosion.transform.position = transform.position;
            StartCoroutine(DestroyBarrel());
        }
        //The first hit destroys joint 
        Destroy(GetComponent<HingeJoint>());
        isRedyToExplode = true;
    }
}

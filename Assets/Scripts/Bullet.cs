using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float lifeTime = 4.0f;
    bool fixedGravity = true;
    void Start()
    {
        StartCoroutine(LifeTime());
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 5, ForceMode.Impulse);
    }

    //Time to live
    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    private void Update()
    {
        //Applying the up force to make the bullet fly forward
        if(fixedGravity)
        GetComponent<Rigidbody>().AddForce(Vector3.up * 7, ForceMode.Acceleration);
    }
    //Disabling the up force
    private void OnCollisionEnter(Collision collision)
    {
        fixedGravity = false;
    }
}

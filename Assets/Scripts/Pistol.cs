using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject direction;
    [SerializeField] string fireButton;
    bool isReadyToShot = true;

    IEnumerator Shot()
    {

        bullet.tag = "Bullet_" + gameObject.tag;
        Instantiate(bullet, direction.transform.position, direction.transform.rotation);
        PistolRecoil();
        yield return new WaitForSeconds(0.15f);
        isReadyToShot = true;
    }

    void Update()
    {//When the pistol is in hand
        if (gameObject.GetComponent<FixedJoint>() != null)
            if (Input.GetButtonDown(fireButton) && isReadyToShot)
            {
                StartCoroutine(Shot());
            }
    }

    //Up and back direction force when shooting
    void PistolRecoil()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.up * 20, ForceMode.Impulse);
        gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * -30, ForceMode.Impulse);
    }
}

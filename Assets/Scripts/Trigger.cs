using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] string _tag;
    int legCount = 2;

    //Destroying an empty collider
    private void Update()
    {

    }

    //Damage calculation, body parts removing
    private void OnTriggerEnter(Collider other)
    {
        //Checking for a friendly bullet
        if (!other.gameObject.CompareTag("Bullet_" + _tag) && other.gameObject.tag.StartsWith("Bullet"))
        {
            Controller controller = GameObject.FindWithTag(_tag).GetComponent<Controller>();
            if (gameObject.CompareTag("Head"))
            {
                controller.Hit(BodyParts.Head);
                Destroy(gameObject);
            }
            if (gameObject.CompareTag("Body"))
            {
                controller.Hit(BodyParts.LArm);
            }
            if (gameObject.CompareTag("Legs"))
            {
                controller.Hit(BodyParts.Legs);
                legCount--;
                if (legCount == 0)
                    Destroy(gameObject);
            }
        }
    }
}

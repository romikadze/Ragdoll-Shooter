using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField]
    Light bulb;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Blinking());
    }

    IEnumerator Blinking()
    {
        yield return new WaitForSeconds(Random.Range(0.1f,0.4f));
        bulb.intensity = Random.Range(0.1f, 2);
        StartCoroutine(Blinking());
    }

    
}

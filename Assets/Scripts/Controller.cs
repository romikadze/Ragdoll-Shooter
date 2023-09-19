using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    [SerializeField]
    GameObject head, lArm, lLeg, rLeg;
    [SerializeField]
    GameObject pistol;
    [SerializeField]
    Rigidbody hips;
    [SerializeField]
    ParticleSystem headBlood, lArmBlood, rLegBlood, lLegBlood;
    GameManager gm;
    public int hitPoints = 100;
    bool rlleg;
    bool larm = true;
    void Awake()
    {
        rlleg = (Random.value > 0.5f);
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Dead();
        }
    }
    public void Hit(BodyParts part)
    {
        switch (part)
        {
            case BodyParts.Head:
                headBlood.Play();

                gameObject.transform.Find("ActiveParts").Find("PT_Medieval_Skeleton_01_Skull").gameObject.SetActive(false);
                head.SetActive(false);
                Damage(50);
                break;
            case BodyParts.LArm:
                if (larm)
                {
                    lArmBlood.Play();

                    gameObject.transform.Find("ActiveParts").Find("PT_Medieval_Skeleton_01_LArm").gameObject.SetActive(false);
                    lArm.SetActive(false);
                    Damage(15);
                    larm = false;
                }
                else
                    Damage(5);
                break;
            case BodyParts.Legs:
                if (rlleg)
                {
                    rLegBlood.Play();

                    gameObject.transform.Find("ActiveParts").Find("PT_Medieval_Skeleton_01_RLeg").gameObject.SetActive(false);
                    rLeg.SetActive(false);
                }
                else
                {
                    lLegBlood.Play();

                    gameObject.transform.Find("ActiveParts").Find("PT_Medieval_Skeleton_01_LLeg").gameObject.SetActive(false);
                    lLeg.SetActive(false);
                }
                rlleg = !rlleg;
                Damage(10);
                break;
        }
    }

    public void Damage(int hp)
    {
        hitPoints -= hp;
        if (hitPoints <= 0)
            Dead();
    }

    public void Dead()
    {
        hips.freezeRotation = false;
        hips.constraints &= ~RigidbodyConstraints.FreezePositionX;
        hips.constraints &= ~RigidbodyConstraints.FreezePositionZ;
        pistol.GetComponent<Rigidbody>().freezeRotation = false;
        pistol.GetComponent<Rigidbody>().AddTorque(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
        Destroy(pistol.GetComponent<FixedJoint>());
        if (gameObject.CompareTag("Player"))
            gm.ChangeGameState(GameManager.GameStates.Over);
        else
            gm.ChangeGameState(GameManager.GameStates.Win);
    }
}
public enum BodyParts
{
    Head,
    LArm,
    Legs
}

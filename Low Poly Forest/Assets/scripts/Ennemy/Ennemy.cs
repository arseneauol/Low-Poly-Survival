using UnityEngine;
using System.Collections;

public class Ennemy : MonoBehaviour
{
    [SerializeField]
    float maxStamina;
    [SerializeField]
    float runSpeed;
    [SerializeField]
    float walkSpeed;
    [SerializeField]
    int maxhealt;
    [SerializeField]
    float timeUpdateNavDestination = 0.3F;
    float stamina;
    int curentHealt;
    int ennemyBehaviour;
    float curentColdownUpdateNavDestination;
    float distancePlayer;
    bool canRun;// permette de ne pas le fair courire pour une seul frame
    Transform playerTransform;
    NavMeshAgent myNavMeshAgent;
    Transform myTransform;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        myNavMeshAgent = this.GetComponent<NavMeshAgent>();
        myTransform = this.transform;
        curentHealt = maxhealt;
    }
    void Update()
    {
        setBehaviour();
        restriction();


    }
    void setBehaviour()//défini le comportement du monstre
    {
        distancePlayer = (myTransform.position - playerTransform.position).magnitude;
        if (myNavMeshAgent.pathStatus == NavMeshPathStatus.PathComplete) // vérifi si il y a un un chemain
        {
            if (distancePlayer > 4 && stamina > 0 && canRun)//comportement course
            {
                Debug.Log(" test");
                ennemyBehaviour = 2;
            }
            else if (distancePlayer < 1 && curentHealt < 0.10f * maxhealt) // comportement attack forte si la vie est a 10%
                ennemyBehaviour = 4;
            else if (distancePlayer < 1) // comportement attack normal
                ennemyBehaviour = 3;
            else
            {
                ennemyBehaviour = 1;// comportement marche
                canRun = false;
            }
        }
        else
        {
            Debug.Log("path not found");
            ennemyBehaviour = 0; // états idle
        }
        doBehaviour();
    }
    void doBehaviour() // applique le comportement au monstre
    {
        switch (ennemyBehaviour)
        {
            case 1://marche
                myNavMeshAgent.speed = walkSpeed;
                stamina += (Time.deltaTime / 4);
                setPath();
                break;
            case 2://course
                myNavMeshAgent.speed = runSpeed;
                stamina -= Time.deltaTime;
                setPath();
                break;
            case 3:// attack normal
                attack();
                stamina += (Time.deltaTime / 4);
                break;
            case 4:// attaque forte
                attack();
                stamina += (Time.deltaTime / 4);
                break;

        }
    }
    void setPath() // définis la position ou l'ennemy doit se diriger
    {
        if (Time.time - curentColdownUpdateNavDestination >= timeUpdateNavDestination)// pertmet de calculer moin souvent le path pour économise ressource
        {
            curentColdownUpdateNavDestination = Time.time;
            myNavMeshAgent.SetDestination(playerTransform.position);
        }
    }
    void attack() // attaque le joueur
    {
        // a définir avec le nouveaux controlleur
    }
    void restriction() // applique les réstriction au variable
    {
        if (stamina > maxStamina)
        {
            stamina = maxStamina;
        }
        if (stamina > 0.50 * maxStamina) // vérifie si l'ennemy peut courrire
        {
            canRun = true;
        }

    }
    void ApplyDammage(int dommage)
    {
        curentHealt = -dommage;
        if (curentHealt <= 0)
            Destroy(this.gameObject);
    }
}
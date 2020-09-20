using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class EnemyController : MonoBehaviour
{

    public Transform central;

    private NavMeshAgent agent;
    float radius = 3f;
    float waitTime = 5f;
    float time = 0;

    Animator anim;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        agent.autoBraking = false;
        agent.updateRotation = false;

        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        agent.isStopped = false;
        anim.SetBool("run", true);

        float posX = Random.Range(-1 * radius, radius);
        float posZ = Random.Range(-1 * radius, radius);

        pos = central.position;
        pos.x += posX;
        pos.z += posZ;

        Vector3 direction = new Vector3(pos.x, transform.position.y, pos.z);

        Quaternion rotation =
            Quaternion.LookRotation(direction - transform.position, Vector3.up);

        transform.rotation = rotation;

        agent.destination = pos;

        Debug.Log("Goto OK");

    }

    void StopHere()
    {
        agent.isStopped = true;
        time += Time.deltaTime;

        if(time > waitTime)
        {
            GotoNextPoint();
            time = 0;
        }

        anim.SetBool("run", false);
        Debug.Log("StopHere OK");
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            StopHere();
        Debug.Log(agent.remainingDistance);
    }
}

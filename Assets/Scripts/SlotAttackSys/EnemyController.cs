using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public GameObject target = null;  // 攻击目标
    float pathTime = 0f;
    int slot = -1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        pathTime += Time.deltaTime;
        if(pathTime > 0.5f)
        {
            pathTime = 0f;
            /*
            Vector3 targetPos = target.transform.position;  // 攻击目标的世界坐标
            Vector3 offset = (this.transform.position - targetPos).normalized * keepGap;

            this.GetComponent<NavMeshAgent>().destination = targetPos + offset;
            */
            SlotManager slotManager = target.GetComponent<SlotManager>();
            if(slotManager != null)
            {
                if (slot == -1)
                    slot = slotManager.Reserve(gameObject);
                if (slot == -1)
                    return;

                NavMeshAgent agent = this.GetComponent<NavMeshAgent>();
                if (agent == null)
                    return;

                agent.destination = slotManager.GetSlotPosition(slot);
            }
        }
	}
}

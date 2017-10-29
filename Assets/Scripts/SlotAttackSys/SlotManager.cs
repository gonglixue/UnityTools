using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour {
    List<GameObject> slots;
    public int count = 6;
    public float distance = 1f;

	// Use this for initialization
	void Start () {
        slots = new List<GameObject>();
        for(int i = 0; i < count; i++)
        {
            slots.Add(null);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector3 GetSlotPosition(int index)
    {
        float degrresPerIndex = 360f / count;
        Vector3 pos = transform.position;
        Vector3 offset = new Vector3(0, 0, distance);

        return pos + (Quaternion.Euler(new Vector3(0, degrresPerIndex * index, 0f)) * offset);
    }

    // 为攻击者设置一个slot
    public int Reserve(GameObject attacker)
    {
        Vector3 bestPosition = transform.position;
        Vector3 offset = (attacker.transform.position - bestPosition).normalized;
        bestPosition += offset*distance;  // 不用slot时的位置
        int bestSlot = -1;
        float bestDist = 9999f;
        for(int i=0;i<slots.Count; i++)
        {
            if (slots[i] != null)
                continue;

            float dist = (GetSlotPosition(i) - bestPosition).sqrMagnitude;
            if(dist < bestDist) // 在所有slots里找出离bestPosition最近的那个空闲slot
            {
                bestSlot = i;
                bestDist = dist;
            }
        }

        if (bestSlot != -1)
            slots[bestSlot] = attacker;

        return bestSlot;
    }

    public void Release(int slot)
    {
        slots[slot] = null;
    }

    void OnDrawGizmosSelected()
    {
        for(int i=0;i<count;i++)
        {
            if (slots == null || slots.Count <= i || slots[i] == null)
                Gizmos.color = Color.black;
            else
                Gizmos.color = Color.red;

            Gizmos.DrawWireSphere(GetSlotPosition(i), 0.5f);
        }
    }
}

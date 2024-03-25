using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionGenerator : MonoBehaviour
{
    public GameObject[] colliders;
    private void OnClear()
    {
        foreach(var item in colliders)
        {
            item.SetActive(false);
        }
    }
    public void OnColliderClick(int id)
    {
        OnClear();

        switch (id)
        {
            case 0;
                OnBoxCollider();
                break;
                case 1;
                On
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

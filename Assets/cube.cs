using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    private void Awake()
    {
        EventCenterManager.Instance.AddListener("开工",Write);
    }

    public void Write()
    {
        transform.position += Vector3.right;
        Debug.Log("我是策划，我在写策划案");
    }

    private void OnDestroy()
    {
        EventCenterManager.Instance.RemoveListener("开工", Write);
    }
}

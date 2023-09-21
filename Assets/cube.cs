using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    private void Awake()
    {
        EventCenterManager.Instance.AddListener("����",Write);
    }

    public void Write()
    {
        transform.position += Vector3.right;
        Debug.Log("���ǲ߻�������д�߻���");
    }

    private void OnDestroy()
    {
        EventCenterManager.Instance.RemoveListener("����", Write);
    }
}

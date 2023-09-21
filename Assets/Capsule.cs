using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    private void Awake()
    {
        EventCenterManager.Instance.AddListener("����", Draw);
    }
    public void Draw()
    {
        transform.Rotate(Vector3.forward, 5f);
        Debug.Log("�������������ڻ���");
    }

    private void OnDestroy()
    {
        EventCenterManager.Instance.RemoveListener("����", Draw);
    }
}

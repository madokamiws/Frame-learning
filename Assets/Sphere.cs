using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    private void Awake()
    {
        EventCenterManager.Instance.AddListener("����", Code);
    }

    public void Code()
    {
        transform.localScale += new Vector3(1, 0, 0);
        Debug.Log("���ǳ�������д����");
    }
    private void OnDestroy()
    {
        EventCenterManager.Instance.RemoveListener("����", Code);
    }
}

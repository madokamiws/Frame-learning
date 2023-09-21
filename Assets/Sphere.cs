using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    private void Awake()
    {
        EventCenterManager.Instance.AddListener("开工", Code);
    }

    public void Code()
    {
        transform.localScale += new Vector3(1, 0, 0);
        Debug.Log("我是程序，我在写代码");
    }
    private void OnDestroy()
    {
        EventCenterManager.Instance.RemoveListener("开工", Code);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR
public class SceneTest
{
    [MenuItem("�ҵĲʵ�/����1")]
    static void Method1()
    {
        LoadSceneManager.Instance.LoadActiveScene();
    }
    [MenuItem("�ҵĲʵ�/����2")]
    static void Method2()
    {

        LoadSceneManager.Instance.LoadNextScene(true);
    }
    [MenuItem("�ҵĲʵ�/����3")]
    static void Method3()
    {

    }
    [MenuItem("�ҵĲʵ�/�첽�л�������1")]
    static void Method4()
    {

        LoadSceneManager.Instance.LoadSceneAsync(0,(obj)=>
        {
            Debug.Log("���ؽ����ǣ�" + obj * 100 + "%");
        },(obj2)=>
        {
            Debug.Log("��������ˣ�");
        });
    }



}
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class LoadSceneManager : SingletonPatternBase<LoadSceneManager>
{
    /// <summary>
    /// �л�����ǰ����
    /// </summary>
    public void LoadActiveScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    /// <summary>
    /// �л�����һ������
    /// </summary>
    public void LoadNextScene( bool isCyclical = false)
    {
        int xx = SceneManager.GetActiveScene().buildIndex + 1;
        if (xx > SceneManager.sceneCountInBuildSettings - 1)
        {
            if (isCyclical)
            {
                xx = 0;
            }
            else
            {
                return;
            }

        }
        SceneManager.LoadScene(xx);

    }
    //public void LoadSceneAsync(string sceneName, UnityAction completed = null, LoadSceneMode mode = LoadSceneMode.Single)
    //{
    //    MonoManager.Instance.StartCoroutine(LoadSceneCoroutine(sceneName, completed, mode));
    //}
    //IEnumerator LoadSceneCoroutine(string sceneName, UnityAction completed = null, LoadSceneMode mode = LoadSceneMode.Single)
    //{
    //    AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, mode);
    //    yield return asyncOperation;//�ȴ���Դ�������
    //    completed?.Invoke();
    //}

    /// <summary>
    /// <para>�첽���س�����Ĭ������£��ɹ����س����󣬻��л����ó�����</para>
    /// <para>���Կ����ⲿ����������ʾ��</para>
    /// </summary>
    /// <param name="sceneBuildIndex">Ҫ���صĳ�����Build Settings�����е�������</param>
    /// <param name="loading">�����еĻص���ֻҪ�ڼ����У��ͻ᲻�ϵ�ִ������ص���һ�����ڽ���������ʾ��</param>
    /// <param name="completed">������Ϻ�Ļص���</param>
    /// <param name="setActiveAfterCompleted">���س�����Ϻ��Ƿ��л����ó�����</param>
    /// <param name="mode">���س�����ģʽ��Ĭ����LoadSceneMode.Single����ʾ��ж��ԭ���ĳ��������л����³�����LoadSceneMode.Additive��ʾ�Ὣ�³���������ԭ���ĳ����С�</param>
    public void LoadSceneAsync(int sceneBuildIndex, UnityAction<float> loading = null, UnityAction<AsyncOperation> completed = null, bool setActiveAfterCompleted = true, LoadSceneMode mode = LoadSceneMode.Single)
    {
        ////���Ҫ���صĳ������������Ϸ����򷵻ء�
        //if (!IsSceneBuildIndexValid(sceneBuildIndex))
        //    return;

        //����Э�̽����첽���ء�
        MonoManager.Instance.StartCoroutine(LoadSceneAsyncCoroutine(sceneBuildIndex, loading, completed, setActiveAfterCompleted, mode));
    }
    IEnumerator LoadSceneAsyncCoroutine(int sceneBuildIndex, UnityAction<float> loading = null, UnityAction<AsyncOperation> completed = null, bool setActiveAfterCompleted = true, LoadSceneMode mode = LoadSceneMode.Single)
    {
        //�첽�������󣬼�¼���첽���������ݡ�
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneBuildIndex, mode);

        //����Ϊfalse����ʹ����������ϣ�Ҳ�����л���ȥ��������������ϣ��ٴΰ����ֵ����Ϊtrue���Ż��л���ȥ��
        asyncOperation.allowSceneActivation = false;

        //���س����Ĺ����У��ṩ���ⲿִ�еĻص���һ�����ڽ���������ʾ��
        while (asyncOperation.progress < 0.9f)
        {
            loading?.Invoke(asyncOperation.progress);
            yield return null;
        }

        //��asyncOperation.allowSceneActivationΪfalse����asyncOperation.progress���ֻ�ܵ���0.9��������Ϊ�����ճ�����1�������ⲿ����������ʾ��
        loading?.Invoke(1f);

        //���س������֮������������������Ϊtrue������л����ó��������Ϊfalse���򲻻��л����ó�����
        asyncOperation.allowSceneActivation = setActiveAfterCompleted;

        //���س������֮��ִ�еĻص���
        completed?.Invoke(asyncOperation);
    }
}

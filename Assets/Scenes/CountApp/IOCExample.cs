using UnityEngine;

namespace FrameworkDesign.Example
{
    public class IOCExample : MonoBehaviour
    {
        void Start()
        {
            // ����һ�� IOC ����
            var container = new IOCContainer();

            // ע��һ��������������ʵ��
            container.Register(new BluetoothManager());

            // �������ͻ�ȡ������������ʵ��
            var bluetoothManager = container.Get<BluetoothManager>();

            //��������
            bluetoothManager.Connect();
        }

        public class BluetoothManager
        {
            public void Connect()
            {
                Debug.Log("�������ӳɹ�");
            }
        }
    }
}

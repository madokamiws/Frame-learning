using FrameworkDesign;

namespace FrameworkDesign
{
    public class CounterApp
    {
        private static IOCContainer mContainer = null;

        // ȷ�� Container ����ʵ����
        static void MakeSureContainer()
        {
            if (mContainer == null)
            {
                mContainer = new IOCContainer();
                Init();
            }
        }

        // ����ע��ģ��
        private static void Init()
        {
            mContainer.Register(new CounterModel());
        }

        // �ṩһ����ȡģ��� API
        public static T Get<T>() where T : class
        {
            MakeSureContainer();
            return mContainer.Get<T>();
        }
    }
}

using FrameworkDesign;

namespace FrameworkDesign
{
    public class CounterApp
    {
        private static IOCContainer mContainer = null;

        // 确保 Container 是有实例的
        static void MakeSureContainer()
        {
            if (mContainer == null)
            {
                mContainer = new IOCContainer();
                Init();
            }
        }

        // 这里注册模块
        private static void Init()
        {
            mContainer.Register(new CounterModel());
        }

        // 提供一个获取模块的 API
        public static T Get<T>() where T : class
        {
            MakeSureContainer();
            return mContainer.Get<T>();
        }
    }
}

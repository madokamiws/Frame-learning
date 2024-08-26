namespace FrameworkDesign
{
    public interface ICommand
    {
        // Start is called before the first frame update
        void Execute();


    }
}
///这里只需要记住一点，Command 模式就是逻辑的调用和执行是分离的，我们知道一个方法的调用和执行是不分离的，因为一旦你调用方法了，方法也就执行了，
///而 Command 模式能够做到调用和执行在空间和时间上是能分离的。
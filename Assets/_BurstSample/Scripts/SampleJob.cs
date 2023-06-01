using Unity.Collections;
using Unity.Jobs;

namespace _BurstSample.Scripts
{
    public struct SampleJob : IJob
    {
        public int num;
        public NativeArray<int> result;

        public void Execute()
        {
            for (int i = 0; i < 10000; i++)
            {
                result[0] += num;
            }
        }
    }
}
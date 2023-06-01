using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace _BurstSample.Scripts.JobSample
{
    [BurstCompile]
    public struct SampleJob : IJob
    {
        public int num;
        public NativeArray<int> result;
 
        public void Execute() {
            //　100回足す
            for (int i = 0; i < 100; i++) {
                result[0] += num;
            }
        }
    }
}
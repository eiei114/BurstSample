using _BurstSample.Scripts;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;


public class SampleJobBehaviour : MonoBehaviour
{
    private void Start()
    {
        var numberOfAdd = 1000;

        var resultMemory = new NativeArray<int>(1, Allocator.TempJob);

        var job = new SampleJob
        {
            num = numberOfAdd,
            result = resultMemory
        };
        
        JobHandle jobHandle = job.Schedule();
        
        jobHandle.Complete();
        
        float resultNum = resultMemory[0];
        
        Debug.Log($"Result: {resultNum}");
        
        resultMemory.Dispose();
    }
}
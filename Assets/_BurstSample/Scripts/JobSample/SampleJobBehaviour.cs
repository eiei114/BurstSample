using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace _BurstSample.Scripts.JobSample
{
    public class SampleJobBehaviour : MonoBehaviour
    {
        private void Start() {
            //　足す数字
            var numberOfAdd = 2;
            //　NativeArrayの割り当て
            var resultMemory = new NativeArray<int>(1, Allocator.TempJob);
            //　Jobの作成と初期化子を使ってジョブに変数を設定
            var myJob = new SampleJob() {
                num = numberOfAdd,
                result = resultMemory
            };
            //　ジョブのスケジューリング
            JobHandle myJobHandle = myJob.Schedule();
            //　ジョブの終了を待つ
            myJobHandle.Complete();
            //　ジョブの結果を変数に入れる
            float resultNum = resultMemory[0];
            //　コンソールに結果を表示
            Debug.Log(resultNum);
            //　NativeArrayをメモリから解放する
            resultMemory.Dispose();
        }
    }
}
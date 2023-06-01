using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.UI;

namespace _BurstSample.Scripts
{
    public class InstantiateJobBehaviour : MonoBehaviour
    {
        //　インスタンス化するプレハブ
        [SerializeField]
        private GameObject prefab;
        //　一度にインスタンス化する数
        [SerializeField]
        private int numberToInstantiate = 100;
        //　トータルでインスタンス化した数
        private int total;
        //　インスタンス化した数の表示テキスト
        [SerializeField]
        private Text totalText;
        [SerializeField]
        private Text fpsText;
        //　ゲームオブジェクトのTransformの共有メモリ
        private TransformAccessArray transforms;
        //　ジョブハンドル
        private JobHandle jobHandle;
 
 
        private void OnDisable() {
            //　ゲームオブジェクトが非アクティブになったらジョブの終了を待ってメモリ開放
            jobHandle.Complete();
            transforms.Dispose();
        }
        private void Start()
        {
            //　オブジェクトのTransformをまとめる特殊な配列を作成
            transforms = new TransformAccessArray(0);
        }
 
        private void Update()
        {
            // FPSの表示
            fpsText.text = (1f / Time.deltaTime).ToString();
            
            //　ジョブの終了を待つ
            jobHandle.Complete();
 
            //　スペースキーを押したら生成
            if (Input.GetKeyDown(KeyCode.Space)) {
                InstantiateGameObject();
            }
            //　ジョブの生成
            var myParallelJobTransform = new MoveJob() {
                //　ジョブ内ではTime.deltaTimeを使えないのでジョブを作成した時にTime.deltaTimeを渡す
                deltaTime = Time.deltaTime,
                speed = 2f,
            };
            //　ジョブのスケジューリング
            jobHandle = myParallelJobTransform.Schedule(transforms);
        }
        
        //　ゲームオブジェクトのインスタンス化
        private void InstantiateGameObject() {
            jobHandle.Complete();
 
            //　TransformAccessArrayの容量をインスタンス化する数だけ増やす
            transforms.capacity += numberToInstantiate;
            //　UnityEngine.Random.Rangeで1～100のランダム値を使ってUnity.Mathematics.Randomのシードを作成
            Unity.Mathematics.Random rand;
            rand = new Unity.Mathematics.Random((uint)UnityEngine.Random.Range(1f, 100f));
 
            //　numberToInstantiate数分をインスタンス化し、transformsに足す
            for (int i = 0; i < numberToInstantiate; i++) {
                var ins = Instantiate(prefab, new float3(rand.NextFloat(-20f, 20f), 50f, 0f), quaternion.identity);
                transforms.Add(ins.transform);
            }
            //　数の表示
            total += numberToInstantiate;
            totalText.text = total.ToString();
        }
    }
}
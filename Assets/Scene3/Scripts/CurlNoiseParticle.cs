using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine.Assertions;
using Random = System.Random;

namespace CurlNoise
{
    public class CurlNoiseParticle : MonoBehaviour
    {
        struct Params
        {
            Vector3 emitPos;
            Vector3 position;
            Vector3 life;
            Vector3 size;
            Vector4 color;
            Vector4 startColor;
            Vector4 endColor;

            public Params(Vector3 emitPos, Vector3 pos, float lifeTime, float startSize, float endSize, Color start, Color end)
            {
                this.emitPos = emitPos;
                this.position = pos;
                this.life = new Vector3(0f, lifeTime, 1.0f);//x:elapsedTime. y:lifeTime, z:Active or Die
                this.size = new Vector3(0.0f, startSize, endSize);
                this.color = Color.white;
                this.startColor = start;
                this.endColor = end;
            }
        }


        public struct GPUThreads
        {
            public int x;
            public int y;
            public int z;

            public GPUThreads(uint x, uint y, uint z)
            {
                this.x = (int) x;
                this.y = (int) y;
                this.z = (int) z;
            }
        }

        [Serializable]
        public struct Colors
        {
            public Color startColor;
            public Color endColor;
        }

        [Serializable]
        public struct Sizes
        {
            [Range(0f, 10f)] public float startSize;
            [Range(0f, 10f)] public float endSize;
        }

        [Serializable]
        public struct Lives
        {
            [Range(0f, 60f)] public float minLife;
            [Range(0f, 60f)] public float maxLife;
        }

        #region variables

        private enum ComputeKernels
        {
            Emit,
            Iterator
        }

        #endregion

        private Dictionary<ComputeKernels, int> kernelMap = new Dictionary<ComputeKernels, int>();
        private GPUThreads gpuThreads;

        [SerializeField] int instanceCount = 100000;
        [SerializeField] Mesh instanceMesh;
        [SerializeField] Material instanceMaterial; //<---DMII
        [SerializeField] ComputeShader computeShader;
        [SerializeField] List<Sizes>  sizes  = new List<Sizes>();
        [SerializeField] List<Colors>  colors  = new List<Colors>();
        


        private ComputeShader computeShaderInstance;
        private int cachedInstanceCount = -1;
        private ComputeBuffer cBuffer;
        private ComputeBuffer argsBuffer; //<---DMII
        private uint[] args = new uint[5] {0, 0, 0, 0, 0};
        private Renderer render;
        private float timer = 0f;
        private Vector2 times;

        private int SubMeshIndex = 0; //<---DMII
        private Bounds bounds; //<---DMII




        private int bufferPropId;
        private int timesPropId;
        private int lifePropId;
        private int modelMatrixPropId;



        private void Initialize()
        {
            bounds = new Bounds(Vector3.zero, new Vector3(100, 100, 100));
            computeShaderInstance = computeShader;

            render = GetComponent<Renderer>();

            uint threadX, threadY, threadZ;



            //FindKernel:Emit,Iterator
            kernelMap = System.Enum.GetValues(typeof(ComputeKernels))
                .Cast<ComputeKernels>()
                .ToDictionary(t => t, t => computeShaderInstance.FindKernel(t.ToString()));

            computeShaderInstance.GetKernelThreadGroupSizes(kernelMap[ComputeKernels.Emit], out threadX, out threadY,
                out threadZ);
            gpuThreads = new GPUThreads(threadX, threadY, threadZ);
            argsBuffer = new ComputeBuffer(1, args.Length * sizeof(uint), ComputeBufferType.IndirectArguments);


            //---Vertex,FragmentShader
            bufferPropId = Shader.PropertyToID("buf");
            timesPropId = Shader.PropertyToID("timer");
            lifePropId = Shader.PropertyToID("lifeTime");
            modelMatrixPropId = Shader.PropertyToID("modelMatrix");
            //---


            UpdateBuffers();

        }

        private void Update()
        {
            
            timer += Time.deltaTime;
            if (timer < 1.5)
            {
                return;
            }
            
            times.x = Time.deltaTime;
            times.y = Time.realtimeSinceStartup;

            //if (timer <= idleTime) return; // just for idling

            if (cachedInstanceCount != instanceCount)
                UpdateBuffers();


            //<------SubShader----------->
            instanceMaterial.SetPass(0);
            //StructuredBuffer<Params> buf;
            instanceMaterial.SetBuffer(bufferPropId, cBuffer);
            //matrixの転送
            //This property MUST be used instead of Transform.localToWorldMatrix, if you're setting shader parameters.
            var render = GetComponent<Renderer>();
            instanceMaterial.SetMatrix(modelMatrixPropId, render.localToWorldMatrix);
            instanceMaterial.SetFloat(timesPropId, timer);
            //<-------------------------->


            //<------ComputeShader----------->
            computeShader.SetVector("times", times);
            computeShaderInstance.SetBuffer(kernelMap[ComputeKernels.Emit], bufferPropId, cBuffer);
            computeShaderInstance.Dispatch(kernelMap[ComputeKernels.Emit], Mathf.CeilToInt((float)instanceCount / (float)gpuThreads.x), gpuThreads.y, gpuThreads.z);

            computeShaderInstance.SetBuffer(kernelMap[ComputeKernels.Iterator], bufferPropId, cBuffer);
            computeShaderInstance.Dispatch(kernelMap[ComputeKernels.Iterator], Mathf.CeilToInt((float)instanceCount / (float)gpuThreads.x), gpuThreads.y, gpuThreads.z);
            //computeShaderInstance.setBuffer
            
            //Render
            Graphics.DrawMeshInstancedIndirect(instanceMesh, SubMeshIndex, instanceMaterial, bounds, argsBuffer);
        }

        private void Start()
        {
            Initialize();
        }

        void UpdateBuffers()
        {
            if (cBuffer != null)
                cBuffer.Release();

            cBuffer = new ComputeBuffer(instanceCount, Marshal.SizeOf(typeof(Params)));
            Params[] parameters = new Params[cBuffer.count];

            for (int i = 0; i < instanceCount; i++)
            {
                var pos = UnityEngine.Random.insideUnitSphere * 15.0f;
                var lifeTime = 5.0f;
                var size = sizes[UnityEngine.Random.Range(0, sizes.Count)];
                var color = colors[UnityEngine.Random.Range(0, colors.Count)];

                parameters[i] = new Params(UnityEngine.Random.insideUnitSphere, pos, lifeTime,size.startSize,size.endSize, color.startColor, color.endColor);
            }

            cBuffer.SetData(parameters);
            uint numIndices = (instanceMesh != null) ? (uint) instanceMesh.GetIndexCount(0) : 0;
            args[0] = numIndices;
            args[1] = (uint) instanceCount;
            argsBuffer.SetData(args);
            cachedInstanceCount = instanceCount;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

namespace flat_land.runner
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] Chunk[] chunks = new Chunk[10];
        [SerializeField] List<GameObject> chunksPrefabs = new List<GameObject>();

        [SerializeField] int nextChunckIndexCursor = 4;

        [SerializeField] float ScrollSpeed = 10f;


        private void Awake()
        {
            chunks.ToList().ForEach(chunk =>
            {
                if (chunk != null)
                {
                    BindChunkEvent(chunk);
                }
            });
        }

        private void Update()
        {
            Vector3 translation = -Vector3.right * ScrollSpeed * Time.deltaTime;
            transform.position = transform.position + translation;
        }

        private void BindChunkEvent(Chunk chunk)
        {
            chunk.onPLayerEnterChunk += () => LoadANewChunk(chunk.End);
        }

        private void LoadANewChunk(Transform end)
        {
            GameObject selectedChunk = SelectAChunk();
            if (selectedChunk != null)
            {
                GameObject chunkGo = Instantiate(selectedChunk, transform);
                BindNextChunk(chunkGo, end);
                SetNextChunkIndex();
            }
        }

        private void BindNextChunk(GameObject chunkGo, Transform end)
        {
            chunks[nextChunckIndexCursor] = chunkGo.GetComponent<Chunk>();
            chunks[nextChunckIndexCursor].SetPosition(end);
            BindChunkEvent(chunks[nextChunckIndexCursor]);
        }

        private void SetNextChunkIndex()
        {
            nextChunckIndexCursor++;
            if (nextChunckIndexCursor >= chunks.Length)
            {
                nextChunckIndexCursor = 0;
                DeleteAnOldChunk();
            }
            DeleteAnOldChunk(IndexTenPeriodique());
        }

        private int IndexTenPeriodique()
        {
            int next = nextChunckIndexCursor - 2;
            if (next < 0)
            {
                return next + 9;
            }
            return next;
        }

        private void DeleteAnOldChunk(int index = 0)
        {
            if (chunks[index] != null || chunks[nextChunckIndexCursor] != null)
            {
                Destroy(chunks[nextChunckIndexCursor].gameObject);
            }
        }

        private GameObject SelectAChunk()
        {
            return chunksPrefabs[UnityEngine.Random.Range(0, chunksPrefabs.Count)];
        }
    }
}


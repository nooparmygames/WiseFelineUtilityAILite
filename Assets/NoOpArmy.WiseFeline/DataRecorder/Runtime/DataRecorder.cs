using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Linq;
using UnityEngine.Rendering;
using Codice.Client.BaseCommands.BranchExplorer;
using System;

namespace NoOpArmy.WiseFeline.DataRecorder
{
    public class DataRecorder : MonoBehaviour
    {
        public List<Record> records { get; private set; } = new List<Record>();

        private void Start()
        {
            if (!Application.isEditor && !Debug.isDebugBuild)
            {
                Destroy(this);
                return;
            }
            else
            {
                RecordManager.Instance.AddDataRecorder(this);
            }
        }

        private void OnDestroy()
        {
            records?.Clear();
            if (!Debug.isDebugBuild)
                RecordManager.Instance?.RemoveDataRecorder(this);
        }

        public void AddSubRecord(SubRecord subRecord, int index)
        {
            //print(RecordManager.Instance.ShouldRecord);
            if (!RecordManager.Instance.ShouldRecord)
                return;
                if (index >= 0 && index < records.Count)
                {
                    var rec = records[index];
                    if (rec != null)
                    {
                        subRecord.record = rec;
                        rec.subRecords.Add(subRecord);
                    }
                }
        }

        public int GetCurrentFrameRecord()
        {
            Record record = new Record();
            if (records.Count == 0 || records[records.Count - 1].frameCount != Time.frameCount)
            {
                record.go = this.gameObject;
                record.id = record.go.GetInstanceID();
                record.frameTime = Time.time;
                record.frameCount = Time.frameCount;
                records.Add(record);
            }
            return records.Count - 1;
        }

        public void RemoveRecord(Record record)
        {
            records.Remove(record);
        }

        public void ClearRecords()
        {
            records.Clear();
        }

        public void AddShape(Shape shape, int index)
        {
            if (!RecordManager.Instance.ShouldRecord)
                return;
            if (index >= 0 && index < records.Count)
            {
                var rec = records[index];
                if (rec != null)
                {
                    rec.shapes.Add(shape);
                }
            }
        }
    }

    /// <summary>
    /// Each record holds all textual and shape information for a frame of a specific data recorder component
    /// </summary>
    public class Record
    {
        public List<SubRecord> subRecords;
        public GameObject go;
        public long id;
        public int frameCount;
        public float frameTime;
        public List<Shape> shapes;

        public Record()
        {
            subRecords = new List<SubRecord>();
            shapes = new List<Shape>();
        }

        public Record(string name, GameObject go, long id, int frameCount, float frameTime)
        {
            this.go = go;
            this.id = id;
            this.frameCount = frameCount;
            this.frameTime = frameTime;
            this.subRecords = new List<SubRecord>();
            this.shapes = new List<Shape>();
        }
    }

    public class SubRecord
    {
        public int indentationLevel;
        public string text;
        public Record record;
    }

    public struct Shape
    {
        public float size;
        public Color color;
        public ShapeType Type;
        public Vector3 position;
    }

    public enum ShapeType : byte
    {
        Sphere,
        Cube,
        WiredSphere,
        WiredCube
    }
}
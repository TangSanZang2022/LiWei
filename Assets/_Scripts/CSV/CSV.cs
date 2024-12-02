using UnityEngine;
using System.IO;
using System.Collections.Generic;
namespace CSVTool
{
    /// <summary>
    /// 读取CSV文件工具类
    /// </summary>
    public class CSV
    {
        static CSV csv;
        public List<string[]> m_ArrayData;
        /// <summary>
        /// 当读取多个文件时使用
        /// </summary>
        public Dictionary<string, List<string[]>> m_DictData;
        public static CSV GetInstance()
        {
            if (csv == null)
            {
                csv = new CSV();
            }
            return csv;
        }
        private CSV() { m_ArrayData = new List<string[]>(); m_DictData = new Dictionary<string, List<string[]>>(); }
        /// <summary>
        /// 在列表中获取string
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public string GetStringInArrayData(int row, int col)
        {
            return m_ArrayData[row][col];
        }
        /// <summary>
        /// 在列表中获取int
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public int GetIntInArrayData(int row, int col)
        {
            return int.Parse(m_ArrayData[row][col]);
        }
        /// <summary>
        /// 在列表中获取double
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public double GetDoubleInArrayData(int row, int col)
        {
            return double.Parse(m_ArrayData[row][col]);
        }
        /// <summary>
        /// 读取单个表格
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        public void LoadFile(string path, string fileName)
        {
            m_ArrayData.Clear();
            StreamReader sr = null;
            try
            {
                sr = File.OpenText(path + @"//" + fileName);
                Debug.Log("file finded!");
            }
            catch
            {
                Debug.Log("file don't finded!");
                return;
            }
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                m_ArrayData.Add(line.Split(','));
            }
            Debug.Log(m_ArrayData.Count);
            sr.Close();
            sr.Dispose();
        }
        /// <summary>
        /// 读取多个表格
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        public void LoadMultipleFile(string[] path, string[] fileName)
        {
            // m_DictData.Clear();
            for (int i = 0; i < path.Length; i++)
            {
                int index = i;

                StreamReader sr = null;
                string key = fileName[index];
                try
                {
                    //FileInfo file = new FileInfo(path[index] + "/" + key);
                    //FileStream fs = file.OpenRead();
                    //sr = new StreamReader(fs, System.Text.Encoding.GetEncoding("gb2312"));
                    sr = File.OpenText(path[index] + "/" + key);
                    Debug.Log("file finded!");
                }
                catch
                {
                    Debug.Log("file don't finded!--" + path[index] + "/" + key);
                    return;
                }
                string line;
                if (!m_DictData.ContainsKey(key))
                {
                    m_DictData.Add(key, new List<string[]>());
                }
                else
                {
                    m_DictData[key].Clear();
                }

                while ((line = sr.ReadLine()) != null)
                {
                    m_DictData[key].Add(line.Split('\t'));
                }
                sr.Close();
                sr.Dispose();
            }
        }
        /// <summary>
        /// 在字典中获取string
        /// </summary>
        /// <param name="key"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public string GetStringInDictData(string key,int row, int col)
        {
            return m_DictData[key][row][col];
        }
        /// <summary>
        /// 在字典中获取int
        /// </summary>
        /// <param name="key"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public int GetIntInDictData(string key, int row, int col)
        {
            return int.Parse(m_DictData[key][row][col]);
        }
        /// <summary>
        /// 在字典中获取double
        /// </summary>
        /// <param name="key"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public double GetDoubleInDictData(string key, int row, int col)
        {
            return double.Parse(m_DictData[key][row][col]);
        }
        /// <summary>
        /// 根据ID获取所有数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<string[]> GetAllValuesForKey(string key)
        {
            if (m_DictData.ContainsKey(key))
            {
                return m_DictData[key];
            }
            return new List<string[]>();
        }
    }
}

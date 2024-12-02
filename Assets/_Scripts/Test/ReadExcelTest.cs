using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Threading;
using System;


namespace Test
{
    public class ReadExcelTest
    {
      
        public void ReadExcel(string path, UnityAction<float,bool> EndHandle)
        {
            HSSFWorkbook wk;
            ISheet sheet;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                wk = new HSSFWorkbook(fs);
                sheet = wk.GetSheetAt(0);
                //fs.Flush();
                fs.Close();
            }
            int row = sheet.LastRowNum;//行
            bool idDown;
            for (int i = 1; i < row; i++)
            {
                idDown = (i == row - 1);
                 ICell cell = sheet.GetRow(i).GetCell(2);
                EndHandle((float)cell.NumericCellValue, idDown);
                //Debug.Log(cell.NumericCellValue);
            }
        }
       /// <summary>
       /// 在新线程中读取数据
       /// </summary>
       /// <param name="path"></param>
       /// <param name="EndHandle"></param>
        public void ReadExcel_NewThread(string path, UnityAction<float,bool> EndHandle)
        {
            ThreadStart starter = delegate { ReadExcel(path, EndHandle); };
            Thread thread = new Thread(starter);
            thread.Start();
        }
    }
}

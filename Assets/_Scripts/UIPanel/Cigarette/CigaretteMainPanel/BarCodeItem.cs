using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Cigarette
{
    /// <summary>
    /// 条码子物体
    /// </summary>
    public class BarCodeItem : MonoBehaviour
    {
        private Text nameText;
        /// <summary>
        /// 名称
        /// </summary>
        private Text NameText
        {
            get
            {
                if (nameText==null)
                {
                    nameText = transform.FindChildForName("NameText").GetComponent<Text>();
                }
                return nameText;
            }
        }
        private Text numText;
        /// <summary>
        /// 名称
        /// </summary>
        private Text NumText
        {
            get
            {
                if (numText == null)
                {
                    numText = transform.FindChildForName("NumText").GetComponent<Text>();
                }
                return numText;
            }
        }
        /// <summary>
        /// 设置文字内容
        /// </summary>
        /// <param name="name"></param>
        /// <param name="num"></param>
        public void Set_NameNum(string nameValue, string numValue)
        {
            NameText.text = nameValue;
            NumText.text = numValue;
        }
    }
}

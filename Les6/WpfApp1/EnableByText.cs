using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

/// <summary>
/// Алексей Кулик kpblc2000@yandex.ru
/// C#, уровень 2, урок 5
/// </summary>
namespace KulikWPF
{
    /// <summary>
    /// 
    /// </summary>
    public static class EnableByText
    {
        /// <summary>
        /// Установка доступности контролов на основе значений текстового бокса
        /// </summary>
        /// <param name="textBox">Текстовое поле</param>
        /// <param name="ControlArray">Список контролов, доступность которых надо установить</param>
        public static void MakeEnabled(TextBox textBox, List<Control> ControlArray)
        {
            bool en = textBox.Text.Trim(new char[] { ' ' }) != "";
            for (int i = 0; i < ControlArray.Count; i++)
            {
                ControlArray[i].IsEnabled = en;
            }
        }

        /// <summary>
        /// Установка доступности контрола на основании значений текстового бокса
        /// </summary>
        /// <param name="textBox">Текстовое поле</param>
        /// <param name="ctrl">Контрол, доступносьт которого надо установить</param>
        public static void MakeEnabled(TextBox textBox, Control ctrl)
        {
            ctrl.IsEnabled = textBox.Text.Trim(new char[] { ' ' }) != "";
        }
    }
}

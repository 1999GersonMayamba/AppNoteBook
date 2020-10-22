using System;
using System.Collections.Generic;
using System.Text;

namespace AppCloudEditor.INTERFACE
{
  public  interface IMessage
    {
        void LongAlert(string message);
        void ShortAlert(string message);
        void LongCenterMessageAlert(string message);
    }
}

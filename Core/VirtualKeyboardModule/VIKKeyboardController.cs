using System.Windows.Forms;

namespace VIK.Core.VirtualKeyboardModule
{
    class VIKKeyboardController
    {
        public VIKKeyboardController()
        {

        }

        public void PressKey(string key)
        {
            SendKeys.Send(key);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotKey
{
    public class MyLabel : Label
    {
        public MyLabel():base()
        {
            //注册热键Ctrl+C，Id号为100。。
            HotKeysManager.RegisterHotKey(Handle, 100, HotKeysManager.KeyModifiers.Ctrl, Keys.C);
            //注册热键Ctrl+V，Id号为101。
            HotKeysManager.RegisterHotKey(Handle, 101, HotKeysManager.KeyModifiers.Ctrl, Keys.V);

            ////注销Id号为100的热键设定
            //HotKeysManager.UnregisterHotKey(Handle, 100);
            ////注销Id号为101的热键设定
            //HotKeysManager.UnregisterHotKey(Handle, 101);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            //按快捷键 
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case 100:
                            Clipboard.SetText(this.Text);
                            break;
                        case 101:
                            this.Text = Clipboard.GetText();
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        public void UnregisterHotKeys()
        {
            //注销Id号为100的热键设定
            HotKeysManager.UnregisterHotKey(Handle, 100);
            //注销Id号为101的热键设定
            HotKeysManager.UnregisterHotKey(Handle, 101);

        }

    }
}

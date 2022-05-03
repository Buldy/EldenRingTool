using System.Windows.Forms;

namespace Elden_Ring_Tool {
    class ScreenObj {
        public Screen screen = null;

        public ScreenObj(Screen scr) {
            screen = scr;
        }

        public override string ToString() {
            return screen.DeviceName;
        }
    }
}

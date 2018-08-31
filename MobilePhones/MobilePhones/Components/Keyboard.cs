using System;

namespace MobilePhones.Components {
    
    public abstract class KeyboardBase {

        public abstract void Lock(bool isLocked);
        public abstract void EnterText(string newText);

    }
    
    public class Keyboard : KeyboardBase {

        private string layoutType = "EN/RUS/UA";
        private int lettersNum = 102;

        public string LayoutType
        {
            get { return layoutType; }
            set { layoutType = value; }
        }

        public int LettersNum
        {
            get { return lettersNum; }
            set { lettersNum = value; }
        }

        public Keyboard() {}

        public Keyboard(string layoutType, int lettersNum) {
            this.layoutType = layoutType;
            this.lettersNum = lettersNum;
        }

        public override string ToString() {
            return "Simple keyboard";
        }

        public override void Lock(bool isLocked) {
            var lockText = isLocked ? "locked" : "unlocked";
            Console.WriteLine("Keyboard is " + lockText);
        }
        
        public override void EnterText(string newText) {
            Console.WriteLine("Text is entered:" + newText);
        }

    }

    public class TouchKeyboard : Keyboard {

        public TouchKeyboard() : base() {}

        public override string ToString() {
            return "Touch keyboard";
        }

    }
    
}

using System;

namespace MobilePhones.Components {
    
    public abstract class KeyboardBase {

        public abstract void Lock();

    }
    
    public class Keyboard : KeyboardBase {

        private string figures;
        private string letters;

        public string Figures
        {
            get { return figures; }
            set { figures = value; }
        }

        public string Letters
        {
            get { return letters; }
            set { letters = value; }
        }

        public Keyboard() {}

        public Keyboard(string figures, string letters) {
            this.figures = figures;
            this.letters = letters;
        }

        public override string ToString() {
            return "Simple keyboard";
        }

        public override void Lock() {
            Console.WriteLine("Keyboard is locked");
        }

    }

    public class TouchKeyboard : Keyboard {

        public TouchKeyboard() : base() {}

        public override string ToString() {
            return "Touch keyboard";
        }

    }
    
}

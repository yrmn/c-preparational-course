using System;
using MobilePhones.Content;

namespace MobilePhones.Components {

    public abstract class ScreenBase {

        public abstract void Show(IScreenImage screenImage);
        
    }

    public class Screen : ScreenBase {

        private double size = 7.1;
        private int dpi = 326;
        private int brightness = 70;

        public Screen() {}

        public Screen(double size, int dpi, int brightness) {
            this.size = size;
            this.dpi = dpi;
            this.brightness = brightness;
        }

        public double Size {
            get { return size; }
            set { size = value; }
        }

        public int Dpi {
            get { return dpi; }
            set { dpi = value; }
        }

        public int Brightness
        {
            get { return brightness; }
            set { brightness = value; }
        }

        public override string ToString() {
            return "Simple screen";
        }
        
        public override void Show(IScreenImage screenImage) {
            Console.WriteLine("Simple screen image");
        }
        
    }

    public class TouchScreen : Screen {

        public TouchScreen() : base() {}

        public override string ToString() {
            return "TouchScreen";
        }

        public override void Show(IScreenImage screenImage) {
            Console.WriteLine("TouchScreen screen image");
        }

    }

    public class SingleTouch: TouchScreen {

        public SingleTouch() : base() {}

        public override string ToString() {
            return "SingleTouch";
        }

        public override void Show(IScreenImage screenImage) {
            Console.WriteLine("SingleTouch screen image");
        }

    }

    public class MultiTouch : TouchScreen {

        public MultiTouch() : base() {}

        public override string ToString() {
            return "MultiTouch";
        }

        public override void Show(IScreenImage screenImage) {
            Console.WriteLine("MultiTouch screen image");
        }

    }

}

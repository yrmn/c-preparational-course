using System;
using MobilePhones.Content;

namespace MobilePhones.Components {

    public abstract class ScreenBase {

        public abstract void Show(IScreenImage screenImage);

        public abstract void Show(IScreenImage screenImage, int brightness);

    }

    public class Screen : ScreenBase {

        private double size;
        private int pixels;

        public Screen() {}

        public Screen(double size, int pixels) {
            this.size = size;
            this.pixels = pixels;
        }

        public double Size {
            get { return size; }
            set { size = value; }
        }

        public int Pixels {
            get { return pixels; }
            set { pixels = value; }
        }

        public override string ToString() {
            return "Simple screen";
        }
        
        public override void Show(IScreenImage screenImage) {
            Console.WriteLine("Simple screen image");
        }
        
        public override void Show(IScreenImage screenImage, int brightness) {
            Console.WriteLine("Simple screen image with " + brightness + " brightness");
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

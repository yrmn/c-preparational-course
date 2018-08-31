using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePhones.Components;
using MobilePhones.Content;

namespace MobilePhones {

    public abstract class MobilePhone {
        
        public abstract AerialBase AerialBase { get; }
        public abstract BatteryBase BatteryBase { get; }
        public abstract DynamicBase DynamicBase { get; }
        public abstract KeyboardBase KeyboardBase { get; }
        public abstract MicrophoneBase MicrophoneBase { get; }
        public abstract ScreenBase ScreenBase { get; }
        public abstract SimCardBase SimCardBase { get; }
        
        private void Show(IScreenImage screenImage) {
            ScreenBase.Show(screenImage);
        }

        public string GetDescription() {
            var descriptionBuilder = new StringBuilder();
            descriptionBuilder.AppendLine($"Aerial Type: {AerialBase.ToString()}");
            descriptionBuilder.AppendLine($"Battery Type: {BatteryBase.ToString()}");
            descriptionBuilder.AppendLine($"Dynamic Type: {DynamicBase.ToString()}");
            descriptionBuilder.AppendLine($"Keyboard Type: {KeyboardBase.ToString()}");
            descriptionBuilder.AppendLine($"Microphone Type: {MicrophoneBase.ToString()}");
            descriptionBuilder.AppendLine($"Screen Type: {ScreenBase.ToString()}");
            descriptionBuilder.AppendLine($"SimCard Type: {SimCardBase.ToString()}");
            return descriptionBuilder.ToString();
        }
        
    }

}

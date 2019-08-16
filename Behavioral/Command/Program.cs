﻿using System;

namespace Command
{
    internal static class Program
    {
        private static void Main()
        {
            var remote = new RemoteControl(3);


            var bike = new Garage("Bike");
            var bikeDoorClose = new GarageDoorCloseCommand(bike);
            var bikeDoorOpen = new GarageDoorOpenCommand(bike);

            var car = new Garage("Car");
            var carDoorClose = new GarageDoorCloseCommand(car);
            var carDoorOpen = new GarageDoorOpenCommand(car);

            var light = new Light("Hall");

            var garageButton = new OnOffStruct
            {
                On = bikeDoorOpen,
                Off = bikeDoorClose
            };

            remote[0] = garageButton;
            remote.PushOn(0);
            remote.PushUndo();
            remote.PushUndo();
            remote.PushOff(0);

            Console.WriteLine();

            ICommand[] partyOn = { new LightOffCommand(light), bikeDoorOpen, carDoorOpen };
            ICommand[] partyOff = { new LightOnCommand(light), bikeDoorClose, carDoorClose };

            remote[2] = new OnOffStruct {On = new MacroCommand(partyOn), Off = new MacroCommand(partyOff)};

            remote.PushOn(1);
            remote.PushOn(2);
            Console.WriteLine();
            remote.PushOff(2);

            Console.ReadKey();
        }
    }
}
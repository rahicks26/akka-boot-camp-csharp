using System;
using Akka.Actor;
using WinTail;

namespace WinTail
{
    /// <summary>
    /// Actor responsible for serializing message writes to the console.
    /// (write one message at a time, champ :)
    /// </summary>
    internal class ConsoleWriterActor : UntypedActor
    {
        // in ConsoleWriterActor.cs
        protected override void OnReceive(object message)
        {
            void onInputError(Messages.InputError msg)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(msg.Reason);
            }

            void onSuccess(Messages.InputSuccess msg)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(msg.Reason);
            }

            if (message is Messages.InputError errorMsg) { onInputError(errorMsg); }
            else if (message is Messages.InputSuccess successMsg) { onSuccess(successMsg); }
            else { Console.WriteLine(message); }

            Console.ResetColor();
        }
    }
}
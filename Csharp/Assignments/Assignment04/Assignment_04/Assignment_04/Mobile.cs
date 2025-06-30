using System;

public class MobilePhone
{
    public delegate void RingEventHandler();
    public event RingEventHandler OnRing;

    public void ReceiveCall()
    {
        Console.WriteLine("Incoming call...");
        OnRing?.Invoke();
    }
}

public class RingtonePlayer
{
    public void PlayRingtone()
    {
        Console.WriteLine("Playing ringtone...");
    }
}

public class ScreenDisplay
{
    public void ShowCallerInfo()
    {
        Console.WriteLine("Displaying caller information...");
    }
}

public class VibrationMotor
{
    public void Vibrate()
    {
        Console.WriteLine("Phone is vibrating...");
    }
     
}

class Mobile
{
    static void Main()
    {
        MobilePhone ph = new MobilePhone();

        RingtonePlayer ringtone = new RingtonePlayer();
        ScreenDisplay screen = new ScreenDisplay();
        VibrationMotor vibration = new VibrationMotor();

        ph.OnRing += ringtone.PlayRingtone;
        ph.OnRing += screen.ShowCallerInfo;
        ph.OnRing += vibration.Vibrate;

        ph.ReceiveCall();
        Console.ReadLine();

    }
}


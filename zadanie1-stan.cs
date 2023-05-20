using System;

// wzorzec: Stan

public interface IATMState
{
    void InsertCard();
    void EnterPin();
    void WithdrawCash();
}

// Implementacja poszczególnych stanów bankomatu
public class WaitingForCardState : IATMState
{
    public void InsertCard()
    {
        Console.WriteLine("Karta została włożona.");
    }

    public void EnterPin()
    {
        Console.WriteLine("Nie można wprowadzić PINu bez karty.");
    }

    public void WithdrawCash()
    {
        Console.WriteLine("Nie można wypłacić gotówki bez karty.");
    }
}

public class WaitingForPinState : IATMState
{
    public void InsertCard()
    {
        Console.WriteLine("Karta jest już w bankomacie.");
    }

    public void EnterPin()
    {
        Console.WriteLine("PIN wprowadzony prawidłowo.");
    }

    public void WithdrawCash()
    {
        Console.WriteLine("Nie można wypłacić gotówki bez wprowadzenia PINu.");
    }
}

public class ReadyForOperationState : IATMState
{
    public void InsertCard()
    {
        Console.WriteLine("Karta jest już w bankomacie.");
    }

    public void EnterPin()
    {
        Console.WriteLine("PIN został już wprowadzony.");
    }

    public void WithdrawCash()
    {
        Console.WriteLine("Wypłacanie gotówki...");
    }
}

// Klasa reprezentująca bankomat
public class ATM
{
    private IATMState _state;

    public IATMState WaitingForCardState { get; private set; }
    public IATMState WaitingForPinState { get; private set; }
    public IATMState ReadyForOperationState { get; private set; }

    public ATM()
    {
        WaitingForCardState = new WaitingForCardState();
        WaitingForPinState = new WaitingForPinState();
        ReadyForOperationState = new ReadyForOperationState();

        _state = WaitingForCardState;
    }

    public void InsertCard()
    {
        _state.InsertCard();
        _state = WaitingForPinState;
    }

    public void EnterPin()
    {
        _state.EnterPin();
        _state = ReadyForOperationState;
    }

    public void WithdrawCash()
    {
        _state.WithdrawCash();
        _state = WaitingForCardState;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        var atm = new ATM();

        atm.InsertCard();
        atm.EnterPin();
        atm.WithdrawCash();

        atm.EnterPin();
        atm.WithdrawCash();
        atm.InsertCard();
    }
}

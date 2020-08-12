public abstract class Link
{
    private Link nextLink;

    public void SetSuccessor(Link next)
    {
        nextLink = next;
    }

    public virtual string Execute(int currentNumber, int previousNumber, string text)
    {
        if (nextLink != null)
        {
            return nextLink.Execute(currentNumber, previousNumber, text);
        }
        return string.Empty;
    }
}

public class FirstLink : Link
{
    public override string Execute(int currentNumber, int previousNumber, string text)
    {
        if (currentNumber <= 20)
        {
            return Lookup.NumberTexts[currentNumber];
        }

        return base.Execute(currentNumber, previousNumber, text);
    }
}

public class SecondLink : Link
{
    public override string Execute(int currentNumber, int previousNumber, string text)
    {
        if (currentNumber < 100)
        {
            return Lookup.NumberTexts[currentNumber - previousNumber] + (string.IsNullOrEmpty(text) ? string.Empty : " ") + text;
        }

        return base.Execute(currentNumber, previousNumber, text);
    }
}

public class ThirdLink : Link
{
    public override string Execute(int currentNumber, int previousNumber, string text)
    {
        if (currentNumber < 1000)
        {
            return Lookup.NumberTexts[(currentNumber - previousNumber) / 100] + $" {Lookup.NumberTexts[100]}" + (string.IsNullOrEmpty(text) ? string.Empty : " and ") + text;
        }

        return base.Execute(currentNumber, previousNumber, text);
    }
}
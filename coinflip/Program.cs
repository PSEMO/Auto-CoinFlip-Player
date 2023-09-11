Random rnd = new Random();

double Heads = 0;
double Tails = 0;
double CurrentTry = 0;

double ReportEveryXTimesStart = 1;
double ReportEveryXTimesEnd = 100000000;//100.000.000
double TempCurrentTry = 0;

string TailsPercentage;
string HeadsPercentage;

Console.ReadLine();

while (true)
{
    CurrentTry++;
    TempCurrentTry++;

    if (rnd.Next(0, 2) == 0)
        Heads++;
    else
        Tails++;

    TailsPercentage = Percentage(Tails, CurrentTry);
    HeadsPercentage = Percentage(Heads, CurrentTry);

    if (TailsPercentage == HeadsPercentage)
    {
        PrintOutInfos();

        CurrentTry = 0;
        ReportEveryXTimesStart = 1;
        TempCurrentTry = 0;
        Heads = 0;
        Tails = 0;

        Console.WriteLine("------------------------------------------------");
        Console.ReadLine();
    }

    if (TempCurrentTry == ReportEveryXTimesStart)
    {
        ReportEveryXTimesStart *= 10;
        if (ReportEveryXTimesStart > ReportEveryXTimesEnd)
        {
            ReportEveryXTimesStart = ReportEveryXTimesEnd;
            TempCurrentTry = 0;
        }

        PrintOutInfos();
    }
}

void PrintOutInfos()
{
    Console.WriteLine("Flip Count: " + CurrentTry.ToString("#,###"));
    Console.WriteLine("Tails: " + TailsPercentage);
    Console.WriteLine("Heads: " + HeadsPercentage);
}

string Percentage(double Number, double Total)
{
    return ((Number / Total) * 100d).ToString("F3") + "%";
}
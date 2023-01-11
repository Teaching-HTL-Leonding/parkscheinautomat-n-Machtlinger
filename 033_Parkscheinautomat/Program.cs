Console.Clear();

int time = 0;
int counter = 0;
bool done = false;

PrintWelcome();
{
    do
    {
        Console.WriteLine($"The current Parktime until now: {PrintParkingTime()}");
        Console.Write("Your input: ");
        string input = Console.ReadLine()!;

        counter++;
        done = EnterCoins(input, counter);
    } while (!done);
}

void PrintWelcome()
{
    Console.WriteLine("Parking ticket machine :");
}

bool EnterCoins(string input, int counter)
{
    if (input == "d" || input == "D")
        if (counter == 1)
        {
            Console.WriteLine("Minimum is 50 cent");
            return false;
        }
        else
        {
            Console.WriteLine($"You can park here for {PrintParkingTime()}hours");
            return true;
        }
    else
    {
        AddParkingTime(input);
        if (time >= 130)
        {
            Console.WriteLine(PrintParkingTime());
            PrintDonation();
            return true;
        }
        else
        {
            return false;
        }
    }
}

int AddParkingTime(string input)
{
    switch (input)
    {
        case "5":
            time += 3;
            break;
        case "10":
            time += 6;
            break;
        case "20":
            time += 12;
            break;
        case "50":
            time += 30;
            break;
        case "1":
            time += 60;
            break;
        case "2":
            time += 120;
            break;
        default:
            time += 0;
            break;
    }
    return time;
}

string PrintParkingTime()
{
    int hours = time / 60;
    if (hours > 1)
        return $"You can here for 1.30 hours";
    else
        return $"{hours}:{time - (hours * 60)}";
}

void PrintDonation()
{
    double donation = Convert.ToDouble(time / 60.00 - 1.50);
    Console.WriteLine($"Thank you for{donation:f2} donation");
}
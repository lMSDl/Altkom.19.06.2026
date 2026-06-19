using ConsoleApp;

Console.WriteLine("Hello, World!");


int Sum(int a, int b) //int, Sum, (, int, a, int, b, )
    => a + b; 


//substract two float numbers and return integer result
int Subtract(float a, float b)
{
    return (int)(a - b);
}


//multiply two numbers
int Multiply(int a, int b)
{
    return a * b;
}

//pierwotnie wygenerowana funkcja Sum została zmodyfikowana przez użytkownika
//co spwodowało, że model dostosował kolejny generowany kod (Multiply) do zmian użytkownika
//kontenst "nauki" copilot jest ograniczony do bieżącej sesji - np. wyłączenie IDE powoduje utratę pamięci "nauki"

//dzielenie dwóch liczb
float Divide(float a, float b)
{
    if (b == 0)
    {
        throw new DivideByZeroException("Cannot divide by zero.");
    }
    return a / b;
}
/*
        Opisowe(naturalny język) – piszemy w komentarzu dokładnie, co chcemy uzyskać. Przykład:
        // Napisz metodę, która zwraca listę użytkowników posortowaną malejąco po dacie rejestracji
        Copilot wygeneruje kod odpowiadający opisowi.

        Deklaratywne – zamiast opisywać krok po kroku, wskazujemy efekt końcowy. Przykład:
        // Walidacja numeru PESEL
        Copilot wygeneruje całą metodę walidacji, łącznie z regexem lub logiką.

        Krok po kroku – dzielimy zadanie na mniejsze fragmenty, dzięki czemu mamy większą kontrolę nad wynikiem. Przykład:
        // 1. Sprawdź, czy numer ma 11 cyfr
        // 2. Oblicz sumę kontrolną
        // 3. Zwróć true/false

        Każdy styl ma swoje zastosowanie – opisowy dla szybkiego prototypowania, krokowy dla bardziej krytycznego kodu, deklaratywny dla standardowych fragmentów.
*/

//funkcja generująca listę 10 produktów klasy Product
//zmień typ zwracany na IEnumerable<Product> i użyj yield return zamiast List<Product>
IEnumerable<Product> GenerateProducts()
{
    for (int i = 1; i <= 10; i++)
    {
        yield return new Product
        {
            Name = $"Product {i}",
            Price = 10.99m * i,
            Description = $"Description for Product {i}",
            Category = $"Category {(i % 3) + 1}",
            Quality = (i % 2 == 0) ? "High" : "Low"
        };
    }
}

Point3D CreatePoint(float[] data)
{
    if (data.Length < 3)
    {
        throw new ArgumentException("Data array must contain at least three elements.");
    }
    return new Point3D(data[0], data[1], data[2]);
} 


public class PeselValidator
{
    public static bool IsValidPesel(string pesel)
    {
        if (string.IsNullOrWhiteSpace(pesel) || pesel.Length != 11)
            return false;

        if (!pesel.All(char.IsDigit))
            return false;

        int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
        int sum = 0;

        for (int i = 0; i < 10; i++)
        {
            sum += (int.Parse(pesel[i].ToString()) * weights[i]);
        }

        int checkDigit = (10 - (sum % 10)) % 10;
        int lastDigit = int.Parse(pesel[10].ToString());

        return checkDigit == lastDigit;
    }

    public static (bool IsValid, string Gender) ValidatePeselWithGender(string pesel)
    {
        if (!IsValidPesel(pesel))
            return (false, "Nie dotyczy");

        int genderDigit = int.Parse(pesel[9].ToString());
        string gender = genderDigit % 2 == 0 ? "Female" : "Male";

        return (true, gender);
    }
}